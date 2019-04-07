using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Auth;

namespace MvvmQuiz.Core.Services
{
    public class LoginService : ILoginService
    {
        public OAuth2Authenticator Authenticator { get; set; }

        public Task<bool> FacebookLogin()
        {
            var taskResult = new TaskCompletionSource<bool>();

            try
            {
                Authenticator = new OAuth2Authenticator(
                    clientId: AppConfigurations.FacebookAppId,
                    //: null,
                    scope: "public_profile, email",
                    authorizeUrl: new Uri("https://www.facebook.com/v2.9/dialog/oauth"),
                    redirectUrl: new Uri($"{AppConfigurations.FacebookRedirectUrl}://authorize"),
                    //accessTokenUrl: new Uri("https://graph.facebook.com/oauth/access_token"),
                    getUsernameAsync: null,
                    isUsingNativeUI: true);

                var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
                presenter.Login(Authenticator);

                Authenticator.Completed += async (object sender, AuthenticatorCompletedEventArgs e) => 
                {
                    try
                    {
                        if (e.IsAuthenticated)
                        {
                            var accessToken = e.Account.Properties["access_token"];
                            var firebaseLoginResult = await LoginFirebase(accessToken, FirebaseAuthType.Facebook);
                            taskResult.SetResult(firebaseLoginResult);
                        }
                        else
                        {
                            taskResult.SetResult(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return taskResult.Task;
        }

        public Task<bool> GoogleLogin()
        {
            var taskResult = new TaskCompletionSource<bool>();

            try
            {
                Authenticator = new OAuth2Authenticator(
                    clientId: AppConfigurations.GoogleClientId,
                    clientSecret: null,
                    scope: "https://www.googleapis.com/auth/userinfo.profile",
                    authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                    redirectUrl: new Uri($"{AppConfigurations.GoogleRedirectUrl}:/oauth2redirect"),
                    accessTokenUrl: new Uri("https://www.googleapis.com/oauth2/v4/token"),
                    getUsernameAsync: null,
                    isUsingNativeUI: true);

                var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
                presenter.Login(Authenticator);

                Authenticator.Completed += async (object sender, AuthenticatorCompletedEventArgs e) =>
                {
                    try
                    {
                        if (e.IsAuthenticated)
                        {
                            var accessToken = e.Account.Properties["access_token"];
                            var firebaseLoginResult = await LoginFirebase(accessToken, FirebaseAuthType.Google);
                            taskResult.SetResult(firebaseLoginResult);
                        }
                        else
                        {
                            taskResult.SetResult(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return taskResult.Task;
        }

        async Task<bool> LoginFirebase(string token, FirebaseAuthType firebaseAuthType)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(AppConfigurations.FirebaseApiKey));
            var auth = await authProvider.SignInWithOAuthAsync(firebaseAuthType, token);

            if (auth != null)
            {
                Console.WriteLine($"Logged in as {auth.User.DisplayName ?? auth.User.FirstName ?? auth.User.LastName}");
            }

            return auth != null;
        }
    }
}