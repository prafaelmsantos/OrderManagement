namespace OrderManagement.Persistence.Mapping
{
    public partial class OrderMap : BaseEntityMap<Order>
    {
        public override void Map(EntityTypeBuilder<Order> entity)
        {
            base.Map(entity);

            entity.ToTable("orders");

            entity.Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();

            entity.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            entity.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            entity.HasMany(x => x.ProductsOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
