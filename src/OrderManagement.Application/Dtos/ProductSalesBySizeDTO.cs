namespace OrderManagement.Application.Dtos
{
    public sealed record ProductSalesBySizeDTO
    {
        public string Color { get; set; } = string.Empty;
        public List<ProductSalesBySizeValuesDTO> Values { get; set; } = [];
    }
}
