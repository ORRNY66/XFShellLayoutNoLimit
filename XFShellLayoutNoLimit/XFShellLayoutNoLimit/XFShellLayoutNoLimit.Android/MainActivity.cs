using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;

namespace XFShellLayoutNoLimit.Droid
{
    [Activity(Label = "XFShellLayoutNoLimit", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize |
                               ConfigChanges.Orientation | 
                               ConfigChanges.UiMode | 
                               ConfigChanges.ScreenLayout |
                               ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
            Window?.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                int uiOptions = (int)Window.DecorView.SystemUiVisibility;
                uiOptions |= (int)WindowManagerFlags.LayoutNoLimits;

                //uiOptions &= ~(int)WindowManagerFlags.TranslucentNavigation;
                //uiOptions &= ~(int)WindowManagerFlags.TranslucentStatus;

                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            }

            Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            Window.ClearFlags(WindowManagerFlags.TranslucentNavigation);
            Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            Window.SetNavigationBarColor(Android.Graphics.Color.Transparent);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}