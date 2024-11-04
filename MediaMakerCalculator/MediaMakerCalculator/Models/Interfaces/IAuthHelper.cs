namespace MediaMakerCalculator.Models.Interfaces
{
    public interface IAuthHelper
    {
        public CredentialsResponse Authenticate(string user, string password, IConfiguration config);
    }
}
