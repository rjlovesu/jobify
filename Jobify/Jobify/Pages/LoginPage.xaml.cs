using Jobify.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
            ServiceManager.GetService<UserService>().Logout();
        }

        private async void LoginButton(object sender, EventArgs e) {
            var user=ServiceManager.GetService<UserService>().LoginUserByEmailAndPassword(UsernameEntry.Text,PasswordEntry.Text);
            if(user != null) {

                Application.Current.MainPage = new HamburgerMenuPage();
            } else {
                await DisplayAlert("Incorrect Login data", "Password and/or email Incorrect","OK");
            }
        }

        void Entry_Completed(object sender, EventArgs e) {
            LoginButton(sender, e);
        }

    }
}