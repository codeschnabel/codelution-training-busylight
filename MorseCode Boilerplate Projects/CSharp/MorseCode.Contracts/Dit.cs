using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode.Contracts
{
    public class Dit : Symbol
    {
        public static int LENGTH_IN_MS = 60;

        public Dit() : base(LENGTH_IN_MS, 1000, 0, 255, 255)
        {
        }
    }
}
