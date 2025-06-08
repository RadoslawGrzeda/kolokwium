using kolokwium.Properties.Data;
using kolokwium.Properties.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Properties.Services;

public abstract class GetPurchaseCustomer:IGetPurchaseCustomer
{
    private readonly Database _context;

    public GetPurchaseCustomer(Database context)
    {
        _context = context;
    }
    

public  async Task<ICollection<CustomerPurchaseDto>>GetCustomerPurchase(int customerId)
{
    var customer = await _context.customers.Select(e => e.CustomerId == customerId).FirstOrDefaultAsync();
    if (customer == null)
    {
       throw new KeyNotFoundException();
    }
    var dane = await _context.customers.Select(e=> new CustomerPurchaseDto
    {
        CustomerId = customerId,
        LastName = e.LastName,
        FirstName = e.FirstName,
        PhoneNumber = e.PhoneNumber,
        PurchasedTicket = new CustomerPurchaseDto.PurchasedTicketDto
        {
            
        }
    }

}
{
    
}
    