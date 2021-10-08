using System.Collections;
using System.Collections.Generic;
using Models;

namespace Assignment_1.Data
{
    public interface IAdultData
    {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
        void RemoveAdult(int adultId);
        Adult GetById(int adultId);
        void SaveChanges();
    }
}