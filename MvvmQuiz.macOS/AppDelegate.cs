using AppKit;
using Foundation;
using MvvmCross.Forms.Platforms.Mac.Core;
using MvvmQuiz.Core;
using MvvmQuiz.macOS.Helpers;

namespace MvvmQuiz.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, Forms.UI.App>
    {
        public override void DidFinishLaunching(NSNotification notification)
        {
            Xamarin.Auth.Presenters.OAuthLoginPresenter.PlatformLogin = (authenticator) =>
            {
                var oauthLogin = new PlatformOAuthLoginPresenter();
                oauthLogin.Login(authenticator);
            };

            SetupConfigurations();

            base.DidFinishLaunching(notification);
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
