using NPoco.FluentMappings;
using Societly.Domain;

namespace Societly.Data.Mappings
{
    public class SocieliteMapping : Map<Socielite>
    {
        public SocieliteMapping()
        {
            TableName("Socialites");
            PrimaryKey(x => x.Id, autoIncrement: false);
        }
    }
}
