using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public int Balance { get; set; }
        public int UserId { get; set; }

        /*public int UserName { get; set; }*/
    }
}
