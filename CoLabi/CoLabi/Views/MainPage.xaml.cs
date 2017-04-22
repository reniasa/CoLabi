using System;
using CoLabi.ViewModels;
using Xamarin.Forms;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace CoLabi
{
    [Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                Current_ConnectivityChanged(sender, args);
            };
        }

        private async void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs args)
        {
            await DisplayAlert("Connectivity Changed", "IsConnected: " + args.IsConnected.ToString(), "OK");
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as MainViewModel).InitializeAsync();
            
            if(CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Success!", "You are connected to WiFi", "Ok");
                foreach(var con in CrossConnectivity.Current.ConnectionTypes)
                {

                    
                }
                
            }
        }

        private object await(MainViewModel mainViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
