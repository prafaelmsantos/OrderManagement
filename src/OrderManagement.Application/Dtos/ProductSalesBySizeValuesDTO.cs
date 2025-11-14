namespace OrderManagement.Application.Dtos
{
    public sealed record ProductSalesBySizeValuesDTO
    {
        public ProductSize Size { get; set; }
        public int TotalQuantity { get; set; }
    }
}
