using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using Persistence;

namespace Data
{
    public class AdultData : IAdultData
    {
        private string adultsFile = "adults.json";
       // private FileContext fileContext;
       private AdultsDBContext adultsDbContext;
        //private IList<Adult> adults;

        public AdultData()
        {
            
            adultsDbContext = new AdultsDBContext();
            /*
            string content = File.ReadAllText(adultsFile);
            adults = JsonSerializer.Deserialize<List<Adult>>(content);

            for (int i = 0; i < adults.Count; i++)
            {
               Console.WriteLine(adults[i]); 
            }
            
            Console.WriteLine("its here");
            for (int i = 0; i < adults.Count; i++)
            {
                //adultsDbContext.Jobs.Add(adults[i].JobTitle);
                adultsDbContext.Adults.Add(adults[i]);
                SaveChanges();
                Console.WriteLine("now its here");
            }
            */
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            IList<Adult> adults = adultsDbContext.Adults.ToList();
            IList<Job> jobs = adultsDbContext.Jobs.ToList();

            for (int i = 0; i < adults.Count; i++)
            {
                for (int j = 0; j < jobs.Count; j++)
                {
                    if (adults[i].Id == jobs[j].Id)
                    {
                        adults[i].JobTitle = jobs[j];
                    }
                    
                }
            }

            
            
            return adults;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            //adult.Id = (++max);
            //adults.Add(adult);
            adultsDbContext.Adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task<Adult> RemoveAdultAsync(int adultId)
        {
            //Adult toRemove = adults.First(t => t.Id == adultId);
            Adult toRemove = await GetByIdAsync(adultId);
            //adults.Remove(toRemove);
            adultsDbContext.Adults.Remove(toRemove);
            adultsDbContext.Jobs.Remove(toRemove.JobTitle);
            SaveChanges();
            return toRemove;
        }

        public async Task<Adult> GetByIdAsync(int adultId)
        {
            List<Adult> adults = adultsDbContext.Adults.Where(adult => adult.Id == adultId).ToList();
            return adults[0];
            //return adults.FirstOrDefault(t => t.Id == adultId);
        }
        
        public void SaveChanges()
        {
            //fileContext.SaveChanges();
            adultsDbContext.SaveChanges();
        }
    }
}