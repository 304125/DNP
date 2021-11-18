using System.Threading.Tasks;
using Assignment_2_Web_Client.Models;

namespace Assignment_2_Web_Client.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
    }
}