namespace kolokwium.Properties.DTOs;

public class CustomerPurchaseDto
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<PurchasedTicketDto> PurchasedTicket { get; set; }


    public class PurchasedTicketDto
    {
        public int TicketConcertId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public TicketDto TicketDto { get; set; }

    }

    public class TicketDto
    {
        public int TicketId { get; set; }
        public string SerialNumber { get; set; }

        public int SeatNumber { get; set; }
        // public ICollection<TicketConcert> TicketConcert { get; set; }
    }
}
//     public class TicketCocertDto
//     public class TicketConcert
//     {
//         public int TicketConcertId { get; set; }
//         public int TicketId { get; set; }
//         public int ConcertId { get; set; }
//         public int Price { get; set; }
//     
//         public Concert ConcertDto { get; set; }
//     
//     }
//     
//     }
//
//     public class Concert
//     {
//         public int ConcertId { get; set; }
//         public string Name { get; set; }
//         public DateTime Date { get; set; }
//         public int AvailableTicket { get; set; }
//         public ICollection<TicketConcert> TicketConcert { get; set; }
//     }
//
//  
// }