using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Properties.Models;
[Table("Purchased_Ticket")]
[PrimaryKey(nameof(TicketConcertId),nameof(CustomerId))]
public class PurchasedTicket
{
    public int TicketConcertId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PurchaseDate{ get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }
    [ForeignKey(nameof(TicketConcertId))]
    public TicketConcert TicketConcert { get; set; }
}