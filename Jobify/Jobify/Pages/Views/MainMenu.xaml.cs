using Jobify.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentView {
        public List<MainMenuItem> MainMenuItems { get; set; }
        public MainMenuItem LogoutItem { get; set; }
        public MainMenuItem ProfileItem { get; set; }


        public MainMenu() {


            InitializeComponent();
            // Build the Menu
            MenuListView.ItemsSource = new[] {
                new MainMenuItem("Account Details"  ,"triangle.png"     ,AccountDetails),
                new MainMenuItem("Security"         ,"shield.png"       ,Security),
                new MainMenuItem("Payments"         ,"play_many.png"    ,Payments),
                new MainMenuItem("FAQ"              ,"question.png"     ,FAQ),
                new MainMenuItem("Support"          ,"comment.png"      ,Support),
                new MainMenuItem("Settings"         ,"cog.png"          ,Settings)
            };

            LogoutItem = new MainMenuItem("Logout", "exit.png", () => { });
            LogoutButton.BindingContext = LogoutItem;
            var logoutTap = new TapGestureRecognizer();
            logoutTap.Tapped += Logout;
            LogoutButton.GestureRecognizers.Add(logoutTap);


            var boxTapHandler = new TapGestureRecognizer();
            boxTapHandler.Tapped += CloseMenu;
            Background.GestureRecognizers.Add(boxTapHandler);
            UserData.BindingContext = ((UserService)ServiceManager.Instance.GetService(typeof(UserService))).loggedUser;
            
        }

        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e) {
            var item = MenuListView.SelectedItem as MainMenuItem;
            if(MenuListView.SelectedItem != null) {
                item.Action();
            }
            MenuListView.SelectedItem = null;
            IsVisible = false;
        }

        public void CloseMenu(object sender,  EventArgs e) {
            MenuListView.SelectedItem = null;
            IsVisible = false;
        }
        
        private void AccountDetails() {
            //TODO
            Console.WriteLine("Ought to be implemented");
        }

        private void Security() {
            //TODO
            Console.WriteLine("Ought to be implemented");
        }

        private void Payments() {
            //TODO
            Console.WriteLine("Ought to be implemented");
        }

        private void FAQ() {
            //TODO
            Console.WriteLine("Ought to be implemented");
        }

        private void Support() {
            //TODO
            Console.WriteLine("Ought to be implemented");
        }

        private void Settings() {
            //TODO
            Console.WriteLine("Ought to be implemented");
        }

        private async void Logout(object sender, EventArgs e) {
            var pages_to_remove = Navigation.NavigationStack.ToList();
            await Navigation.PushAsync(new LoginPage());

            foreach(var item in pages_to_remove)
                Navigation.RemovePage(item);

        }
    }

    public class MainMenuItem {
        public string Text { get; set; }
        public string Icon { get; set; }
        public Action Action { get; set; }

        public MainMenuItem(string text, string icon, Action action) {
            Text = text;
            Icon = icon;
            Action = action;
        }

        public MainMenuItem() {
            
        }
    }



}