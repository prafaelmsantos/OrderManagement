namespace OrderManagement.Application.Dtos
{
    public sealed class OrderDTO
    {
        public long Id { get; set; }
        public OrderStatus Status { get; set; }

        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public string? Observations { get; set; }
        public string? PaymentMethod { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CustomerId { get; set; }
        public CustomerDTO? Customer { get; set; }

        public List<ProductOrderDTO> ProductsOrders { get; set; } = [];
    }
}
