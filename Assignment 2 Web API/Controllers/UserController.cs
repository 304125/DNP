using System.Threading.Tasks;
using Assignment_2.Data;
using Assignment_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
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