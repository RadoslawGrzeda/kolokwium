using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Properties.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string LastName { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? PhoneNumber { get; set; }
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
    
}