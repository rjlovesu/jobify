using Jobify.Models;
using Jobify.Pages.Views;
using Jobify.Services;
using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Internals;

namespace Jobify.Pages {

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MapPage : ContentPage {
        MainMenu Main;

        public MapPage() {
            InitializeComponent();

            SetButtons();
            StyleMap();
            UpdateMap();
        }

        
        void SetButtons() {
            var hamburger_button = new ImageButton() {
                Source = "hamburger.png",
                BackgroundColor = new Color(0, 0, 0, 0),
                
            };
            hamburger_button.Clicked += HamburgerButtonClicked;

            RLayout.Children.Add(hamburger_button,
                Constraint.RelativeToParent(rl => rl.Width * 0.03),
                Constraint.RelativeToParent(rl => rl.Width * 0.03),
                Constraint.RelativeToParent(rl => rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Width * 0.1));

            var filter_button = new ImageButton() {
                Source = "suitcase.png",
                BackgroundColor= new Color(0, 0, 0, 0)
            };
            RLayout.Children.Add(filter_button,
                Constraint.RelativeToParent(rl => rl.Width - rl.Width * 0.04 - rl.Width * 0.08),
                Constraint.RelativeToParent(rl => rl.Width * 0.05),
                Constraint.RelativeToParent(rl => rl.Width * 0.08),
                Constraint.RelativeToParent(rl => rl.Width * 0.065));

            var location_button = new ImageButton() {
                Source = "target.png",
                BackgroundColor = new Color(0, 0, 0, 0),
                
            };
            RLayout.Children.Add(location_button,
                Constraint.RelativeToParent(rl => rl.Width - rl.Width * 0.03 - rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Height - rl.Width * 0.03 - rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Width * 0.1));

            Main = new MainMenu() {
                IsVisible = false
            };
            RLayout.Children.Add(Main,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(rl => rl.Width * 1),
                Constraint.RelativeToParent(rl => rl.Height * 1));
        }


        void StyleMap() {
            try {
                var assembly = typeof(MapPage).GetTypeInfo().Assembly;
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
            //centering the map on user
            var user_location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(user_location.Latitude, user_location.Longitude),
                Distance.FromKilometers(100))
                );

            MainMap.InfoWindowClicked += InfoWindowClicked;
            //adding pins where jobs are
            ServiceManager.GetService<JobService>().GetAllJobs()
                .ForEach(job => {
                    var pin = new Pin() {
                        Label = job.Title,
                        Position = job.Location,
                        BindingContext = job,
                        Icon = BitmapDescriptorFactory.FromBundle("map_pin")
                        
                    };
                    MainMap.Pins.Add(pin);

                });

            

        }

        private void InfoWindowClicked(object sender, InfoWindowClickedEventArgs e) {
            var job = (Job)e.Pin.BindingContext;
            Navigation.PushAsync(new JobPage(job));
        }


        void HamburgerButtonClicked(object sender, EventArgs e) {
            Main.IsVisible = true;
        }
    }
}

