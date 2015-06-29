using System.Linq;
using System.Security;
using MediatR;
using NPoco;
using Societly.Domain;

namespace Societly.Features.Account
{
    public class LoginUserCommand : IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginResult>
    {
        private readonly IDatabase _database;

        public LoginUserHandler(IDatabase database)
        {
            _database = database;
        }

        public LoginResult Handle(LoginUserCommand message)
        {
            var user = _database.Fetch<GameUser>()
                .SingleOrDefault(x => x.Email == message.Email);

            if(user == null || ! EncrypterDecrypterService.Verify(user.PasswordSalt, user.Password, message.Password))
                throw new SecurityException("Invalid login information");

            return new LoginResult(user);
        }
    }
}
