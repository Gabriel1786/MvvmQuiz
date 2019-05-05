using System;
using System.Threading.Tasks;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Utils;
using Xamarin.Auth;

namespace MvvmQuiz.Core.Services
{
    public class LoginService : ILoginService
    {
        public OAuth2Authenticator Authenticator { get; set; }

        public Task<User> FacebookLogin()
        {
            var taskResult = new TaskCompletionSource<User>();

            try
            {
                Authenticator = new OAuth2Authenticator(
                    clientId: AppConfigurations.FacebookAppId,
                    //: null,
                    scope: "public_profile, email",
                    authorizeUrl: new Uri("https://www.facebook.com/v3.3/dialog/oauth"),
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
                            var firebaseLoginResult = await LoginFirebase(accessToken, Firebase.Auth.FirebaseAuthType.Facebook);
                            taskResult.SetResult(firebaseLoginResult);
                        }
                        else
                        {
                            taskResult.SetResult(null);
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

        public Task<User> GoogleLogin()
        {
            var taskResult = new TaskCompletionSource<User>();

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
                            var firebaseLoginResult = await LoginFirebase(accessToken, Firebase.Auth.FirebaseAuthType.Google);
                            taskResult.SetResult(firebaseLoginResult);
                        }
                        else
                        {
                            taskResult.SetResult(null);
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

        public async Task<User> LoginFirebase(string token, Firebase.Auth.FirebaseAuthType firebaseAuthType)
        {
            var authProvider = new Firebase.Auth.FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(AppConfigurations.FirebaseApiKey));
            var auth = await authProvider.SignInWithOAuthAsync(firebaseAuthType, token);
            if (auth == null)
            {
                return null;
            }

            var authResult = new AuthResult { AccessToken = token, AuthType = firebaseAuthType, Auth = auth };
            PreferencesHelpers.Set(Constants.AUTH_RESULT, authResult);

            var user = new User
            {
                Id = auth.User.LocalId,
                FirstName = auth.User.FirstName,
                LastName = auth.User.LastName,
                PhotoUrl = auth.User.PhotoUrl
            };

            Console.WriteLine($"Logged in as {auth.User.DisplayName ?? auth.User.FirstName ?? auth.User.LastName}");

            return user;
        }
    }
}