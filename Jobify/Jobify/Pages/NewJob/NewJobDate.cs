using Jobify.Shared.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages.NewJob {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobDate : NewJobNavSimpleAbstr {
        public NewJobDate(Job job) : base(job) {
            Title = "Date";
            Label = "When?";
        }

        protected override void NextPage(object sender, EventArgs e) {
            Job.Schedlue = Entry;
            if(string.IsNullOrEmpty(Job.Schedlue)) {
                DisplayAlert("Missing Value ", "Enter info about date and time!", "OK");
                return;
            }
            Navigation.PushAsync(new NewJobContacts(Job));
        }
    }
}