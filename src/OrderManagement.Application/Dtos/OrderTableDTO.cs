namespace OrderManagement.Application.Dtos
{
    public sealed record OrderTableDTO
    {
        public long Id { get; set; }

        public int TotalQuantity { get; set; }
        public string TotalPrice { get; set; } = null!;

        public long CustomerId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public string? CustomerTaxIdentificationNumber { get; set; }

        public string CreatedDate { get; set; } = null!;
    }
}
