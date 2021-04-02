using LACE.Core.Abstractions.Model;

namespace LACE.Adapters.RaspberryPi.Facts
{
    public class Fact<TFact> : IFact
    {
        public TFact Observation { get; init; }
    }
}
