using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public class PlaceMapTests
    {
        private readonly Place _place;

        public PlaceMapTests(Place place, IntegratedTestFixture fixture)
        {
            fixture.Save(place);
            _place = fixture.Load<Place>(place.Id);
        }

        public void ShouldSavePlace()
        {
            _place.ShouldNotBe(null);
        }
    }
}
