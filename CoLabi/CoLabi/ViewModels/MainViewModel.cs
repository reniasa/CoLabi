using CoLabi.Models;
using CoLabi.Services;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoLabi.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IEnumerable<User> _users;
        private bool _isActive;

        public bool IsActive {
            get { return _isActive; }
            set
            {
                _isActive = value;
                NotifyPropertyChanged();
            }
        }

        public IEnumerable<User> Users {
            get { return _users; }
            set
            {
                _users = value;
                NotifyPropertyChanged();
            }
        }

        private UsersService _usersService;
        private LocalService _localServer;
        public event PropertyChangedEventHandler PropertyChanged;

        public async Task InitializeAsync()
        {
            try
            {
                var embeddedImage = new Image { Aspect = Aspect.AspectFit };
                embeddedImage.Source = ImageSource.FromResource("CoLabi.images.grayDot.png");
                Users = await new UsersService().GetUsers();
                CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
                {
                    Current_ConnectivityChanged(sender, args);
                };
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
           
        }

        private async void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs args)
        {
            IsActive = await new LocalService().IsAccesible();
            var user = await new UsersService().GetUser(1);
            user.LastOnline = new DateTime();
            await new UsersService().UpdateUserActivity(1, user);
            await new UsersService().GetUsers();

        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}

namespace CoLabi
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}
