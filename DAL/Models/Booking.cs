using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [Required]
        public DateTime EventDate { get; set; }

        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public Booking() { 
            Seats = new List<Seat>();
        }

    }
}
