using Jobify.Map;
using Jobify.Shared.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Jobify.Pages.NewJob {
    internal class NewJobLocation : NewJobNavAbstr {
        private Xamarin.Forms.GoogleMaps.Map map;

        public NewJobLocation(Job Job): base(Job) {
            var rlayout = new RelativeLayout();
            map = new Xamarin.Forms.GoogleMaps.Map();
            MapInitializer.StyleMap(map);
            _ = MapInitializer.CenterOnUserAsync(map);
            StackLayout.Children.Add(rlayout);
            Title = "Pick the location!";

            rlayout.Children.Add(map,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(rl => rl.Width),
                Constraint.RelativeToParent(rl => rl.Height));

            var center_on_location_button = new ImageButton() {
                Source = "target.png",
                BackgroundColor = new Color(0, 0, 0, 0),
            };

            center_on_location_button.Clicked += CenterOnLocationAsync;
            rlayout.Children.Add(center_on_location_button,
                Constraint.RelativeToParent(rl => rl.Width - rl.Width * 0.16),
                Constraint.RelativeToParent(rl => rl.Width * 0.04),
                Constraint.RelativeToParent(rl => rl.Width * 0.12),
                Constraint.RelativeToParent(rl => rl.Width * 0.12));
            
            
            var pin = new Image() {
                Source = "map_pin_red.png",
            };

            rlayout.Children.Add(pin,
                Constraint.RelativeToParent(rl => rl.Width / 2 - rl.Width * 0.05),
                Constraint.RelativeToParent(rl => rl.Height / 2 - rl.Width * 0.10),
                Constraint.RelativeToParent(rl => rl.Width * 0.10),
                Constraint.RelativeToParent(rl => rl.Width * 0.10));

        }

        protected override void NextPage(object sender, EventArgs e) {
            Job.Location = map.CameraPosition.Target;
            Navigation.PushAsync(new JobCreated(Job));
        }

        private async void CenterOnLocationAsync(object sender,EventArgs e) {
            var user_location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(user_location.Latitude, user_location.Longitude),
                Distance.FromKilometers(20))
            );
        }
    }
}