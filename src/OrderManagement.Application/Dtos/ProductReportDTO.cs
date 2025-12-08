namespace OrderManagement.Application.Dtos
{
    public sealed record ProductReportDTO
    {
        public long ProductId { get; set; }
        public ProductDTO Product { get; set; } = null!;
        public int TotalQuantity { get; set; }
        public List<ProductSalesBySizeDTO> ProductSalesBySizes { get; set; } = [];
    }
}
