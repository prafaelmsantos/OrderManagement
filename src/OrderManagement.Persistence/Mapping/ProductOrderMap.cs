namespace OrderManagement.Persistence.Mapping
{
    public class ProductOrderMap : BaseEntityMap<ProductOrder>
    {
        public override void Map(EntityTypeBuilder<ProductOrder> entity)
        {
            base.Map(entity);

            entity.ToTable("product_order");

            entity.Property(x => x.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            entity.Property(x => x.OrderId)
                .HasColumnName("order_id")
                .IsRequired();

            entity.Property(x => x.Color)
                .HasColumnName("color");

            entity.Property(x => x.UnitPrice)
                .HasColumnName("unit_price")
                .IsRequired();

            entity.Property(x => x.ZeroMonths)
                .HasColumnName("zero_months")
                .IsRequired();

            entity.Property(x => x.OneMonth)
                .HasColumnName("one_month")
                .IsRequired();

            entity.Property(x => x.ThreeMonths)
                .HasColumnName("three_months")
                .IsRequired();

            entity.Property(x => x.SixMonths)
                .HasColumnName("six_months")
                .IsRequired();

            entity.Property(x => x.NineMonths)
                .HasColumnName("thirty_six_months")
                .IsRequired();

            entity.Property(x => x.TwelveMonths)
                .HasColumnName("twelve_months")
                .IsRequired();

            entity.Property(x => x.EighteenMonths)
                .HasColumnName("eighteen_months")
                .IsRequired();

            entity.Property(x => x.TwentyFourMonths)
                .HasColumnName("twenty_four_months")
                .IsRequired();

            entity.Property(x => x.OneYear)
                .HasColumnName("one_year")
                .IsRequired();

            entity.Property(x => x.TwoYears)
                .HasColumnName("two_years")
                .IsRequired();

            entity.Property(x => x.ThreeYears)
                .HasColumnName("three_years")
                .IsRequired();

            entity.Property(x => x.FourYears)
                .HasColumnName("four_years")
                .IsRequired();

            entity.Property(x => x.SixYears)
                .HasColumnName("six_years")
                .IsRequired();

            entity.Property(x => x.EightYears)
                .HasColumnName("eight_years")
                .IsRequired();

            entity.Property(x => x.TenYears)
                .HasColumnName("ten_years")
                .IsRequired();

            entity.Property(x => x.TwelveYears)
                .HasColumnName("twelve_years")
                .IsRequired();

            entity.Property(x => x.TotalQuantity)
                .HasColumnName("total_quantity")
                .IsRequired();

            entity.Property(x => x.TotalPrice)
                .HasColumnName("total_price")
                .IsRequired();
        }
    }
}
