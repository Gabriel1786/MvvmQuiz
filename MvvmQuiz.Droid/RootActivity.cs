using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using MvvmCross.Forms.Platforms.Android.Views;

namespace MvvmQuiz.Droid
{
    [Activity(Label = "@string/app_name",
              Icon = "@mipmap/icon",
              Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              LaunchMode = LaunchMode.SingleTask)]
    public class RootActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
        }
    }
}

