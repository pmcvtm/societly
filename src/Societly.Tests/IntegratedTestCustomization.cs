using Ploeh.AutoFixture;
using Societly.Tests.Infrastructure;

namespace Societly.Tests
{
    public class IntegratedTestCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var contextFixture = new IntegratedTestFixture();

            fixture.Register(() => contextFixture);

            fixture.Customizations.Add(new ContainerBuilder(contextFixture.Container));
        }
    }
}
