using Jobify.Models;
using Jobify.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobCreated : ContentPage {
        public JobCreated(Job job) {
            
            InitializeComponent();

            ServiceManager.GetService<JobService>().saveJob(job);
            //TODO save job
        }

        public async void Close(object sender, EventArgs e) {
            await Navigation.PopToRootAsync();
        }

    }

   
}