using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Societly.Features.Account;

namespace UI
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = LoginResult.CookieName,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
