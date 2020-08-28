using Jobify.Shared.Models;
using Jobify.Pages.NewJob;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobSkillsRequiredPage : NewJobNavSimpleAbstr {
        public NewJobSkillsRequiredPage(Job job) : base( job) {
            Label = "What skills are required? (optional)";
            Title = "Skills Required";
        }

        protected override void NextPage(object sender, EventArgs e) {
            Job.SkillsRequired = Entry;
            Navigation.PushAsync(new NewJobDate(Job));
        }
    }
}