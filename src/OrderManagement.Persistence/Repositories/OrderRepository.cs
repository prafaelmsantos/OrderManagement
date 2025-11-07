namespace OrderManagement.Persistence.Repositories
{
    public sealed class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }
    }
}
