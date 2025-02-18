using Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories.User
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository>
            _userReadOnlyRepositoryMock = new();

        public IUserReadOnlyRepository Build()
        {
            return _userReadOnlyRepositoryMock.Object;
        }

        public void ExistUserWithEmail(string email)
        {
            _userReadOnlyRepositoryMock.Setup(userReadOnly =>
                userReadOnly.Exists(email)).ReturnsAsync(true);
        }
    }
}
