using NPoco.FluentMappings;
using Societly.Domain;

namespace Societly.Data.Mappings
{
    public class GameUserMap : Map<GameUser>
    {
        public GameUserMap()
        {
            TableName("GameUsers");
            PrimaryKey(x => x.Id, autoIncrement: false);
        }
    }
}
