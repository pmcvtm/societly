using StructureMap;

namespace Societly.Tests.Infrastructure
{
    public class TestIoC
    {
        public static IContainer BuildCompositionRoot()
        {
            return new Container(c =>
            {
                c.AddRegistry<CoreRegistry>();
                c.AddRegistry<TestRegistry>();
            });
        }
    }
}
