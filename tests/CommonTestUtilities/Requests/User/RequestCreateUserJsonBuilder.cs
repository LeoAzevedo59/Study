using Communication.Requests.Users;

namespace CommonTestUtilities.Requests.User
{
    public abstract class RequestCreateUserJsonBuilder
    {
        public static RequestCreateUserJson Build()
        {
            RequestCreateUserJson request =
                new("Leo",
                    "leo@exemple.com",
                    "password"
                );

            return request;
        }

        public static RequestCreateUserJson Build(string name)
        {
            RequestCreateUserJson request =
                new(name,
                    "leo@exemple.com",
                    "password"
                );

            return request;
        }

        public static RequestCreateUserJson BuildWithEmail(string email)
        {
            RequestCreateUserJson request =
                new("Leo",
                    email,
                    "password"
                );

            return request;
        }
    }
}
