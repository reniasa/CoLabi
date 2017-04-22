using CoLabi.Models;
using CoLabi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoLabi.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IEnumerable<User> _users;
        public IEnumerable<User> Users {
            get { return _users; }
            set
            {
                _users = value;
                NotifyPropertyChanged();
            }
        }

        private UsersService _usersService;

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task InitializeAsync()
        {
            try
            {
                Users = await new UsersService().GetUsers();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
           
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
