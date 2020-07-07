using Naxam.Mapbox;

namespace Jobify.Models {
    public class Job {
        public LatLng JobLocation { get; set; }
        public string Name { get; set; }

        public Job(LatLng jobLocation, string name) {
            JobLocation = jobLocation;
            Name = name;
        }
    }
}
