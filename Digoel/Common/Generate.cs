using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digoel.Common
{
    public static class Generate
    {
        public static string Words(int wordCount, bool uppercaseFirstLetter = true, bool includePunctuation = false)
        {
            return Words(wordCount, wordCount, uppercaseFirstLetter, includePunctuation);
        }

        public static string Words(int wordCountMin, int wordCountMax, bool uppercaseFirstLetter = true, bool includePunctuation = false)
        {
            var source = string.Join(" ", Source.WordList(includePunctuation).Take(RandomHelper.Instance.Next(wordCountMin, wordCountMax)));

            if (uppercaseFirstLetter)
            {
                source = source.UppercaseFirst();
            }

            return source;
        }

    }
}