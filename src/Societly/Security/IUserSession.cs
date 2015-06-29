using System;

namespace Societly.Security
{
    public interface IUserSession
    {
        Guid UserId { get; }
        string Email { get; }
        string UserName { get; }
    }
}
