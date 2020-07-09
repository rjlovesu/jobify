using Jobify.Services;
using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
//using Xamarin.Forms.Maps;

namespace Jobify {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            StyleMap();
            UpdateMap();
        }

        public void StyleMap() {
            
            try {
                var assembly = typeof(MainPage).GetTypeInfo().Assembly;
                var stream = assembly.GetManifestResourceStream($"Jobify.MapStyle.json");
                Console.WriteLine(stream.ToString());
                string styleFile;
                using(var reader = new System.IO.StreamReader(stream)) {
                    styleFile = reader.ReadToEnd();
                }
                MainMap.MapStyle = MapStyle.FromJson(styleFile);
            } catch(Exception e) {
                Console.WriteLine("Something wrong with MapStyle file: "+e.Message);
                return;
            }
           

            
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
