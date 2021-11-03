using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment_2.Models;
using Assignment_2.Persistence;

namespace Assignment_2.Data
{
    public class AdultData : IAdultData
    {
        private string adultsFile = "adults.json";
        private FileContext fileContext;
        private IList<Adult> adults;

        public AdultData()
        {
            fileContext = new FileContext();
            string content = File.ReadAllText(adultsFile);
            adults = JsonSerializer.Deserialize<List<Adult>>(content);
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return new List<Adult>(adults);
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adults.Max(todo => todo.Id);
            adult.Id = (++max);
            adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task<Adult> RemoveAdultAsync(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            SaveChanges();
            return toRemove;
        }

        public async Task<Adult> GetByIdAsync(int adultId)
        {
            return adults.FirstOrDefault(t => t.Id == adultId);
        }
        
        public void SaveChanges()
        {
            fileContext.SaveChanges();
        }
    }
}