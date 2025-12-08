namespace OrderManagement.Application.Dtos
{
    public sealed record CustomerTableDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? TaxIdentificationNumber { get; set; }
        public string? Contact { get; set; }
        public string? FullAddress { get; set; }
        public int TotalOrders { get; set; }
        public string CreatedDate { get; set; } = null!;
    }
}
