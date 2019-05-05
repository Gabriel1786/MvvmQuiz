using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Firebase.Database;
using MvvmCross;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace MvvmQuiz.Core.Services
{
    public class ClientService : IClientService
    {
        public FirebaseClient Client { get; set; }

        public ClientService()
        {
            Client = new FirebaseClient(Constants.DATABASE_URL, new FirebaseOptions
            {
                AuthTokenAsyncFactory = AuthToken,
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = AppConfigurations.PropertyNamesContractResolver
                }
            });
        }

        private async Task<string> AuthToken()
        {
            var authResultJson = Xamarin.Essentials.Preferences.Get(Constants.AUTH_RESULT, null);
            if (string.IsNullOrEmpty(authResultJson))
            {
                return null;
            }

            var authResult = JsonConvert.DeserializeObject<AuthResult>(authResultJson);
            if (authResult.Auth.IsExpired())
            {
                var loginService = Mvx.IoCProvider.Resolve<ILoginService>();
                await loginService.LoginFirebase(authResult.AccessToken, authResult.AuthType);

                Debug.WriteLine("Attempting to refresh AuthToken.");
                return await AuthToken();
            }

            return authResult.Auth.FirebaseToken;
        }
    }
}