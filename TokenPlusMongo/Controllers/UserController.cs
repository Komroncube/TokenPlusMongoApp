using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TokenPlusMongo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _userService.GetAllUserAsync();
            return Ok(users);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(UserDto userDto)
        {
            User createdUser = await _userService.CreateUser(userDto);
            return Ok(createdUser);
        }
    }
}
