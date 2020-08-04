using Jobify.Models;
using Jobify.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewJobTypePage : ContentPage {
        public Job Job { get; set; }

        public NewJobTypePage(Job job) {
            InitializeComponent();
            this.Job = job;
            Picker.ItemsSource = ServiceManager.GetService<JobTypeService>().GetAllJobNames();
            Entry.TextChanged += Text_Changed;
            Picker.SelectedIndexChanged += Picked;
            Entry.Completed += Entry_Completed;
            ToolbarItems.Add(new ToolbarItem("Exit", "x.png", async () =>
            {
                
                while(Navigation.NavigationStack.Count > 1) {
                    await Navigation.PopAsync();
                }
            }));

        }

        void Entry_Completed(object sender, EventArgs e) {
            NextPage(sender, e);
        }

        void Text_Changed(object sender, EventArgs e) {
            if(!(Entry.Text == null || Entry.Text == "" || Entry.Text == " " || Picker.SelectedIndex == -1)) {
                Picker.SelectedIndex = -1;
            }
        }

        public void Picked(object sender,EventArgs e) {
            if(!(Entry.Text == null || Entry.Text == "" || Entry.Text == " " || Picker.SelectedIndex == -1)){
                Entry.Text = "";
            }
        }

        private void NextPage(object sender, EventArgs e) {
            if(Picker.SelectedIndex != -1) {
                Job.JobType = ServiceManager.GetService<JobTypeService>().JobTypeByTitle((string)Picker.SelectedItem);
            }else{
                var jt = ServiceManager.GetService<JobTypeService>().JobTypeByTitle(Entry.Text);
                if(jt!=null) {  
                    Job.JobType = jt;
                } else{
                    if(!ServiceManager.GetService<JobTypeService>().AddNewJobType(new JobType() { Name = Entry.Text })) {
                        DisplayAlert("Missing Value ", "Pick or enter what kind of job has to be done!", "OK");
                        return;
                    }
                }
            }
            //TODO navigate to next page
        }
    }
}