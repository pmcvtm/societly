using NPoco;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace Societly.Data
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IDatabase>()
                .HybridHttpOrThreadLocalScoped()
                .Use(DbFactory.Create());
        }
    }
}
