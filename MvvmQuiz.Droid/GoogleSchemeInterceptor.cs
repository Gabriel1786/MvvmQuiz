using System;
using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.OS;
using MvvmCross;
using MvvmQuiz.Core.Services;
using MvvmQuiz.Droid.Helpers;

namespace MvvmQuiz.Droid
{
    [Activity(Label = "GoogleSchemeInterceptor", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataSchemes = new[] { Secrets.GoogleCustomScheme },
        DataPath = "/oauth2redirect"
    )]
    public class GoogleSchemeInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var uri = new Uri(Intent.Data.ToString());

            var authService = Mvx.IoCProvider.Resolve<ILoginService>();
            authService.Authenticator?.OnPageLoading(uri);

            var intent = new Intent(ApplicationContext, typeof(RootActivity));
            StartActivity(intent);

            Finish();
        }
    }
}
