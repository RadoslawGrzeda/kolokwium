using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Properties.Models;

public class Concert
{
    [Key]
    public int ConcertId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int AvailableTicket { get; set; }
    public ICollection<TicketConcert> TicketConcert { get; set; }
}