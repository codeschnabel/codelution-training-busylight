using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode.Contracts
{
    public class Symbol
    {
        internal Symbol(int durationInMilliseconds, int frequency, int red, int green, int blue)
        {
            DurationInMilliseconds = durationInMilliseconds;
            Frequency = frequency;
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int DurationInMilliseconds { get; private set; }

        public int Frequency { get; private set; }
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }
    }
}
