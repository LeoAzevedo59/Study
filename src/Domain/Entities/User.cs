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

        private User() { }

        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
