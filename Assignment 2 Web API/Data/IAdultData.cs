using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_2.Models;

namespace Assignment_2.Data
{
    public interface IAdultData
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);
        Task<Adult> RemoveAdultAsync(int adultId);
        Task<Adult> GetByIdAsync(int adultId);
        Task SaveChanges();
    }
}