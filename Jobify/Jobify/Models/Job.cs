
using Xamarin.Forms.GoogleMaps;

namespace Jobify.Models {
    public class Job {
        public Position Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = "";
        public string SkillsRequired { get; set; } = "";
        public string Schedlue { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string OtherContacts { get; set; } = "";
        public string Pay { get; set; } = "";
        public string Info { get; set; } = "";
        public User Author { get; set; }

        public Job(Position location, string title) {
            Location = location;
            Title = title;
        }
    }
}
