using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<OrderItem>()
    //        .HasKey(oi => new { oi.OrderId, oi.ProductId });
    //}

    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductVolume> ProductVolume => Set<ProductVolume>();
    public DbSet<ProductNotes> ProductNotes => Set<ProductNotes>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OrderShipping> OrderShippings => Set<OrderShipping>();

    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

}