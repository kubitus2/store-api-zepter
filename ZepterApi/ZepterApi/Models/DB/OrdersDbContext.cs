using Microsoft.EntityFrameworkCore;

namespace ZepterApi.Models.DB;

public class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Store> Stores { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
