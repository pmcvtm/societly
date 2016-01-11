using Shouldly;
using Societly.Domain;

namespace Societly.Tests.Data.Mappings
{
    public abstract class MappingTestBase<TEntity> where TEntity : Entity
    {
        protected readonly TEntity Loaded;

        protected MappingTestBase(IntegratedTestFixture fixture)
        {
            TEntity built = fixture.Build<TEntity>();
            fixture.Save(built);
            Loaded = fixture.Load<TEntity>(built.Id);
        }

        public void ShouldSaveEntity()
        {
            Loaded.ShouldNotBe(null);
        }
    }
}
