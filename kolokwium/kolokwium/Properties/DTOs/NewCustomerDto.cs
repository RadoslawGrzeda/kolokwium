namespace kolokwium.Properties.DTOs;


    public class NewCustomerDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public List<TicketRequestDto> Tickets { get; set; } = new();
    }

    public class TicketRequestDto
    {
        public string SerialNumber { get; set; } = null!;
        public int SeatNumber { get; set; }
        public int ConcertId { get; set; }
        public int Price { get; set; }
    }

