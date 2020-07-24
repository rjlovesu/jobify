using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobify.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class HamburgerMenuPage : MasterDetailPage {
        public HamburgerMenuPage() {
            Master = new HamburgerMenu();
            Detail = new NavigationPage(new MapPage());

            MessagingCenter.Subscribe<EventArgs>(this, "OpenMenu", args => {
                IsPresented = true;
            });

            MessagingCenter.Subscribe<EventArgs>(this, "CloseMenu", args => {
                IsPresented = false;
            });
        }
    }
}