using MediaMakerCalculator.Data;
using MediaMakerCalculator.Models;
using MediaMakerCalculator.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaMakerCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CredentialsController : ControllerBase
    {
        // Authenticates the user's credentials and returns a bearer token for use with the credentials controller

        private readonly IAuthHelper _authHelper;  
        private readonly IConfiguration _config;
        private readonly ILogHelper _logHelper;
        private readonly LoggingDbContext _context;

        public CredentialsController(IAuthHelper authHelper, IConfiguration config, ILogHelper logHelper, LoggingDbContext context)
        {
            _authHelper = authHelper;
            _config = config;
            _logHelper = logHelper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsRequest credentials)
        {
            var token = _authHelper.Authenticate(credentials.Username, credentials.Password, _config);
            if(string.IsNullOrEmpty(token.Token))
            {
                _logHelper.LogItem("Unable to authenticate credentials", "Error", _context);
                return Unauthorized();
            }
            _logHelper.LogItem("Authenticated credentials successfully", "Information", _context);
            return Ok(token);
        }
    }
}
