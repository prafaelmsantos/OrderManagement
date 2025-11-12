namespace OrderManagement.Application.Dtos
{
    public sealed record ProductDTO
    {
        public long Id { get; set; }
        public string Reference { get; set; } = null!;
        public string? Description { get; set; }
        public double UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
