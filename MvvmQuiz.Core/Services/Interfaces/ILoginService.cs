using System;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace MvvmQuiz.Core.Services
{
    public interface ILoginService
    {
        OAuth2Authenticator Authenticator { get; set; }

        Task<bool> FacebookLogin();
        Task<bool> GoogleLogin();
    }
}
