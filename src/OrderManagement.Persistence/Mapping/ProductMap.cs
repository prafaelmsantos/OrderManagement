namespace OrderManagement.Persistence.Mapping
{
    public partial class ProductMap : BaseEntityMap<Product>
    {
        public override void Map(EntityTypeBuilder<Product> entity)
        {
            base.Map(entity);

            entity.ToTable("products");

            entity.Property(x => x.Reference)
                .HasColumnName("reference")
                .IsRequired();

            entity.Property(x => x.Description)
                .HasColumnName("description");

            entity.Property(x => x.UnitPrice)
                .HasColumnName("unit_price")
                .IsRequired();

            entity.Property(x => x.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired();

            entity.HasMany(p => p.ProductsOrders)
                .WithOne(pto => pto.Product)
                .HasForeignKey(pto => pto.ProductId);
        }
    }
}
