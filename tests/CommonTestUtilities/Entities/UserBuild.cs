using Domain.Entities;

namespace CommonTestUtilities.Entities
{
    public static class UserBuild
    {
        public static User Build()
        {
            return new User
            {
                Id = Guid.Parse("5eeeed85-93c1-4d18-b49d-09af3b930ad1"),
                Name = "test",
                Email = "test@example.com",
                Password =
                    "$2a$11$YdN9j8/BO6goTAQGsVXERO4ZBHz32EFdwLwx60sR/JrQPBZFbWMuW",
                Role = "Admin"
            };
        }
    }
}
