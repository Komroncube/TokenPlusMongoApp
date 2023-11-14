namespace TokenPlusMongo.Services.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(string username);
    }
}
