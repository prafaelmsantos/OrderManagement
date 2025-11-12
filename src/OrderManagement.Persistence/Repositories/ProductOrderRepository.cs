namespace OrderManagement.Persistence.Repositories
{
    public sealed class ProductOrderRepository : Repository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(AppDbContext context) : base(context) { }
    }
}
