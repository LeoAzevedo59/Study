// ReSharper disable All

using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = RoleType.ADMIN;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Role { get; init; }
    }
}
