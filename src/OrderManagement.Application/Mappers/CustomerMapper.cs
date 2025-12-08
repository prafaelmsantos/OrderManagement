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
                StoreName = customer.StoreName,
                PaymentMethod = customer.PaymentMethod,
                TaxIdentificationNumber = customer.TaxIdentificationNumber,
                Contact = customer.Contact,
                Address = customer.Address,
                PostalCode = customer.PostalCode,
                City = customer.City,
                CreatedDate = customer.CreatedDate,
            };
        }

        public static CustomerOrdersTableDTO ToCustomerOrdersTableDTO(this Customer customer)
        {
            if (customer is null)
            {
                return null!;
            }

            return new CustomerOrdersTableDTO()
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Orders = customer.Orders.Select(x => x.ToOrderTableDTO()).ToList()
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
                FullAddress = GetFullAddress(customer),
                TotalOrders = customer.Orders.Count,
                CreatedDate = customer.CreatedDate.ToString("dd/MM/yyyy")
            };
        }

        private static string? GetFullAddress(Customer customer)
        {
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(customer.Address))
            {
                parts.Add(customer.Address);
            }

            string postalCity = $"{customer.PostalCode} {customer.City}".Trim();
            if (!string.IsNullOrWhiteSpace(postalCity))
            {
                parts.Add(postalCity);
            }

            return parts.Count == 0 ? null : string.Join(", ", parts);
        }
    }
}
