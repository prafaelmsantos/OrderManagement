namespace OrderManagement.Application.Dtos
{
    public sealed record CustomerDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? StoreName { get; set; }
        public string? PaymentMethod { get; set; }
        public string? TaxIdentificationNumber { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
