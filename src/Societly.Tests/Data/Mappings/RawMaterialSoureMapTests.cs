using Ploeh.AutoFixture;
using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public class RawMaterialSoureMapTests
    {
        private readonly RawMaterialSource _source;

        public RawMaterialSoureMapTests(IntegratedTestFixture fixture)
        {
            var place = fixture.Build<Place>();
            var material = fixture.Build<RawMaterial>();

            var source = new Fixture().Build<RawMaterialSource>()
                .WithAutoProperties()
                .With(x => x.Material, material)
                .Create();

            place.AddResource(source);
            fixture.Save(place); fixture.Save(material); fixture.Save(source);

            _source = fixture.Load<RawMaterialSource>(source.Id);
        }

        public void ShouldSaveRawMaterialSource()
        {
            _source.ShouldNotBe(null);
        }
    }
}
