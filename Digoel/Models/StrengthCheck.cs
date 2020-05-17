using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Digoel.Models
{
    public class StrengthCheck
    {
        [Required]
        [Display(Name = "password_strength")]
        public string password_strength { get; set; }
        public string Leaked { get; set; }
    }
}