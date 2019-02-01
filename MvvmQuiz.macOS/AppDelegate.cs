using AppKit;
using Foundation;
using MvvmCross.Forms.Platforms.Mac.Core;

namespace MvvmQuiz.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, Forms.UI.App>
    {
        public override void DidFinishLaunching(NSNotification notification)
        {
            base.DidFinishLaunching(notification);
        }
    }
}
