using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public class SocieliteMapTests
    {
        private readonly Socielite _socielite;

        public SocieliteMapTests(Socielite socielite, IntegratedTestFixture fixture)
        {
            fixture.Save(socielite);

            _socielite = fixture.Load<Socielite>(socielite.Id);
        }

        public void ShouldSaveSocialite()
        {
            _socielite.ShouldNotBe(null);
        }
    }
}
