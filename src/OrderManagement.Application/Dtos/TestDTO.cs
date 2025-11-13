namespace OrderManagement.Application.Dtos
{
    public sealed record ProductSalesBySizeResponseDTO
    {
        public string Color { get; set; } = string.Empty;
        public List<ProductSalesBySizeValuesDTO> Values { get; set; } = [];
    }

    public sealed record ProductSalesBySizeValuesDTO
    {
        public string Size { get; set; } = string.Empty;
        public int Index { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
