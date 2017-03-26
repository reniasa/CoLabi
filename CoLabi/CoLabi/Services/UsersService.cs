using CoLabi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLabi.Services
{
    public class UsersService
    {
        public IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Name = "Jan Kowalski",
                    Specialization = "Frezarki"
                }
            };
        }
    }
}
