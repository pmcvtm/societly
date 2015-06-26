using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public class SocialiteMapTests
    {
        private readonly Socialite _socialite;

        public SocialiteMapTests(Socialite socialite, IntegratedTestFixture fixture)
        {
            fixture.Save(socialite);

            _socialite = fixture.Load<Socialite>(socialite.Id);
        }

        public void ShouldSaveSocialite()
        {
            _socialite.ShouldNotBe(null);
        }
    }
}
