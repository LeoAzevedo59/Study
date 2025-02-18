using Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public static class UnitOfWorkBuilder
    {
        public static IUnityOfWork Build()
        {
            Mock<IUnityOfWork> mock = new();
            return mock.Object;
        }
    }
}
