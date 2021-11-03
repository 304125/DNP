using System.Threading.Tasks;
using Assignment_2.Models;

namespace Assignment_2.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
    }
}