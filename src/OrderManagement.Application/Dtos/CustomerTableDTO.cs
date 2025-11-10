namespace OrderManagement.Application.Dtos
{
    public sealed class CustomerTableDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string TaxIdentificationNumber { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string FullAddress { get; set; } = null!;
        public int TotalOrders { get; set; }
    }
}
