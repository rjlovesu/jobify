using Jobify.Shared.Models;
using Jobify.Services;
using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using Jobify.Map;
using Jobify.Pages.NewJob;

namespace Jobify.Pages {

    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage {

        public MapPage() {
            InitializeComponent();

            SetButtons();
            MapInitializer.StyleMap(MainMap);
            UpdateMap();

            MessagingCenter.Subscribe<EventArgs>(this, "RefreshData", args => {
                UpdateMap();
            });
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

            /*TODO wtf did this do?
             * 
            var filter_button = new ImageButton() {
                Source = "suitcase.png",
                BackgroundColor= new Color(0, 0, 0, 0)
            };
            RLayout.Children.Add(filter_button,
                Constraint.RelativeToParent(rl => rl.Width - rl.Width * 0.04 - rl.Width * 0.08),
                Constraint.RelativeToParent(rl => rl.Width * 0.05),
                Constraint.RelativeToParent(rl => rl.Width * 0.08),
                Constraint.RelativeToParent(rl => rl.Width * 0.065));
            */


            var location_button = new ImageButton() {
                Source = "target.png",
                BackgroundColor = new Color(0, 0, 0, 0),
            };
            location_button.Clicked += LocationButtonClicked;
            RLayout.Children.Add(location_button,
                Constraint.RelativeToParent(rl => rl.Width - rl.Width * 0.03 - rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Height - rl.Width * 0.03 - rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Width * 0.1));

            var new_job_button = new ImageButton() {
                Source = "plus.png",
                BackgroundColor = new Color(0, 0, 0, 0),

            };
            new_job_button.Clicked += NewJobButtonClicked;
            RLayout.Children.Add(new_job_button,
                Constraint.RelativeToParent(rl => rl.Width * 0.05),
                Constraint.RelativeToParent(rl => rl.Height - rl.Width * 0.03 - rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Width * 0.1),
                Constraint.RelativeToParent(rl => rl.Width * 0.1));


        }


        async void UpdateMap() {

            MainMap.Pins.Clear();

           await MapInitializer.CenterOnUserAsync(MainMap);



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

        void NewJobButtonClicked(object sender, EventArgs e) {
            Navigation.PushAsync(new NewJobType(new Job()));
        }
        void HamburgerButtonClicked(object sender, EventArgs e) {
            MessagingCenter.Send(EventArgs.Empty, "OpenMenu");
        }

        async void LocationButtonClicked(object sender, EventArgs e) {
            var user_location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(user_location.Latitude, user_location.Longitude),
                Distance.FromKilometers(20))
                );
        }
    }
}