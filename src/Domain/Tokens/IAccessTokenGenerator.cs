using Domain.Entities;

namespace Domain.Tokens
{
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
