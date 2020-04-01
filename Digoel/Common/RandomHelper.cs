using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Digoel.Common
{
    public static class RandomHelper
    {
        private static int seedCounter = new Random().Next();

        [ThreadStatic]
        private static Random rng;

        internal static Random Instance
        {
            get
            {
                if (rng == null)
                {
                    int seed = Interlocked.Increment(ref seedCounter);
                    rng = new Random(seed);
                }
                return rng;
            }
        }
    }
}