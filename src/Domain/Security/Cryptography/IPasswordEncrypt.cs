namespace Domain.Security.Cryptography
{
    public interface IPasswordEncrypt
    {
        string Encrypt(string password);
        bool Verify(string password, string passwordHash);
    }
}
