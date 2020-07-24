using LACE.Core.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LACE.Adapters.RaspberryPi.Facts
{
    public class BinaryGpioPinFact : GpioPinFact
    {
        public bool Measurement { get; set; }
    }
}
