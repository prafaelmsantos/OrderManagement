namespace OrderManagement.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new CustomerMap());
            modelBuilder.AddConfiguration(new ProductMap());
            modelBuilder.AddConfiguration(new OrderMap());
            modelBuilder.AddConfiguration(new ProductOrderMap());

            modelBuilder.AddInitialSeed();
        }
    }
}
