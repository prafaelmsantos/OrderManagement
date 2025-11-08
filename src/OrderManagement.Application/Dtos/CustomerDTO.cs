namespace OrderManagement.Application.Dtos
{
    public sealed class CustomerDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string TaxIdentificationNumber { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string FullAddress { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
