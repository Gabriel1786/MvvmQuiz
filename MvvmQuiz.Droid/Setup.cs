using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmQuiz.Droid.Helpers;
using Xamarin.Forms;

namespace MvvmQuiz.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, Forms.UI.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            AppCenter.Start($"android={Secrets.AppCenterSecret};",
                            typeof(Analytics), typeof(Crashes));
        }
    }
}
