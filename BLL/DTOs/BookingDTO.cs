using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookingDTO 
    {
        public int BookingId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SeatId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
    }
}
