namespace OrderManagement.Application.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDTO ToCustomerDTO(this Customer customer)
        {
            if (customer is null)
            {
                return null!;
            }

            return new CustomerDTO()
            {
                Id = customer.Id,
                FullName = customer.FullName,
                TaxIdentificationNumber = customer.TaxIdentificationNumber,
                Contact = customer.Contact,
                Address = customer.Address,
                PostalCode = customer.PostalCode,
                City = customer.City,
                CreatedDate = customer.CreatedDate
            };
        }

        public static CustomerTableDTO ToCustomerTableDTO(this Customer customer)
        {
            return new CustomerTableDTO()
            {
                Id = customer.Id,
                FullName = customer.FullName,
                TaxIdentificationNumber = customer.TaxIdentificationNumber,
                Contact = customer.Contact,
                FullAddress = $"{customer.Address}, {customer.PostalCode} {customer.City}",
                TotalOrders = customer.Orders.Count,
                CreatedDate = customer.CreatedDate.ToString("dd/MM/yyyy")
            };
        }
    }
}
