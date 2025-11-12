namespace OrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; private set; }
        public string? Observations { get; private set; }
        public string? PaymentMethod { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        public long CustomerId { get; private set; }
        public virtual Customer Customer { get; private set; } = null!;

        public virtual ICollection<ProductOrder> ProductsOrders { get; private set; } = [];

        protected Order() { }

        public Order(long id, OrderStatus status, string? observations, string? paymentMethod, long customerId)
        {
            Validator.New()
                .When(id <= 0, "O id do pedido é inválido.")
                .When(!Enum.IsDefined(typeof(OrderStatus), status), "O status do pedido é inválido.")
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Id = id;
            Status = status;
            Observations = observations;
            PaymentMethod = paymentMethod;
            CustomerId = customerId;
        }

        public Order(OrderStatus status, string? observations, string? paymentMethod, long customerId)
        {
            Validator.New()
                .When(!Enum.IsDefined(typeof(OrderStatus), status), "O status do pedido é inválido.")
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Status = status;
            Observations = observations;
            PaymentMethod = paymentMethod;
            CustomerId = customerId;
        }

        public void Update(OrderStatus status, string? observations, string? paymentMethod, long customerId)
        {
            Validator.New()
                .When(!Enum.IsDefined(typeof(OrderStatus), status), "O status do pedido é inválido.")
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Status = status;
            Observations = observations;
            PaymentMethod = paymentMethod;
            CustomerId = customerId;
        }

        public void SetProductsOrders(List<ProductOrder> productsToOrders)
        {
            ProductsOrders.Clear();
            ProductsOrders = productsToOrders;
        }
    }
}
