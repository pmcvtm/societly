using System;
using System.Linq;
using NPoco;
using NPoco.FluentMappings;

namespace Societly.Data
{
    public static class DbFactory
    {
        private static readonly Lazy<DatabaseFactory> Factory = new Lazy<DatabaseFactory>(Initialize, true);

        public static Database Create()
        {
            return Factory.Value.GetDatabase();
        }

        private static DatabaseFactory Initialize()
        {
            var mappings = typeof(DbFactory)
                .Assembly
                .GetTypes()
                .Where(type => !type.IsAbstract && typeof(IMap).IsAssignableFrom(type))
                .Select(Activator.CreateInstance)
                .Cast<IMap>()
                .ToArray();

            var mappingConfig = FluentMappingConfiguration.Configure(mappings);

            return DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() => new Database("societly"));
                x.WithFluentConfig(mappingConfig);
            });
        }
    }
}
