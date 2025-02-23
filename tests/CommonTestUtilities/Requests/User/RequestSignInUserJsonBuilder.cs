using Communication.Requests.Users;

namespace CommonTestUtilities.Requests.User
{
    public abstract class RequestSignInUserJsonBuilder
    {
        public static RequestSigninUserJson Build()
        {
            RequestSigninUserJson request = new()
            {
                Email = "test@example.com",
                Password = "test123"
            };

            return request;
        }
    }
}
