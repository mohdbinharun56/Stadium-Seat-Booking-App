﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Uname {  get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }


    }
}
