using Shouldly;
using Societly.Features.Account;

namespace Societly.Tests.Features.Account
{
    public class EncrypterDecrypterServiceTests
    {
        const string Password = "password1234"; //Also my real password, don't tell anyone.
        private readonly EncrypterDecrypterService.HashResult _result;

        public EncrypterDecrypterServiceTests()
        {
            _result = EncrypterDecrypterService.CreateHash(Password);
        }

        public void ShouldHashPassword()
        {
            _result.Hash.ShouldNotBe(Password);
        }
        
        public void ShouldReturnSalt()
        {
            _result.Salt.ShouldNotBe(null);
        }

        public void ShouldVerify()
        {
            EncrypterDecrypterService.Verify(_result.Salt, _result.Hash, Password).ShouldBe(true);
        }
    }
}
