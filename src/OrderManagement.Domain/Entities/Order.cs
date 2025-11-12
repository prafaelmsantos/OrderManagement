namespace OrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string? Observations { get; private set; }
        public string? PaymentMethod { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public long CustomerId { get; private set; }
        public virtual Customer Customer { get; private set; } = null!;

        public virtual ICollection<ProductOrder> ProductsOrders { get; private set; } = [];

        protected Order() { }

        public Order(long id, string? observations, string? paymentMethod, long customerId)
        {
            Validator.New()
                .When(id <= 0, "O id do pedido é inválido.")
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Id = id;
            Observations = observations;
            PaymentMethod = paymentMethod;
            CustomerId = customerId;

            CreatedDate = DateTime.UtcNow;
        }

        public Order(string? observations, string? paymentMethod, long customerId)
        {
            Validator.New()
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Observations = observations;
            PaymentMethod = paymentMethod;
            CustomerId = customerId;

            CreatedDate = DateTime.UtcNow;
        }

        public void Update(string? observations, string? paymentMethod, long customerId)
        {
            Validator.New()
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

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
