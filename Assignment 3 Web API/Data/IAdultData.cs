using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IAdultData
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);
        Task<Adult> RemoveAdultAsync(int adultId);
        Task<Adult> GetByIdAsync(int adultId);
        void SaveChanges();
    }
}