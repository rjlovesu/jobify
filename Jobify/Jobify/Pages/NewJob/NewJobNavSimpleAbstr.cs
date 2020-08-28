using Jobify.Shared.Models;
using Xamarin.Forms;

namespace Jobify.Pages.NewJob {
    public abstract class NewJobNavSimpleAbstr : NewJobNavAbstr {

        private Label label;
        protected string Label { 
            set { label.Text = value; }
        }

        private Entry entry;
        protected string Entry {
            get { return entry.Text; }
        }

        public NewJobNavSimpleAbstr(Job Job) : base(Job) {
            StackLayout.Margin = new Thickness(20);
            label = new Label() { FontSize = 20};
            StackLayout.Children.Add(label);

            entry = new Entry() { Placeholder = "type..."};
            entry.Completed += NextPage;
            StackLayout.Children.Add(entry);
        }
    }
}