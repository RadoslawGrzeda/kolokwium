using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Properties.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string SerialNumber { get; set; }
    public int SeatNumber { get; set; }
    public ICollection<TicketConcert> TicketConcert { get; set; }
}