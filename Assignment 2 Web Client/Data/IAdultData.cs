using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_2_Web_Client.Models;

namespace Assignment_2_Web_Client.Data
{
    public interface IAdultData
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        //Task<Adult> GetByIdAsync(int adultId);
    }
}