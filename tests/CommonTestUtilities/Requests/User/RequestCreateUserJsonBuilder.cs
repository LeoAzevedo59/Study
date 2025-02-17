using Communication.Requests.Users;

namespace CommonTestUtilities.Requests.User
{
    public abstract class RequestCreateUserJsonBuilder
    {
        public static RequestCreateUserJson Build()
        {
            RequestCreateUserJson request = new()
            {
                Name = "Leo",
                Email = "leo@exemple.com",
                Password = "password"
            };

            return request;
        }
    }
}
