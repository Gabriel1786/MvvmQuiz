using System;
using System.Threading.Tasks;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Services.Interfaces;
using Firebase.Database.Query;
using Newtonsoft.Json;
using MvvmQuiz.Core.Utils;

namespace MvvmQuiz.Core.Services
{
    public class UserService : IUserService
    {
        readonly IClientService _firebase;

        public UserService(IClientService clientService)
        {
            _firebase = clientService;
        }

        public async Task<bool> CreateOrUpdateUser(User user)
        {
            try
            {
                await _firebase.Client.Child(Constants.USER_CHILD)
                                      .Child(user.Id)
                                      .PutAsync(user);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: Could not create or update user");
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public Task SetCurrentUser(User user)
        {
            PreferencesHelpers.Set(nameof(User), user);
            return Task.CompletedTask;
        }

        public Task<User> CurrentUser()
        {
            return Task.FromResult(PreferencesHelpers.Get<User>(nameof(User), null));
        }

        public Task<bool> IsLoggedIn()
        {
            var user = PreferencesHelpers.Get<User>(nameof(User), null);
            return Task.FromResult(user != null);
        }

        public Task Logout()
        {
            PreferencesHelpers.Set<User>(nameof(User), null);
            return Task.CompletedTask;
        }
    }
}
