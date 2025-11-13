namespace OrderManagement.Application.Dtos
{
    public sealed record CustomerOrdersTableDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public List<OrderTableDTO> Orders { get; set; } = [];
    }
}
