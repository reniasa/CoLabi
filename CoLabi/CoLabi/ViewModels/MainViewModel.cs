using CoLabi.Models;
using CoLabi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLabi.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IEnumerable<User> Users { get; set; }

        private UsersService _usersService;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _usersService = new UsersService();
            Users = _usersService.GetUsers();
        }


    }
}
