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
        public async Task<List<User>> GetUsers()
        {
            RestClient<User> restClient = new RestClient<User>();
            return await restClient.GetAsync();
        }
    }
}
