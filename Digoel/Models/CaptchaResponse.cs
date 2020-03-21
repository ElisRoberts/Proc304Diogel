using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Digoel.Models
{
    //Handles captcha response depending on if the captcha is valid or not 
    public class CaptchaResponse
    {
        [JsonProperty("success")]

        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public List<string> ErrorMessage { get; set; }
    }
}