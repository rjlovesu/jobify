using Jobify.Models;
using System;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobSkillsRequiredPage : NewJobPageFormEntrySuper {
        public NewJobSkillsRequiredPage(Job job) : base("What skills are required? (optional)", "Skills Required", job) {
        }

        public override void NextPage(object sender, EventArgs e) {
            Job.SkillsRequired = GetEntryText();
            Navigation.PushAsync(new NewJobDate(Job));
        }
    }
}