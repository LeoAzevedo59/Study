using Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Security.Cryptography
{
    public class PasswordEncryptBuilder
    {
        private readonly Mock<IPasswordEncrypt> _passwordEncryptMock = new();

        public IPasswordEncrypt Build()
        {
            _passwordEncryptMock.Setup(passwordEncrypt =>
                passwordEncrypt.Encrypt(It.IsAny<string>())).Returns(
                "$2a$11$t5MG1FX1NfjBkR/3JMpfWeGop5elh18yVTSXskZuOdfKqXPMfBc9i");

            return _passwordEncryptMock.Object;
        }

        public PasswordEncryptBuilder Verify(string? password = null)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                _passwordEncryptMock.Setup(encrypt =>
                        encrypt.Verify(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(false);
                return this;
            }

            _passwordEncryptMock.Setup(encrypt =>
                encrypt.Verify(password, It.IsAny<string>())).Returns(true);

            return this;
        }
    }
}
