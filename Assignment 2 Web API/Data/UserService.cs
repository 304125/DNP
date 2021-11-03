using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_2.Models;

namespace Assignment_2.Data
{
    public class UserService : IUserService
    {
        private List<User> users;

        public UserService()
        {
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
        }
        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
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