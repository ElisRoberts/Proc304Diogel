using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Digoel.Models
{
    public class PasswordLeaked
    {
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}