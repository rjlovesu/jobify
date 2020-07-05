using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Jobify {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        private static string bomb = new Random().Next(1, 4).ToString();

        public MainPage() {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e) {
            Button button = sender as Button;

            if(button.Text == bomb) {
                await DisplayAlert("Bomb Exploded!", "GAME OVER", "retry");
                bomb = new Random().Next(1, 4).ToString();

            }
        }
    }
}
