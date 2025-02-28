using Domain.Entities;

namespace CommonTestUtilities.Entities
{
    public static class UserBuild
    {
        public static User Build()
        {
            return new User("test",
                "test@example.com",
                "$2a$11$YdN9j8/BO6goTAQGsVXERO4ZBHz32EFdwLwx60sR/JrQPBZFbWMuW"
            );
        }
    }
}
