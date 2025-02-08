using Domain.Repositories;

namespace Infra.DataAccess;

internal class UnityOfWork(ApiDbContext dbContext) : IUnityOfWork
{
    public void Commit() => dbContext.SaveChanges();
}