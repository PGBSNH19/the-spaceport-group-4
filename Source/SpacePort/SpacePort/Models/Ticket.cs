using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        [StringLength(15, ErrorMessage = "Text length should be shorter than 15 Characters")]
        public string Person { get; set; }
        [Column(TypeName = "decimal(10, 4)")]
        public decimal ShipSize { get; set; }
        public string ShipType { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public DateTime TimeOfDepature { get; set; }
        public Receipt Receipt { get; set; }
    }
}
