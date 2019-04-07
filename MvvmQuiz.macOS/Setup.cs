using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MvvmCross.Forms.Platforms.Mac.Core;
using MvvmQuiz.macOS.Helpers;

namespace MvvmQuiz.macOS
{
    public class Setup : MvxFormsMacSetup<Core.App, Forms.UI.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            AppCenter.Start($"ios={Secrets.AppCenterSecret};",
                            typeof(Analytics), typeof(Crashes));
        }
    }
}
