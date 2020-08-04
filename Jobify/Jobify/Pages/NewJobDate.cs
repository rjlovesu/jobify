using Jobify.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobDate : NewJobPageFormEntrySuper {
        public NewJobDate(Job job) : base("When?", "Date", job) {
        }

        public override void NextPage(object sender, EventArgs e) {

            Job.Schedlue = GetEntryText();
            if(string.IsNullOrEmpty(Job.Schedlue)) {
                DisplayAlert("Missing Value ", "Enter info about date and time!", "OK");
                return;
            }
            Navigation.PushAsync(new NewJobContacts(Job));
        }
    }
}