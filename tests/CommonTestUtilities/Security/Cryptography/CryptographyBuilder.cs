using Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Security.Cryptography
{
    public static class PasswordEncryptBuilder
    {
        public static IPasswordEncrypt Build()
        {
            Mock<IPasswordEncrypt> mock = new();

            mock.Setup(passwordEncrypt =>
                passwordEncrypt.Encrypt(It.IsAny<string>())).Returns(
                "$2a$11$t5MG1FX1NfjBkR/3JMpfWeGop5elh18yVTSXskZuOdfKqXPMfBc9i");

            return mock.Object;
        }
    }
}
