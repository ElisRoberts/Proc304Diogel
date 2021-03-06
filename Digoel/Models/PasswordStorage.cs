﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Digoel.Models
{
    public class PasswordStorage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Name of Website / Service")]
        public string Website { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

 
        [Display(Name = "Date Added / Edited")]
        public DateTime DateSaved { get; set; }

        [StringLength(128)]
        public string UserId { set; get; } 
    }
}