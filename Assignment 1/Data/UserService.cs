using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Assignment_1.Data
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
                    SecurityLevel = 1,
                    UserName = "Mihail"

                },
                new User
                {
                    Password = "123",
                    SecurityLevel = 1,
                    UserName = "Alex"
                }
            }.ToList();
        }
        public User ValidateUser(string userName, string password)
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