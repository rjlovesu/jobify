

using Xamarin.Forms.GoogleMaps;

namespace Jobify.Models {
    public class Job {
        public Position Location { get; set; }
        public string Name { get; set; }

        public Job(Position location, string name) {
            Location = location;
            Name = name;
        }
    }
}
