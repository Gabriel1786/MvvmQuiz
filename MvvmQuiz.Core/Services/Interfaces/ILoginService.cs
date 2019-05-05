using System;
using System.Threading.Tasks;
using MvvmQuiz.Core.Models;
using Xamarin.Auth;

namespace MvvmQuiz.Core.Services
{
    public interface ILoginService
    {
        OAuth2Authenticator Authenticator { get; set; }

        Task<User> FacebookLogin();
        Task<User> GoogleLogin();
        Task<User> LoginFirebase(string token, Firebase.Auth.FirebaseAuthType firebaseAuthType);
    }
}
