using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenPlusMongo.Models.RequestModels;
using TokenPlusMongo.Services.AuthServices;

namespace TokenPlusMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenComboDb _dbContext;
        private readonly IAuthService _authService;

        public LoginController(TokenComboDb dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            string pass = PasswordHasher.GetHash(request.Password);
            if(!_dbContext.Users.Any(x=> x.UserName==request.UserName && x.PasswordHash==pass))
            {
                return BadRequest("Login yoki parol xato");
            }
            string token = _authService.GenerateToken(request.UserName);   

            return Ok(token);
        }
    }
}
