using System.Threading.Tasks;
using Assignment_2_Web_Client.Models;

namespace Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
    }
}