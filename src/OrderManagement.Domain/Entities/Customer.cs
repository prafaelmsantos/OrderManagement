namespace OrderManagement.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; private set; } = null!;
        public string TaxIdentificationNumber { get; private set; } = null!;
        public string Contact { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string PostalCode { get; private set; } = null!;
        public string City { get; private set; } = null!;
        public DateTime CreatedDate { get; private set; }

        public virtual ICollection<Order> Orders { get; private set; } = [];

        protected Customer() { }

        public Customer(
            long id,
            string fullName,
            string taxIdentificationNumber,
            string contact,
            string address,
            string postalCode,
            string city)
        {
            Validator.New()
                .When(id <= 0, "O id do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(fullName), "O nome completo do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(taxIdentificationNumber), "O número de identificação fiscal é inválido.")
                .When(string.IsNullOrWhiteSpace(contact), "O contacto do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(address), "O endereço do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(postalCode), "O código postal do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(city), "A cidade do cliente é inválida.")
                .TriggerBadRequestExceptionIfExist();

            Id = id;
            FullName = fullName;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;
            CreatedDate = DateTime.UtcNow;
        }

        public Customer(
            string fullName,
            string taxIdentificationNumber,
            string contact,
            string address,
            string postalCode,
            string city)
        {
            Validator.New()
                .When(string.IsNullOrWhiteSpace(fullName), "O nome completo do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(taxIdentificationNumber), "O número de identificação fiscal é inválido.")
                .When(string.IsNullOrWhiteSpace(contact), "O contacto do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(address), "O endereço do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(postalCode), "O código postal do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(city), "A cidade do cliente é inválida.")
                .TriggerBadRequestExceptionIfExist();

            FullName = fullName;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;

            CreatedDate = DateTime.UtcNow;
        }

        public void Update(
            string fullName,
            string taxIdentificationNumber,
            string contact,
            string address,
            string postalCode,
            string city)
        {
            Validator.New()
                .When(string.IsNullOrWhiteSpace(fullName), "O nome completo do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(taxIdentificationNumber), "O número de identificação fiscal é inválido.")
                .When(string.IsNullOrWhiteSpace(contact), "O contacto do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(address), "O endereço do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(postalCode), "O código postal do cliente é inválido.")
                .When(string.IsNullOrWhiteSpace(city), "A cidade do cliente é inválida.")
                .TriggerBadRequestExceptionIfExist();

            FullName = fullName;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
}
