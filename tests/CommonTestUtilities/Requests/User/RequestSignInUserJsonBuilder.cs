using Communication.Requests.Users;

namespace CommonTestUtilities.Requests.User
{
    public abstract class RequestSignInUserJsonBuilder
    {
        public static RequestSigninUserJson Build()
        {
            RequestSigninUserJson request = new("test@example.com",
                "test123"
            );

            return request;
        }

        public static RequestSigninUserJson BuildWithPassword(string password)
        {
            RequestSigninUserJson request = new("test@example.com",
                password
            );

            return request;
        }

        public static RequestSigninUserJson BuildWithEmail(string email)
        {
            RequestSigninUserJson request = new(email,
                "test123"
            );

            return request;
        }
    }
}
