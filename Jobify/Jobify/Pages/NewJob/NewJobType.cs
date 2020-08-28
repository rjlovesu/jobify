using Jobify.Shared.Models;
using Jobify.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages.NewJob {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobType : NewJobNavAbstr {

        private Picker picker;
        private Entry entry;

        public NewJobType(Job job) : base(job){

            StackLayout.Margin = new Thickness(20);

            StackLayout.Children.Add(new Label() { Text = "What kind of job you need to get done?" , FontSize = 20 });

            picker = new Picker() { ItemsSource = ServiceManager.GetService<JobTypeService>().GetAllJobNames(), Title = "Choose from a list" };
            picker.SelectedIndexChanged += Picked;
            StackLayout.Children.Add(picker);

            StackLayout.Children.Add(new Label() { Text = "or", FontSize = 16 });

            StackLayout.Children.Add(entry = new Entry() { 
                Placeholder = "enter your own..." 
            });
            entry.TextChanged += Text_Changed;
            entry.Completed += Entry_Completed;


        }

        void Entry_Completed(object sender, EventArgs e) {
            NextPage(sender, e);
        }

        void Text_Changed(object sender, EventArgs e) {
            if(!(entry.Text == null || entry.Text == "" || entry.Text == " " || picker.SelectedIndex == -1)) {
                picker.SelectedIndex = -1;
            }
        }

        public void Picked(object sender, EventArgs e) {
            if(!(entry.Text == null || entry.Text == "" || entry.Text == " " || picker.SelectedIndex == -1)) {
                entry.Text = "";
            }
        }

        protected override void NextPage(object sender, EventArgs e) {
            if(picker.SelectedIndex != -1) {
                Job.Title = ServiceManager.GetService<JobTypeService>().JobTypeByTitle((string)picker.SelectedItem).Name;
            } else {
                var jt = entry.Text ;
                if(!string.IsNullOrEmpty(jt)) {
                    Job.Title = jt;
                } else {
                    DisplayAlert("Missing Value ", "Pick or enter what kind of job has to be done!", "OK");
                    return; 
                }
            }
            //navigate to next page
            Navigation.PushAsync(new NewJobSkillsRequiredPage(Job));
        }

    }
}