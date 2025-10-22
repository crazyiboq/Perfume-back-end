using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();

    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public DbSet<User> users => Set<User>();



}
