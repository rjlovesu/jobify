using Jobify.Shared.Models;
using System;

namespace Jobify.Pages.NewJob {
    public class NewJobMoreInfo : NewJobNavSimpleAbstr{
        public NewJobMoreInfo(Job Job) : base(Job){
            Title = "More Info";
            Label = "Is there anything else employee needs to know? (optional)";
        }

        protected override void NextPage(object sender, EventArgs e) {
            Job.Info = Entry;
            Navigation.PushAsync(new NewJobLocation(Job));
        }
    }
}