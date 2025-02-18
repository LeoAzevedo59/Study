using Domain.Entities;
using Domain.Tokens;
using Moq;

namespace CommonTestUtilities.Security.Tokens
{
    public class JwtTokenGeneratorBuilder
    {
        public static IAccessTokenGenerator Build()
        {
            Mock<IAccessTokenGenerator> mock = new();

            mock.Setup(
                accessTokenGenerator => accessTokenGenerator
                    .Generate(It.IsAny<User>())).Returns(
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImEyY2FlYzIxLTc5ZmYtNDRmZS1iYTcwLWMyNTZlYWRhNGNlNyIsIm5hbWVpZCI6ImUwYjJiNWFhLTQzMjUtNDJhMS04YmJhLTA2NDZkZWExMmRmNSIsInJvbGUiOiJndWVzdCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6IjhmOWNjYjRlLTRjNjQtNDE2OS1hNzdiLTZmOWU1NmJiZjgxOSIsIm5iZiI6MTczOTg4MzcyOCwiZXhwIjoxNzQyNTExNzI4LCJpYXQiOjE3Mzk4ODM3MjgsImlzcyI6ImEzeFpGOUQ4U003UHh5OERUcVkyYTg0TTlhTEtVM1VYIn0.Qx5x1ml5QisCcKZWsdfa-FI3qyj-7YZnijRfBF6LMxs");

            return mock.Object;
        }
    }
}
