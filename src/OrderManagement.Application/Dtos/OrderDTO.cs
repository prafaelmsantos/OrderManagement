namespace OrderManagement.Application.Dtos
{
    public sealed class OrderDTO
    {
        public long Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public int QuantityTotal { get; set; }
        public double PriceTotal { get; set; }

        public long CustomerId { get; set; }
        public CustomerDTO Customer { get; set; } = null!;

        public List<ProductOrderDTO> ProductsOrders { get; set; } = [];
    }
}
