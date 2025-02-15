namespace Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> Exists(string email);
    }
}
