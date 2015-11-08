using Ploeh.AutoFixture;
using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public class SocialiteMapTests
    {
        private readonly Socialite _socialite;

        public SocialiteMapTests(GameUser user, IntegratedTestFixture fixture)
        {
            fixture.Save(user);

            var socialite = new Fixture().Build<Socialite>()
                .WithAutoProperties()
                .With(x => x.User, user)
                .Create();

            fixture.Save(socialite);
            _socialite = fixture.Load<Socialite>(socialite.Id);
        }

        public void ShouldSaveSocialite()
        {
            _socialite.ShouldNotBe(null);
        }
    }
}
