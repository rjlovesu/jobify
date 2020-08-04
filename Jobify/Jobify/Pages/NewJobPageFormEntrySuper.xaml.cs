using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public abstract partial class NewJobPageFormEntrySuper : ContentPage {
        public Job Job { get; set; }
        public NewJobPageFormEntrySuper(string label,string title,Job job) {
            InitializeComponent();
            this.Job = job;
            Title = title;
            Label.Text = label;
            ToolbarItems.Add(new ToolbarItem("Exit", "x.png", async () => {

                await Navigation.PopToRootAsync();
            }));
            
        }

        public string GetEntryText() {
            return Entry.Text;
        }

        public abstract void NextPage(object sender, EventArgs e);
    }
}