using Domain.Entities;
using Domain.Repositories.User;
using Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    internal class UserRepository(ApiDbContext dbContext) :
        IUserWriteOnlyRepository,
        IUserReadOnlyRepository
    {
        public async Task<bool> Exists(string email)
        {
            return await dbContext.Users.AnyAsync(user =>
                user.Email.Equals(email));
        }

        public async Task Add(User user)
        {
            await dbContext.Users.AddAsync(user);
        }
    }
}
