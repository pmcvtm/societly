using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Dsl;

namespace Societly.Tests
{
    public class Builder
    {
        private readonly Fixture _fixture;

        public Builder()
        {
            _fixture = new Fixture();
            new IntegratedTestCustomization().Customize(_fixture);
        }

        public T Build<T>() => _fixture.Create<T>();

        public ICustomizationComposer<T> BuildWithOptions<T>()
        {
            return _fixture.Build<T>();
        }
    }
}
