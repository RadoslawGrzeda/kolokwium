using kolokwium.Properties.Data;
using kolokwium.Properties.DTOs;
using kolokwium.Properties.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Properties.Services;


    public class CustomerService : ICustomerService
{
    private readonly Database _context;

    public CustomerService(Database context)
    {
        _context = context;
    }

    public async Task<bool> AddCustomerWithTicketsAsync(NewCustomerDto dto)
    {
        var existingCustomer = await _context.customers.FirstOrDefaultAsync(c =>
            c.FirstName == dto.FirstName &&
            c.LastName == dto.LastName &&
            c.PhoneNumber == dto.PhoneNumber);

        if (existingCustomer != null)
            return false;

        var concertGroups = dto.Tickets.GroupBy(t => t.ConcertId);
        foreach (var group in concertGroups)
        {
            if (group.Count() > 5)
                throw new InvalidOperationException("Nie można kupić więcej niż 5 biletów na jeden koncert.");
        }

        var customer = new Customer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber
        };

        _context.customers.Add(customer);
        await _context.SaveChangesAsync();

        foreach (var ticketDto in dto.Tickets)
        {
            var ticket = new Ticket
            {
                SerialNumber = ticketDto.SerialNumber,
                SeatNumber = ticketDto.SeatNumber
            };

            _context.tickets.Add(ticket);
            await _context.SaveChangesAsync();

            var ticketConcert = new TicketConcert
            {
                TicketId = ticket.TicketId,
                ConcertId = ticketDto.ConcertId,
                Price = ticketDto.Price
            };

            _context.ticketConcerts.Add(ticketConcert);
            await _context.SaveChangesAsync();

            var purchased = new PurchasedTicket
            {
                TicketConcertId = ticketConcert.TicketConcertId,
                CustomerId = customer.CustomerId,
                PurchaseDate = DateTime.UtcNow
            };

            _context.purchasedTickets.Add(purchased);
        }

        await _context.SaveChangesAsync();
        return true;
    }
}
