using NPoco.FluentMappings;
using Societly.Domain;

namespace Societly.Data.Mappings
{
    public class RawMaterialSourceMap : Map<RawMaterialSource>
    {
        public RawMaterialSourceMap()
        {
            TableName("RawMaterialSources");
            PrimaryKey(x => x.Id, autoIncrement: false);

            Columns(x =>
            {
                x.Column(s => s.LocationId).WithName("PlaceId");

                x.Column(s => s.Material).Result();
                x.Column(s => s.Location).Result();
            });
        }
    }
}
