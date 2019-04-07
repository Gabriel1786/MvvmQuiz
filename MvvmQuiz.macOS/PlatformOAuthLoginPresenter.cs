using System;
using AppKit;
using Xamarin.Auth;

namespace MvvmQuiz.macOS
{
    public class PlatformOAuthLoginPresenter
    {
        AppKit.NSViewController rootViewController;

        public void Login(Authenticator authenticator)
        {
            authenticator.Completed += AuthenticatorCompleted;

            rootViewController = AppKit.NSApplication.SharedApplication.KeyWindow.ContentViewController;
            var oauthVc = new NSViewController(null, null);
            oauthVc.Title = "OAuth Controller";
            rootViewController.PresentViewControllerAsSheet(oauthVc);
        }

        void AuthenticatorCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            rootViewController.DismissViewController(null);
            ((Authenticator)sender).Completed -= AuthenticatorCompleted;
        }
    }
}
