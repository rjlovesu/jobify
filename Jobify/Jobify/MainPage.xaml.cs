using Jobify.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Jobify {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            UpdateMap();
        }

        public async void UpdateMap() {
            //adding pins where jobs are
            MainMap.ItemsSource = ((JobService)ServiceManager.Instance.GetService(typeof(JobService))).GetAllJobs();

            //centering the map on user
            var user_location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(user_location.Latitude, user_location.Longitude), 
                Distance.FromKilometers(100))
                );

        }
    }
}
