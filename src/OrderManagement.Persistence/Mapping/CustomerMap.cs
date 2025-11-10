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

            entity.Property(x => x.TaxIdentificationNumber)
                .HasColumnName("tax_identification_number")
                .IsRequired();

            entity.Property(x => x.Contact)
                .HasColumnName("contact")
                .IsRequired();

            entity.Property(x => x.Address)
                .HasColumnName("address")
                .IsRequired();

            entity.Property(x => x.PostalCode)
                .HasColumnName("postal_code")
                .IsRequired();

            entity.Property(x => x.City)
                .HasColumnName("city")
                .IsRequired();

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
