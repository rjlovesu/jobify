using Jobify.Models;
using Jobify.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                      
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private async void LoginButton(object sender, EventArgs e) {
            var user=((UserService)ServiceManager.Instance.GetService(typeof(UserService))).LoginUserByEmailAndPassword(UsernameEntry.Text,PasswordEntry.Text);
            if(user != null) {
                
                await Navigation.PushAsync(new MapPage());
                Navigation.RemovePage(this);
            } else {
                await DisplayAlert("Incorrect Login data", "Password and/or email Incorrect","OK");
            }
        }

    }
}