namespace OrderManagement.Application.Dtos
{
    public sealed record ProductOrderDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public ProductDTO? Product { get; set; }

        public long OrderId { get; set; }
        public OrderDTO? Order { get; set; }

        public string? Color { get; set; }
        public double UnitPrice { get; set; }

        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }

        public int ZeroMonths { get; set; }
        public int OneMonth { get; set; }
        public int ThreeMonths { get; set; }
        public int SixMonths { get; set; }
        public int TwelveMonths { get; set; }
        public int EighteenMonths { get; set; }
        public int TwentyFourMonths { get; set; }
        public int ThirtySixMonths { get; set; }

        public int OneYear { get; set; }
        public int TwoYears { get; set; }
        public int ThreeYears { get; set; }
        public int FourYears { get; set; }
        public int SixYears { get; set; }
        public int EightYears { get; set; }
        public int TenYears { get; set; }
        public int TwelveYears { get; set; }
    }
}
