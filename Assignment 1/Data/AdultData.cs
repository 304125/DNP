using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FileData;
using Models;

namespace Assignment_1.Data
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

        public IList<Adult> GetAdults()
        {
            return new List<Adult>(adults);
        }

        public void AddAdult(Adult adult)
        {
            int max = adults.Max(todo => todo.Id);
            adult.Id = (++max);
            adults.Add(adult);
            SaveChanges();
        }

        public void RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            SaveChanges();
        }

        public Adult GetById(int adultId)
        {
            return adults.FirstOrDefault(t => t.Id == adultId);
        }
        
        public void SaveChanges()
        {
            fileContext.SaveChanges();
        }
    }
}