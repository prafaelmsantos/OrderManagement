namespace OrderManagement.Application.Dtos
{
    public sealed record OrderTableDTO
    {
        public long Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }

        public long CustomerId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public string CustomerTaxIdentificationNumber { get; set; } = null!;
    }
}
