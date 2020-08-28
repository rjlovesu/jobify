using Jobify.Shared.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages.NewJob {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobPay : NewJobNavSimpleAbstr {
        public NewJobPay(Job Job): base(Job) {
            Title = "Pay";
            Label = "How much are you paying for the job?";
        }

        protected override void NextPage(object sender, EventArgs e) {
            Job.Pay = Entry;
            if(string.IsNullOrEmpty(Job.Pay)) {
                DisplayAlert("Missing Value ", "Enter info about pay!", "OK");
                return;
            }
            Navigation.PushAsync(new NewJobMoreInfo(Job));
        }
    }
}