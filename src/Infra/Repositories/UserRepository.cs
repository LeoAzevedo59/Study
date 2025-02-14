using Domain.Entities;
using Domain.Repositories.User;
using Infra.DataAccess;

namespace Infra.Repositories;

internal class UserRepository(ApiDbContext dbContext) :
    IUserWriteOnlyRepository
{

    public async Task Add(User user)
    {
        await dbContext.Users.AddAsync(user);
    }
}
