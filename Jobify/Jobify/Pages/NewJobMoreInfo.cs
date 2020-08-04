using Jobify.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class NewJobMoreInfo : NewJobPageFormEntrySuper {
        public NewJobMoreInfo(Job job) :base("Is there anything else employee needs to know? (optional)","More info", job) {
            
        }

        public override void NextPage(object sender, EventArgs e) {
            Job.Info = GetEntryText();
            
            Navigation.PushAsync(new JobCreated(Job));
        }
    }
}