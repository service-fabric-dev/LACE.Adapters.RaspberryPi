using System.Reflection;
using LACE.Core.Content;

namespace LACE.Adapters.RaspberryPi.UnitTests
{
    public abstract class EmbeddedTest
    {
        protected static readonly EmbeddedContentLoader ContentLoader = new (Assembly.GetAssembly(typeof(EmbeddedTest)));
    }
}
