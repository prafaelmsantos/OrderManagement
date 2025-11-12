namespace OrderManagement.Application.Dtos
{
    public record class ProductTableDTO
    {
        public long Id { get; set; }
        public string Reference { get; set; } = null!;
        public string? Description { get; set; }
        public double UnitPrice { get; set; }
        public int TotalOrders { get; set; }
        public string CreatedDate { get; set; } = null!;
    }
}
