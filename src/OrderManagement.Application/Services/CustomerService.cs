namespace OrderManagement.Application.Services
{
    public sealed class CustomerService : ICustomerService
    {
        #region Private variables
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region Constructors
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Public methods
        public async Task<List<CustomerTableDTO>> GetAllCustomersAsync()
        {
            List<Customer> customers = await _customerRepository
                .GetAllQueryable()
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return [.. customers.Select(x => x.ToCustomerTableDTO())];
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(long customerId)
        {
            Customer customer = await GetCustomerAsync(customerId);

            return customer.ToCustomerDTO();
        }

        public async Task<CustomerDTO> AddCustomerAsync(CustomerDTO customerDTO)
        {
            await ExistsAsync(customerDTO);

            Customer customer = new Customer(
                customerDTO.FullName,
                customerDTO.TaxIdentificationNumber,
                customerDTO.Contact,
                customerDTO.Address,
                customerDTO.PostalCode,
                customerDTO.City
            );

            customer = await _customerRepository.AddAsync(customer);

            return customer.ToCustomerDTO();
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            Customer customer = await GetCustomerAsync(customerDTO.Id);

            await ExistsAsync(customerDTO);

            customer.Update(
                customerDTO.FullName,
                customerDTO.TaxIdentificationNumber,
                customerDTO.Contact,
                customerDTO.Address,
                customerDTO.PostalCode,
                customerDTO.City);

            customer = await _customerRepository.UpdateAsync(customer);

            return customer.ToCustomerDTO();
        }

        public async Task<List<BaseResponseDTO>> DeleteCustomersAsync(List<long> customersIds)
        {
            return await DeleteAsync(customersIds);
        }
        #endregion

        #region Private methods
        private async Task<Customer> GetCustomerAsync(long id)
        {
            Customer? customer = await _customerRepository.GetByIdAsync(id) ??
                throw new Exception("Erro ao tentar encontrar o cliente por id.");

            return customer!;
        }

        private async Task ExistsAsync(CustomerDTO customerDTO)
        {
            bool exists = await _customerRepository
                .GetAllQueryable()
                .AnyAsync(x => x.Id != customerDTO.Id &&
                    x.TaxIdentificationNumber.Trim() == customerDTO.TaxIdentificationNumber.Trim());

            if (exists)
            {
                throw new Exception("O cliente já existe.");
            }
        }

        private async Task<List<BaseResponseDTO>> DeleteAsync(List<long> customersIds)
        {
            List<BaseResponseDTO> internalBaseResponseDTOs = [];

            foreach (long customerId in customersIds)
            {
                BaseResponseDTO internalBaseResponseDTO = new() { Id = customerId, Success = false };
                try
                {
                    Customer? customer = await _customerRepository.GetByIdAsync(customerId);

                    if (customer is not null)
                    {
                        if (customer.Orders.Count != 0)
                        {
                            internalBaseResponseDTO.Message = $"O cliente {customer.FullName} contém encomendas.";
                        }
                        else
                        {
                            await _customerRepository.RemoveAsync(customer);
                            internalBaseResponseDTO.Success = true;
                        }
                    }
                    else
                    {
                        internalBaseResponseDTO.Message = "Cliente não encontrado.";
                    }
                }
                catch (Exception)
                {
                    internalBaseResponseDTO.Message = "Erro ao tentar apagar o cliente.";
                }

                internalBaseResponseDTOs.Add(internalBaseResponseDTO);
            }

            return internalBaseResponseDTOs;
        }
        #endregion
    }
}
