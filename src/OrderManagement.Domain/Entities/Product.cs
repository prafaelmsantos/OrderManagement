namespace OrderManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Reference { get; private set; } = null!;
        public string? Description { get; private set; }
        public double UnitPrice { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        public virtual ICollection<ProductOrder> ProductsOrders { get; private set; } = [];

        protected Product() { }

        public Product(long id, string reference, string? description, double unitPrice)
        {
            Id = id;
            Reference = reference;
            Description = description;
            UnitPrice = unitPrice;
        }

        public Product(string reference, string? description, double price)
        {
            Reference = reference;
            Description = description;
            UnitPrice = price;
        }

        public void Update(string reference, string? description, double price)
        {
            Reference = reference;
            Description = description;
            UnitPrice = price;
        }
    }
}
