using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SeatDTO
    {
        public int SeatId { get; set; }
        [Required]
        public string SeatNumber { get; set; }
        [Required]
        public string section { get; set; }
        [Required]
        public string status { get; set; }
    }
}
