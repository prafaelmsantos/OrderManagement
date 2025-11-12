namespace OrderManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Reference { get; private set; } = null!;
        public string? Description { get; private set; }
        public double UnitPrice { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public virtual ICollection<ProductOrder> ProductsOrders { get; private set; } = [];

        protected Product() { }

        public Product(long id, string reference, string? description, double unitPrice)
        {
            Validator.New()
                .When(id <= 0, "O id do produto é inválido.")
                .When(string.IsNullOrWhiteSpace(reference), "A referência do produto é inválida.")
                .When(unitPrice < 0, "O preço unitário do produto é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Id = id;
            Reference = reference;
            Description = description;
            UnitPrice = unitPrice;

            CreatedDate = DateTime.UtcNow;
        }

        public Product(string reference, string? description, double unitPrice)
        {
            Validator.New()
                .When(string.IsNullOrWhiteSpace(reference), "A referência do produto é inválida.")
                .When(unitPrice < 0, "O preço unitário do produto é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Reference = reference;
            Description = description;
            UnitPrice = unitPrice;

            CreatedDate = DateTime.UtcNow;
        }

        public void Update(string reference, string? description, double unitPrice)
        {
            Validator.New()
                .When(string.IsNullOrWhiteSpace(reference), "A referência do produto é inválida.")
                .When(unitPrice < 0, "O preço unitário do produto é inválido.")
                .TriggerBadRequestExceptionIfExist();

            Reference = reference;
            Description = description;
            UnitPrice = unitPrice;
        }
    }
}
