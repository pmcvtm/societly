using NPoco.FluentMappings;
using Societly.Domain;

namespace Societly.Data.Mappings
{
    public class RawMaterialMap : Map<RawMaterial>
    {
        public RawMaterialMap()
        {
            TableName("RawMaterials");
            PrimaryKey(x => x.Id, autoIncrement: false);
        }
    }
}
