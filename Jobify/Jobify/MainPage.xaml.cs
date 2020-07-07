using GeoJSON.Net.Feature;
using Naxam.Controls.Forms;
using Naxam.Mapbox;
using Naxam.Mapbox.Expressions;
using Naxam.Mapbox.Layers;
using Naxam.Mapbox.Sources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Jobify {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainController MC;
        public MainPage() {
            InitializeComponent();
            MC = new MainController();

            map.Center = new LatLng(56.957513, 24.114702);
            map.ZoomLevel = 40;
            map.MapStyle = MapStyle.DARK;

            map.DidFinishLoadingStyleCommand = new Command<MapStyle>(HandleStyeLoaded);


        }

        private void HandleStyeLoaded(MapStyle obj) {
            var jobMarkerCoords = MC.Job_S.GetAllJobs().Select(job => new Feature(
                new GeoJSON.Net.Geometry.Point(
                    new GeoJSON.Net.Geometry.Position(
                        job.JobLocation.Lat,
                        job.JobLocation.Long)
                    )
                )
            ).ToList();

            var source = new GeoJsonSource {
                Id = "markers.src",
                Data = new FeatureCollection(jobMarkerCoords)
            };
            map.Functions.AddSource(source);

            IconImageSource icon = (ImageSource)"marker.png";
            map.Functions.AddStyleImage(icon);

            var symbolLayer = new SymbolLayer("markers.layer", source.Id) {
                IconImage = Expression.Literal(icon.Id),
                IconAllowOverlap = Expression.Literal(false),
                IconSize = Expression.Literal(0.5),
            };
            map.Functions.AddLayer(symbolLayer);
        }
    }
}
