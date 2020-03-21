using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Digoel.Models
{
    //This model applies the Hash that was generated in in the 'ShaHashGet' model
    public class ShaHashApply : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return ShaHashGet.GetHash(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(providedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}