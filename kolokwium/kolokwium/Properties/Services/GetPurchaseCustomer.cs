using kolokwium.Properties.Data;
using kolokwium.Properties.DTOs;
using kolokwium.Properties.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Properties.Services;

public abstract class GetPurchaseCustomer : IGetPurchaseCustomer
{
    private readonly Database _context;

    public GetPurchaseCustomer(Database context)
    {
        _context = context;
    }

        public async Task<CustomerPurchasesDto?> GetPurchasesByCustomerIdAsync(int customerId)
        {
            var customer = await _context.customers
                .Where(c => c.CustomerId == customerId)
                .Select(c => new CustomerPurchasesDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Purchases = c.PurchasedTickets.Select(pt => new PurchaseDto
                    {
                        Date = pt.PurchaseDate,
                        Price = pt.TicketConcert.Price,
                        Ticket = new TicketDto
                        {
                            Serial = pt.TicketConcert.Ticket.SerialNumber,
                            SeatNumber = pt.TicketConcert.Ticket.SeatNumber
                        },
                        Concert = new ConcertDto
                        {
                            Name = pt.TicketConcert.Concert.Name,
                            Date = pt.TicketConcert.Concert.Date
                        }
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return customer;
        }

        public Task<CustomerPurchasesDto?> GetPurchasesByCustomerIdAsync()
        {
            throw new NotImplementedException();
        }
}

    