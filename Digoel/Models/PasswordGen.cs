﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digoel.Models
{
    public class PasswordGen
    {

        [Required]
        [Display(Name = "Generate Password")]
        public string genPassword { get; set; }
        public int length { get; set; }

}