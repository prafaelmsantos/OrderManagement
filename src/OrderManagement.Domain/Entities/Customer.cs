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
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

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
            Id = id;
            FullName = fullName;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }

        public Customer(
            string fullName,
            string taxIdentificationNumber,
            string contact,
            string address,
            string postalCode,
            string city)
        {
            FullName = fullName;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }

        public void Update(
            string fullName,
            string taxIdentificationNumber,
            string contact,
            string address,
            string postalCode,
            string city)
        {
            FullName = fullName;
            TaxIdentificationNumber = taxIdentificationNumber;
            Contact = contact;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
}
