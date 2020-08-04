using Jobify.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobPay : NewJobPageFormEntrySuper {
        public NewJobPay(Job job) : base("How much are you paying for the job?", "Pay", job) {
        }

        public override void NextPage(object sender, EventArgs e) {
            Job.Pay = GetEntryText();
            if(string.IsNullOrEmpty(Job.Pay)) {
                DisplayAlert("Missing Value ", "Enter info about pay!", "OK");
                return;
            }
            
            Navigation.PushAsync(new NewJobMoreInfo(Job));
        }
    }
}