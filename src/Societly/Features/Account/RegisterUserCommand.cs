using MediatR;
using NPoco;
using Societly.Domain;

namespace Societly.Features.Account
{
    public class RegisterUserCommand : IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, LoginResult>
    {
        private readonly IDatabase _database;

        public RegisterUserHandler(IDatabase database)
        {
            _database = database;
        }

        public LoginResult Handle(RegisterUserCommand message)
        {
            var hashedPassword = EncrypterDecrypterService.CreateHash(message.Password);

            var user = new GameUser
            {
                Email = message.Email,
                UserName = message.UserName,

                Password = hashedPassword.Hash,
                PasswordSalt = hashedPassword.Salt,
            };

            _database.Save<GameUser>(user);

            return new LoginResult(user);
        }
    }
}
