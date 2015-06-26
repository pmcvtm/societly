using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public class GameUserMapTests
    {
        private readonly GameUser _user;

        public GameUserMapTests(GameUser user, IntegratedTestFixture fixture)
        {
            fixture.Save(user);
            _user = fixture.Load<GameUser>(user.Id);
        }

        public void ShouldSaveGameUser()
        {
            _user.ShouldNotBe(null);
        }
    }
}
