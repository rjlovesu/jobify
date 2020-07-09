using Jobify.Services;
using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Threading;
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
            SetButtons();
            StyleMap();
            UpdateMap();
        }

        void SetButtons() {
            var hamburger_button = new ImageButton() {
                Source = "hamburger.png",
                BackgroundColor = new Color(0, 0, 0, 0)
            };
            RLayout.Children.Add(hamburger_button,
                Constraint.RelativeToParent(rl => rl.Width * 0.03),
                Constraint.RelativeToParent(rl => rl.Width * 0.03));

            var filter_button = new ImageButton() {
                Source = "suitcase.png",
                BackgroundColor= new Color(0,0,0,0)
            };
            RLayout.Children.Add(filter_button,
                Constraint.RelativeToView(hamburger_button, (rl, fb) => rl.Width - rl.Width * 0.03 - fb.Width),
                Constraint.RelativeToParent(rl => rl.Width * 0.03));

            var location_button = new ImageButton() {
                Source = "target.png",
                BackgroundColor = new Color(0, 0, 0, 0)
            };
            RLayout.Children.Add(location_button,
                Constraint.RelativeToView(hamburger_button, (rl, lb) => rl.Width - rl.Width * 0.03 - lb.Width),
                Constraint.RelativeToView(hamburger_button, (rl, lb) => rl.Height - rl.Width * 0.03 - lb.Height));

        }


        void StyleMap() {


            try {
                var assembly = typeof(MainPage).GetTypeInfo().Assembly;
                var stream = assembly.GetManifestResourceStream($"Jobify.Map.MapStyle.json");
                Console.WriteLine(stream.ToString());
                string styleFile;
                using(var reader = new System.IO.StreamReader(stream)) {
                    styleFile = reader.ReadToEnd();
                }

                MainMap.MapStyle = MapStyle.FromJson(styleFile);
            } catch(Exception e) {
                Console.WriteLine("Something wrong with MapStyle file: " + e.Message);

            }
            MainMap.UiSettings.ZoomControlsEnabled = false;
            MainMap.UiSettings.MyLocationButtonEnabled = false;

        }

        async void UpdateMap() {
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
