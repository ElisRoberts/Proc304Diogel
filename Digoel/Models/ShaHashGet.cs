using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography; //Using inbuilt crypto

namespace Digoel.Models
{
    //This model generated the hash thats going to be used in password storage
    public class ShaHashGet
    {
        public static string GetHash(string input)
        {
            using(SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(input);
                b = sha256.ComputeHash(b);
                System.Text.StringBuilder sbuilder = new System.Text.StringBuilder();

                for (int i = 0; i < b.Length; i++)
                {
                    sbuilder.Append(b[i].ToString("x2"));
                }
                return sbuilder.ToString();
            }
        }
    }
}