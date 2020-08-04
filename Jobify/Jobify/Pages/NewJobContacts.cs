using Jobify.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobContacts : NewJobPageFormEntrySuper {
        public NewJobContacts(Job job) : base("Add your phone number, e-mail, etc.", "Contacts",job) {
        }

        public override void NextPage(object sender, EventArgs e) {
            Job.OtherContacts = GetEntryText();
            if(string.IsNullOrEmpty(Job.OtherContacts)) {
                DisplayAlert("Missing Value ", "Enter some information how to contact you!", "OK");
                return;
            }
            Navigation.PushAsync(new NewJobPay(Job));
        }
    }
}