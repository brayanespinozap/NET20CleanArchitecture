namespace NorthWind.EFCore.Repositories.DataContexts
{
    // Add-Migration InitialCreate -p NorthWind.EFCore.Repositories -s NorthWind.EFCore.Repositories -c NorthWindContext
    public class NorthWindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=bespinoza\\sqlexpress;Database=NorthWindNET20;Integrated Security=True; TrustServerCertificate=True;");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
