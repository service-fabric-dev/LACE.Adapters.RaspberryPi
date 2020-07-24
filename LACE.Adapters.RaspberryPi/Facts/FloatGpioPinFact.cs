using LACE.Core.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LACE.Adapters.RaspberryPi.Facts
{
    public class FloatGpioPinFact : GpioPinFact
    {
        public float Measurement { get; set; }
    }
}
