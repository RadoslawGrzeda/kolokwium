using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Properties.Models;

[Table("Ticket_Concert")]
public class TicketConcert
{
    [Key]
    public int TicketConcertId { get; set; }
    public int TicketId { get; set; }
    public int ConcertId { get; set; }
    public int Price { get; set; }
    
    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; }
    [ForeignKey(nameof(ConcertId))]
    public Concert Concert { get; set; }
    
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
}