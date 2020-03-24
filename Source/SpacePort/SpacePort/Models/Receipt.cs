using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpacePort.Models
{
    public class Receipt
    {
        public int ID { get; set; }
        public int TotalPrice { get; set; }
        public int Duration { get; set; }
        public int TicketID { get; set; }
        public Ticket Ticket { get; set; }
    }
}
