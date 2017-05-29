using CoLabi.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLabi.Services
{
    public class UsersService
    {
        private RestClient<User> _restClient;
        public UsersService()
        {
            _restClient = new RestClient<User>();
        }
        public async Task<List<User>> GetUsers()
        {
            return await _restClient.GetAsync();
        }

        public async Task<bool> UpdateUserActivity(int id, User user)
        {
            return await _restClient.PutAsync(id, user);
        }

        public async Task<User> GetUser(int id)
        {
            return await _restClient.GetAsync(id);
        }
    }
}
