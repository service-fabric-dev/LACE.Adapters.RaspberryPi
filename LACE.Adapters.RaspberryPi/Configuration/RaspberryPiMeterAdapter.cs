using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LACE.Core.Abstractions;

namespace LACE.Adapters.RaspberryPi.Configuration
{
    public class RaspberryPiMeterAdapter : IMeterAdapter
    {
        public RaspberryPiMeterAdapter()
        {

        }

        public Task<IFact> ReadAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
 