using Naxam.Controls.Forms;
using Naxam.Mapbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jobify {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
            Title = "Default Styles";

            map.Center = new LatLng(56.946285, 24.105078);
            map.ZoomLevel = 5;
            map.MapStyle = MapStyle.LIGHT;
        }
    }
}
