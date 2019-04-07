using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmQuiz.iOS.Helpers;

namespace MvvmQuiz.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, Forms.UI.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            AppCenter.Start($"ios={Secrets.AppCenterSecret};",
                            typeof(Analytics), typeof(Crashes));
        }
    }
}
