using Jobify.Pages;
using Jobify.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerMenu : ContentPage {

        public HamburgerMenu() {
            InitializeComponent();

            listView.ItemsSource = new[] {
                /*new MainMenuItem("Account Details"  ,"triangle.png"     ,AccountDetails ),
                new MainMenuItem("Security"         ,"shield.png"       ,Security       ),
                new MainMenuItem("Payments"         ,"play_many.png"    ,Payments       ),
                new MainMenuItem("FAQ"              ,"question.png"     ,FAQ            ),
                new MainMenuItem("Support"          ,"comment.png"      ,Support        ),
                new MainMenuItem("Settings"         ,"cog.png"          ,Settings       ),*/
                new MainMenuItem("Logout"           ,"exit.png"         ,Logout         )  
            };

            var logged_user = ServiceManager.GetService<UserService>().loggedUser;
            UserName.Text = logged_user.Name+" " +logged_user.Surname;
        }

        public void ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var item = listView.SelectedItem as MainMenuItem;
            if(listView.SelectedItem != null) {
                item.Action();
            }
            listView.SelectedItem = null;
            MessagingCenter.Send(EventArgs.Empty, "CloseMenu");
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

        private void Logout() {

            Application.Current.MainPage = new NavigationPage(new LoginPage());

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