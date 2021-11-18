using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment_2_Web_Client.Models;

namespace Data
{
    public class WebUserService : IUserService
    {
        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5002/User?userName={userName}&password={password}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            User userToGet = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return userToGet;
        }
    }
}