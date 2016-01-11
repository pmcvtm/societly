using System;
using System.Configuration;
using Ploeh.AutoFixture.Dsl;
using Respawn;
using Societly.Data;
using Societly.Domain;
using Societly.Tests.Infrastructure;
using StructureMap;

namespace Societly.Tests
{
    public class IntegratedTestFixture
    {
        private readonly Lazy<Builder> _builder = new Lazy<Builder>(() => new Builder());
        private static readonly IContainer Root = TestIoC.BuildCompositionRoot();
        private static Checkpoint Checkpoint = new Checkpoint
        {
        };

        public IntegratedTestFixture()
        {
            Container = Root.CreateChildContainer();
            Checkpoint.Reset(ConfigurationManager.ConnectionStrings["Societly"].ConnectionString);
        }

        public IContainer Container { get; private set; }

        public void Save<TEntity>(params TEntity[] entities) where TEntity : Entity
        {
            var database = DbFactory.Create();
            foreach (var entity in entities)
                database.Save<TEntity>(entity);
        }

        public TEntity Load<TEntity>(Guid id) where TEntity : Entity
        {
            var database = DbFactory.Create();
            return database.SingleOrDefaultById<TEntity>(id);
        }

        public T Build<T>() { return _builder.Value.Build<T>(); }
        public ICustomizationComposer<T> BuildWithOptions<T>() { return _builder.Value.BuildWithOptions<T>(); }
    }
}
