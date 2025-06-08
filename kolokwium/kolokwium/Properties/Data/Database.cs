using kolokwium.Properties.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Properties.Data;

public class Database : DbContext
{
    public DbSet<Customer> customers { get; set; }
    public DbSet<Concert> concerts { get; set; }
    public DbSet<PurchasedTicket> purchasedTickets { get; set; }
    public DbSet<Ticket> tickets { get; set; }
    public DbSet<TicketConcert> ticketConcerts { get; set; }
    
    protected Database()
    {

    }

    public Database(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
// modelBuilder.Entity<Product_Order>(a =>
        // {
        //     a.HasKey(x => new { x.ProductId, x.OrderId });
        //
        //     a.HasOne(po => po.Product)
        //         .WithMany(p => p.ProductOrders)
        //         .HasForeignKey(po => po.ProductId);
        //
        //     a.HasOne(po => po.Order)
        //         .WithMany(p => p.ProductOrders)
        //         .HasForeignKey(po => po.OrderId);
        // });
        //
        //
        // modelBuilder.Entity<Product>(a =>
        //     a.Property(x => x.Price).HasColumnType("numeric(10,2)")
        // );
 
/*modelBuilder.Entity<Client>().HasData(new List<Client>()
{
    new Client() { ID = 1, FirstName = "John", LastName = "Doe" },
    new Client() { ID = 2, FirstName = "Jane", LastName = "Doe" },
    new Client() { ID = 3, FirstName = "Julie", LastName = "Doe" },
});

modelBuilder.Entity<Status>().HasData(new List<Status>()
{
    new Status() { ID = 1, Name = "Created" },
    new Status() { ID = 2, Name = "Ongoing" },
    new Status() { ID = 3, Name = "Completed" },
});

modelBuilder.Entity<Product>().HasData(new List<Product>()
{
    new Product() { ID = 1, Name = "Apple", Price = 3.45 },
    new Product() { ID = 2, Name = "Bananas", Price = 5.55 },
    new Product() { ID = 3, Name = "Orange", Price = 12.37 },
});
}*/