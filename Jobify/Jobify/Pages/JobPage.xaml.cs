using Jobify.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobPage : ContentPage {

        public Job Job { get; set; }

        public JobPage(Job job) {
            InitializeComponent();
            BindingContext = this;
            Job = job;
            if(Job.Author!=null)
                Author.Text = Job.Author.Name + " " + Job.Author.Surname;

            var address = "...";
            try {
                var geocoder = new Geocoder();
                //Fix this later:
                //address= string.Join(", ",geocoder.GetAddressesForPositionAsync(Job.Location).Result);
                address = "Lapu street 15";
            } catch(Exception e) {
                Console.WriteLine(e);
            }


            //adding menu items
            var item_list = new List<ListItem>() {
                 new ListItem() { Name  = "Job"             ,Value = Job.Title          }
                ,new ListItem() { Name  = "Skills Required" ,Value = Job.SkillsRequired }
                ,new ListItem() { Name  = "Address"         ,Value = address            }
                ,new ListItem() { Name  = "When"            ,Value = Job.Schedlue       }
                ,new ListItem() { Name  = "Contacts"        ,Value = Job.PhoneNumber    }
                ,new ListItem() { Name  = "Pay"             ,Value = Job.Pay            }
                ,new ListItem() { Name  = "More Info"       ,Value = Job.Info           }
            };

            //removing empty ones:
            item_list.RemoveAll(li => li.Value == null || li.Value.Equals(""));
            List.ItemsSource = item_list;

        }

        private void Accept(object sender, EventArgs e) {
            Navigation.PopAsync();
        }
    }

    public class ListItem{
        public string Name { get; set; }
        public string Value { get; set; }
    

    
    }
}