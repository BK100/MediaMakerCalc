namespace MediaMakerCalculator.Models.Interfaces
{
    public interface IAuthHelper
    {
        public string? Authenticate(string user, string password, IConfiguration config);
    }
}
