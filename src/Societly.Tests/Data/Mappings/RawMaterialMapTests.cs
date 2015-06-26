using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public class RawMaterialMapTests
    {
        private readonly RawMaterial _rawMaterial;

        public RawMaterialMapTests(RawMaterial material, IntegratedTestFixture fixture)
        {
            fixture.Save(material);
            _rawMaterial = fixture.Load<RawMaterial>(material.Id);
        }

        public void ShouldSaveRawMaterial()
        {
            _rawMaterial.ShouldNotBe(null);
        }
    }
}
