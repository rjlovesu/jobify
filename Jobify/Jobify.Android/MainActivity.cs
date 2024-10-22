﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using Xamarin.Forms.GoogleMaps.Android;

namespace Jobify.Droid
{
    [Activity(Label = "Jobify", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            if(CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted) {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }

            var platformConfig = new PlatformConfig {
                BitmapDescriptorFactory = new BitmapConfig()
            };

            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState, platformConfig);
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}