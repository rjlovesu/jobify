using Jobify.Shared.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages.NewJob {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobContacts : NewJobNavSimpleAbstr {
        public NewJobContacts(Job job) : base(job) {
            Title = "Contacts";
            Label = "Enter your phone number, email, etc.";
        }

        protected override void NextPage(object sender, EventArgs e) {
            Job.OtherContacts = Entry;
            if(string.IsNullOrEmpty(Job.OtherContacts)) {
                DisplayAlert("Missing Value", "Enter some information how to contact you!", "OK");
                return;
            }
            Navigation.PushAsync(new NewJobPay(Job));
        }
    }
}