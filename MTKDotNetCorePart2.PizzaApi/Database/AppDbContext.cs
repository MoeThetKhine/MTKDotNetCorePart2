namespace MTKDotNetCorePart2.PizzaApi.Database;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
     : base(options)
    {
    }

    #region DbSet

    public DbSet<PizzaModel> Pizzas { get; set; }
    public DbSet<PizzaExtraModel>PizzaExtras { get; set; }
    public DbSet<PizzaOrderDetailModel>PizzaOrderDetails { get; set; }
    public DbSet<PizzaOrderModel>PizzaOrders { get; set; }

    #endregion
}
