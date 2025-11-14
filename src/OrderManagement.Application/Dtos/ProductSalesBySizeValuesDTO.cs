namespace OrderManagement.Application.Dtos
{
    public sealed record ProductSalesBySizeValuesDTO
    {
        public string Size { get; set; } = string.Empty;
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
