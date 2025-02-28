namespace Communication.Requests.Users
{
    public record RequestCreateUserJson(
        string Name,
        string Email,
        string Password
    );
}
