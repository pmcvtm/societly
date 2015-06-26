using NPoco.FluentMappings;
using Societly.Domain;

namespace Societly.Data.Mappings
{
    public class PlaceMap : Map<Place>
    {
        public PlaceMap()
        {
            TableName("Places");
            PrimaryKey(x => x.Id, autoIncrement: false);

            Columns(x =>
            {
                x.Column(p => p.Residents).Result();
                x.Column(p => p.Resources).Result();
            });
        }
    }
}
