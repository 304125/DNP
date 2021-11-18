using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Persistence;

namespace Data
{
    public class UserService : IUserService
    {
        private List<User> users;
        private AdultsDBContext adultsDbContext;

        public UserService()
        {
            adultsDbContext = new AdultsDBContext();
            users = new[]
            {
                new User
                {
                    Password = "123456",
                    SecurityLevel = 4,
                    UserName = "Maggie"

                },
                new User
                {
                    Password = "admin",
                    SecurityLevel = 4,
                    UserName = "admin"

                },
                new User
                {
                    Password = "123",
                    SecurityLevel = 2,
                    UserName = "Kim"

                },
                new User
                {
                    Password = "123",
                    SecurityLevel = 2,
                    UserName = "someone"

                },
                new User
                {
                    Password = "123",
                    SecurityLevel = 2,
                    UserName = "nobody"
                }
            }.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                adultsDbContext.Users.Add(users[i]);
                adultsDbContext.SaveChangesAsync();
            }
        }
        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            IList<User> users = adultsDbContext.Users.Where(user => user.UserName.Equals(userName)).ToList();
            User first = null;
            if (users != null)
            {
                first = users[0];
            }
            
            //User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}