using Domain.Repositories;

namespace Infra.DataAccess;

internal class UnityOfWork(ApiDbContext dbContext) : IUnityOfWork
{
    public async Task Commit() => await dbContext.SaveChangesAsync();
}