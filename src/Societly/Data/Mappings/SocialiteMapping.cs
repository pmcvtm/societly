using NPoco.FluentMappings;
using Societly.Domain;

namespace Societly.Data.Mappings
{
    public class SocialiteMapping : Map<Socialite>
    {
        public SocialiteMapping()
        {
            TableName("Socialites");
            PrimaryKey(x => x.Id, autoIncrement: false);

            Columns(x =>
            {
                x.Column(s => s.UserId);
                x.Column(s => s.User).Result();
            });
        }
    }
}
