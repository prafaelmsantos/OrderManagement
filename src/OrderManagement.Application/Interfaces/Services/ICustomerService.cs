namespace OrderManagement.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerTableDTO>> GetAllCustomersTableAsync();
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(long customerId);
        Task<CustomerDTO> AddCustomerAsync(CustomerDTO customerDTO);
        Task<CustomerDTO> UpdateCustomerAsync(CustomerDTO customerDTO);
        Task<List<BaseResponseDTO>> DeleteCustomersAsync(List<long> customersIds);
    }
}
