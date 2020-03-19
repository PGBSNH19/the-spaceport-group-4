using System;

namespace SpacePort
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string ShipSize { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public DateTime TimeOfDepature { get; set; }
    }
}