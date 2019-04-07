using System;
using Foundation;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmQuiz.Core;
using MvvmQuiz.Core.Services;
using MvvmQuiz.iOS.Helpers;
using UIKit;

namespace MvvmQuiz.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, Forms.UI.App>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

            Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();

            SetupConfigurations();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            var uri = new Uri(url.AbsoluteString);
            var loginService = Mvx.IoCProvider.Resolve<ILoginService>();
            loginService.Authenticator.OnPageLoading(uri);

            return true;
        }

        public void SetupConfigurations()
        {
            AppConfigurations.GoogleClientId = Secrets.GoogleClientId;
            AppConfigurations.FirebaseApiKey = Secrets.FirebaseApiKey;
            AppConfigurations.FacebookAppId = Secrets.FacebookAppId;
            AppConfigurations.FacebookRedirectUrl = Secrets.FacebookCustomScheme;
            AppConfigurations.GoogleRedirectUrl = Secrets.GoogleCustomScheme;
        }
    }
}

