using Jobify.Pages;
using Jobify.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify {
    public partial class App : Application {
        public App() {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            ServiceManager.Init();
            
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
