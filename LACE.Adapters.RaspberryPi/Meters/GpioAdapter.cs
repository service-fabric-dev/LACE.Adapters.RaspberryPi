using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LACE.Core.Abstractions.Model;

namespace LACE.Adapters.RaspberryPi.Meters
{
    public class GpioAdapter : IMeterAdapter
    {
        public Task<IFact> ReadAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
