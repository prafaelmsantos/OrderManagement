namespace OrderManagement.Application.Dtos
{
    public sealed record ProductTableDTO
    {
        public long Id { get; set; }
        public string Reference { get; set; } = null!;
        public string? Description { get; set; }
        public string UnitPrice { get; set; } = null!;
        public int TotalOrders { get; set; }
        public string CreatedDate { get; set; } = null!;
    }
}
