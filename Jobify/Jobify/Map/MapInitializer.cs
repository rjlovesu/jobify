using System;
using System.Reflection;
using Xamarin.Forms.GoogleMaps;

namespace Jobify.Map {
    public static class MapInitializer {
        private static MapStyle MapStyle;

        static MapInitializer() {
            try {
                var assembly = typeof(MapInitializer).GetTypeInfo().Assembly;
                var stream = assembly.GetManifestResourceStream($"Jobify.Map.MapStyle.json");
                Console.WriteLine(stream.ToString());
                string styleFile;
                using(var reader = new System.IO.StreamReader(stream)) {
                    styleFile = reader.ReadToEnd();
                }

                MapStyle = MapStyle.FromJson(styleFile);
            } catch(Exception e) {
                Console.WriteLine("Something wrong with MapStyle file: " + e.Message);

            }
        }

        public static Xamarin.Forms.GoogleMaps.Map StyleMap(Xamarin.Forms.GoogleMaps.Map map) {
            map.MapStyle = MapStyle;
            map.UiSettings.ZoomControlsEnabled = false;
            map.UiSettings.MyLocationButtonEnabled = false;
            return map;
        }

        public static async System.Threading.Tasks.Task<Xamarin.Forms.GoogleMaps.Map> CenterOnUserAsync(Xamarin.Forms.GoogleMaps.Map map) {
            //centering the map on user
            var user_location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(user_location.Latitude, user_location.Longitude),
                Distance.FromKilometers(20))
                );

            return map;
        }

    }

   
}
