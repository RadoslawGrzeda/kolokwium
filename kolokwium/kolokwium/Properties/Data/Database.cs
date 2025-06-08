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
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "Anna", LastName = "Kowalska", PhoneNumber = "12349" },
            new Customer { CustomerId = 2, FirstName = "Jan", LastName = "Nowak", PhoneNumber = "9871" }
        );

        modelBuilder.Entity<Concert>().HasData(
            new Concert { ConcertId = 1, Name = "Jaz", Date =  DateTime.SpecifyKind(new DateTime(2025, 6, 1, 10, 0, 0), DateTimeKind.Utc)},
            new Concert { ConcertId = 2, Name = "Rock",  Date=DateTime.SpecifyKind(new DateTime(2025, 6, 1, 10, 0, 0), DateTimeKind.Utc)}
        );

        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { TicketId = 1, SerialNumber = "TK1", SeatNumber = 101 },
            new Ticket { TicketId = 2, SerialNumber = "TK1", SeatNumber = 102 },
            new Ticket { TicketId = 3, SerialNumber = "TK2", SeatNumber = 201 }
        );

        modelBuilder.Entity<TicketConcert>().HasData(
            new TicketConcert { TicketConcertId = 1, TicketId = 1, ConcertId = 1, Price = 45 },
            new TicketConcert { TicketConcertId = 2, TicketId = 2, ConcertId = 1, Price = 45 },
            new TicketConcert { TicketConcertId = 3, TicketId = 3, ConcertId = 2, Price = 60 }
        );

        modelBuilder.Entity<PurchasedTicket>().HasData(
            new PurchasedTicket { TicketConcertId = 1, CustomerId = 1, PurchaseDate = DateTime.SpecifyKind(new DateTime(2025, 6, 1, 10, 0, 0), DateTimeKind.Utc)
            },
            new PurchasedTicket { TicketConcertId = 2, CustomerId = 1,  PurchaseDate = DateTime.SpecifyKind(new DateTime(2025, 6, 1, 10, 0, 0), DateTimeKind.Utc)
            },
            new PurchasedTicket { TicketConcertId = 3, CustomerId = 2, PurchaseDate = DateTime.SpecifyKind(new DateTime(2025, 6, 1, 10, 0, 0), DateTimeKind.Utc)
            }
        );

        
        

    }
}