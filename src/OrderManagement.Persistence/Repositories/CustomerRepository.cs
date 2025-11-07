namespace OrderManagement.Persistence.Repositories
{
    public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }
    }
}
