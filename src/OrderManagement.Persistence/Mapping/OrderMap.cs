namespace OrderManagement.Persistence.Mapping
{
    public partial class OrderMap : BaseEntityMap<Order>
    {
        public override void Map(EntityTypeBuilder<Order> entity)
        {
            base.Map(entity);

            entity.ToTable("orders");

            entity.Property(x => x.Observations)
                .HasColumnName("observations");

            entity.Property(x => x.PaymentMethod)
                .HasColumnName("payment_method");

            entity.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired();

            entity.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            entity.HasMany(x => x.ProductsOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
