using MediaMakerCalculator.Models;
using MediaMakerCalculator.Models.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediaMakerCalculator.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        public CredentialsResponse Authenticate(string user, string password, IConfiguration config)
        {
            // Would typically be held in and retrieved from SQL database, AWs parameter store etc
            if (user != "testUser" || password != "testPassword") return null;

            var authKey = config.GetValue<string>("AuthConfig:ApiKey");
            var bytes = Encoding.ASCII.GetBytes(authKey);

            var handler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, user)
                ]),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(descriptor);
            var writtenToken = handler.WriteToken(token);

            return new CredentialsResponse() { Token = writtenToken };
        }
    }
}
