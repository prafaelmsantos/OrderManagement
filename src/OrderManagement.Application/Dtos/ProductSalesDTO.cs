namespace OrderManagement.Application.Dtos
{
    public sealed record ProductSalesDTO
    {
        public long Id { get; set; }
        public string? Color { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
