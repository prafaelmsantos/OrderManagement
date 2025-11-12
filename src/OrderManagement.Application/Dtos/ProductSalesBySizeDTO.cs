namespace OrderManagement.Application.Dtos
{
    public class ProductSalesBySizeDTO
    {
        public string? Color { get; set; }
        public string Size { get; set; } = null!;
        public int Index { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
