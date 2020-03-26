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
        [StringLength(25, ErrorMessage = "Text length should be shorter than 15 Characters")]
        [Required]
        public string PersonName { get; set; }
        [StringLength(25, ErrorMessage = "Text length should be shorter than 15 Characters")]
        [Required]
        public string ShipName { get; set; }
        public DateTime DateTimeOfArrival { get; set; }
        public DateTime DateTimeOfDepature { get; set; }
        public Receipt Receipt { get; set; }
    }
}
