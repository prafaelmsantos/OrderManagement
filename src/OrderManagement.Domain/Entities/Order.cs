namespace OrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public long CustomerId { get; private set; }
        public virtual Customer Customer { get; private set; } = null!;

        public virtual ICollection<ProductOrder> ProductsOrders { get; private set; } = [];

        protected Order() { }

        public Order(long id, OrderStatus status, long customerId)
        {
            Id = id;
            Status = status;
            CustomerId = customerId;
        }

        public Order(OrderStatus status, long customerId)
        {
            Status = status;
            CustomerId = customerId;
        }

        public void Update(OrderStatus status, long customerId)
        {
            Status = status;
            CustomerId = customerId;
        }

        public void SetProductsOrders(List<ProductOrder> productsToOrders)
        {
            ProductsOrders.Clear();
            ProductsOrders = productsToOrders;
        }
    }
}
