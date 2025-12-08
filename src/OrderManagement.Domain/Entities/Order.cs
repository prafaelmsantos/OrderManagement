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

        public Order(string? observations, long customerId)
        {
            Validator.New()
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Observations = observations;
            CustomerId = customerId;

            CreatedDate = DateTime.UtcNow;
        }

        public void Update(string? observations, long customerId)
        {
            Validator.New()
                .When(customerId <= 0, "O id do cliente associado ao pedido é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Observations = observations;
            CustomerId = customerId;
        }

        public void SetProductsOrders(List<ProductOrder> productsToOrders)
        {
            ProductsOrders.Clear();
            ProductsOrders = productsToOrders;
        }
    }
}
