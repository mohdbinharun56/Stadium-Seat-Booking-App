using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        [Required]
        public int TicketPrice { get; set; }


        public virtual Booking Booking { get; set; }
    }
}
