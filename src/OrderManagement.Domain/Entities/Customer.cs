namespace OrderManagement.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; private set; } = null!;
        public string? StoreName { get; private set; }
        public string? PaymentMethod { get; private set; }
        public string? TaxIdentificationNumber { get; private set; }
        public string? Contact { get; private set; }
        public string? Address { get; private set; }
        public string? PostalCode { get; private set; }
        public string? City { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public virtual ICollection<Order> Orders { get; private set; } = [];

        protected Customer() { }

        public Customer(
            string fullName,
            string? storeName,
            string? paymentMethod,
            string? taxIdentificationNumber,
            string? contact,
            string? address,
            string? postalCode,
            string? city)
        {
            Validator.New()
                .When(string.IsNullOrWhiteSpace(fullName), "O nome completo do cliente é inválido.")
                .TriggerBadRequestExceptionIfExist();

            FullName = fullName;
            StoreName = storeName;
            PaymentMethod = paymentMethod;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;

            CreatedDate = DateTime.UtcNow;
        }

        public void Update(
            string fullName,
            string? storeName,
            string? paymentMethod,
            string? taxIdentificationNumber,
            string? contact,
            string? address,
            string? postalCode,
            string? city)
        {
            Validator.New()
                .When(string.IsNullOrWhiteSpace(fullName), "O nome do cliente é inválido.")
                .TriggerBadRequestExceptionIfExist();

            FullName = fullName;
            StoreName = storeName;
            PaymentMethod = paymentMethod;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
}
