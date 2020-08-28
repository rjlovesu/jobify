using Jobify.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages.NewJob {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public abstract partial class NewJobNavAbstr : ContentPage {
        public Job Job { get; set; }
        protected StackLayout StackLayout { 
            get { return SLayout; } 
        }
        public NewJobNavAbstr(Job Job) {
            InitializeComponent();
            this.Job = Job;
            var next_button = new ImageButton() {
                Source = "next.png",
                BackgroundColor = new Color(0, 0, 0, 0),

            };
            next_button.Clicked += NextPage;
            RLayout.Children.Add(next_button,
                Constraint.RelativeToParent(rl => rl.Width - rl.Width * 0.03 - rl.Width * 0.12),
                Constraint.RelativeToParent(rl => rl.Height - rl.Width * 0.03 - rl.Width * 0.12),
                Constraint.RelativeToParent(rl => rl.Width * 0.12),
                Constraint.RelativeToParent(rl => rl.Width * 0.12));


            ToolbarItems.Add(new ToolbarItem("Exit", "x.png", async () => {

                await Navigation.PopToRootAsync();
            }));
        }

        protected abstract void NextPage(object sender, EventArgs e);

    }
}