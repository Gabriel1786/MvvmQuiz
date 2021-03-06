﻿using Android.App;
using Android.OS;
using Android.Content.PM;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmQuiz.Core;
using MvvmQuiz.Droid.Helpers;
using System.Linq;

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

            Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);
            Xamarin.Auth.CustomTabsConfiguration.CustomTabsClosingMessage = null;

            SetupConfigurations();

            base.OnCreate(bundle);
        }

        public void SetupConfigurations()
        {
            AppConfigurations.GoogleClientId = Secrets.GoogleClientId;
            AppConfigurations.FirebaseApiKey = Secrets.FirebaseApiKey;
            AppConfigurations.FacebookAppId = Secrets.FacebookAppId.ToString().Split('.').ToList().LastOrDefault(); //HACK: added a . because AppCenter converts to int and bugs everything, must remove . runtime
            AppConfigurations.FacebookRedirectUrl = Secrets.FacebookCustomScheme;
            AppConfigurations.GoogleRedirectUrl = Secrets.GoogleCustomScheme;
        }
    }
}

