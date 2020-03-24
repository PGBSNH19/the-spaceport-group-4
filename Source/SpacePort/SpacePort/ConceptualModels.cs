using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int Person { get; set; }
        public string ShipSize { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public DateTime TimeOfDepature { get; set; }

        public int ParkedTimeInMinutes() 
        {
            var parked = TimeOfDepature - TimeOfArrival;
            return (int)parked.TotalMinutes;
        }
    }

    public class Receipt
    {
        public int TicketID { get; set; }
        public int ReceiptID { get; set; }
        public int TotalPrice { get; set; }
        public int Duration { get; set; }
    }


}
