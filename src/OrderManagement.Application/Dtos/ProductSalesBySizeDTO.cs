namespace OrderManagement.Application.Dtos
{
    public sealed record ProductSalesBySizeDTO
    {
        public string? Color { get; set; }
        public int TotalQuantity { get; set; }
        public List<ProductSalesBySizeValuesDTO> Values { get; set; } = [];
    }
}
