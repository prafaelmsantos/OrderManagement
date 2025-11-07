namespace OrderManagement.Application.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDTO ToCustomerDTO(this Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                TaxIdentificationNumber = customer.TaxIdentificationNumber.ToString(),
                Contact = customer.Contact,
                Address = customer.Address,
                PostalCode = customer.PostalCode,
                City = customer.City,
                FullAddress = $"{customer.Address}, {customer.PostalCode} {customer.City}",
                CreatedAt = customer.CreatedAt,
                Orders = [.. customer.Orders.Select(o => o.ToOrderDTO())]
            };
        }
    }
}
