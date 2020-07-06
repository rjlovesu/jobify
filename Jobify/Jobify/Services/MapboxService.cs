using System;
using System.Net.Http;
using System.Threading.Tasks;
using Naxam.Controls.Forms;
using Newtonsoft.Json;
using System.Linq;

namespace Jobify.Services
{
    public interface IMapBoxService
    {
    }

    public class MapBoxService : IMapBoxService
    {
        HttpClient client;
        static string BaseURL = "https://api.mapbox.com/";
        public static string AccessToken = "pk.eyJ1Ijoicmpsb3Zlc3UiLCJhIjoiY2tjOTI3cHJwMWgzNTJ5bWd5NThwYXRiNCJ9.G-uKLaOpum6vM2moGCAUww";
        public static string Username = "rjlovesu";
        public MapBoxService()
        {
            client = new HttpClient()
            {
                MaxResponseContentBufferSize = 256000
            };
        }

    }
}
