using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public async Task<User> ValidateUser([FromQuery]string userName, [FromQuery]string password)
        {
            User loggedInUser = await userService.ValidateUserAsync(userName, password);
            return loggedInUser;
        }
    }
}