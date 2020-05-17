using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digoel.Common
{//This class will generate a pureRandom password
    public static  class PureRandom
    {
        static string Lower = "abcdefghijklmnopqrstuvwxyz";
        static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string Digits = "0123456789";
        static string Symbols = "!\"#$%&'()*+,-./:;<=>?@[]^_{|}~";
        static readonly string[] Full = { Lower, Upper, Digits, Symbols, Lower + Upper + Digits + Symbols };

        const string Similar = "Il1O05S2Z";
        static readonly string[] Excluded = Full.Select(x => new string(x.Except(Similar).ToArray())).ToArray();

        static Random _rng = new Random();
        static string[] _symbolSet = Full;


        public static string GeneratePass(int length)
        {
            var minLength = _symbolSet.Length - 1;
            if (length < minLength)
                throw new Exception("password length must be " + minLength + " or greater");

            int[] usesRemaining = Enumerable.Repeat(1, _symbolSet.Length).ToArray();
            usesRemaining[minLength] = length - minLength;
            var password = new char[length];
            for (int ii = 0; ii < length; ii++)
            {
                int set = _rng.Next(0, _symbolSet.Length);
                if (usesRemaining[set] > 0)
                {
                    usesRemaining[set]--;
                    password[ii] = _symbolSet[set][_rng.Next(0, _symbolSet[set].Length)];
                }
                else ii--;
            }
            return new string(password);
        }
    }


}