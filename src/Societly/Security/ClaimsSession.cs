using System;
using System.Security;
using System.Security.Claims;

namespace Societly.Security
{
    public class ClaimsSession : IUserSession
    {
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }

        public ClaimsSession(ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new SecurityException("Attempt to access user session with no current user signed in.");

            try
            {
                UserId = Guid.Parse(principal.FindFirst(ClaimTypes.PrimarySid).Value);
                UserName = principal.FindFirst(ClaimTypes.Name).Value;
                Email = principal.FindFirst(ClaimTypes.Email).Value;
            }
            catch (NullReferenceException exception)
            {
                throw new SecurityException("Attempt to access user session with improperly set claims", exception);
            }
        }
    }
}
