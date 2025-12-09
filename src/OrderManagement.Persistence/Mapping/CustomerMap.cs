namespace OrderManagement.Persistence.Mapping
{
    public partial class CustomerMap : BaseEntityMap<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> entity)
        {
            base.Map(entity);

            entity.ToTable("customers");

            entity.Property(x => x.FullName)
                .HasColumnName("full_name")
                .IsRequired();

            entity.Property(x => x.StoreName)
                .HasColumnName("store_name");

            entity.Property(x => x.PaymentMethod)
                .HasColumnName("payment_method");

            entity.Property(x => x.TaxIdentificationNumber)
                .HasColumnName("tax_identification_number");

            entity.Property(x => x.Contact)
                .HasColumnName("contact");

            entity.Property(x => x.Address)
                .HasColumnName("address");

            entity.Property(x => x.PostalCode)
                .HasColumnName("postal_code");

            entity.Property(x => x.City)
                .HasColumnName("city");

            entity.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired();

            entity.HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
