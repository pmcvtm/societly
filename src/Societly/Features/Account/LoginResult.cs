using System.Security.Claims;
using Societly.Domain;

namespace Societly.Features.Account
{
    public class LoginResult
    {
        public LoginResult(GameUser user)
        {
            Identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                },
                CookieName
            );
        }

        public const string CookieName = "Societly";
        public ClaimsIdentity Identity { get; set; }
    }
}
