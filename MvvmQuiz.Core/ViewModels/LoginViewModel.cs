using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmQuiz.Core.Services;

namespace MvvmQuiz.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;
        readonly ILoginService _loginService;

        public LoginViewModel(IMvxNavigationService navigationService, ILoginService loginService)
        {
            _navigationService = navigationService;
            _loginService = loginService;

            FacebookLoginCommand = new MvxAsyncCommand(FacebookLogin, null, true);
            GoogleLoginCommand = new MvxAsyncCommand(GoogleLogin, null, true);
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public MvxAsyncCommand FacebookLoginCommand { get; }
        public MvxAsyncCommand GoogleLoginCommand { get; }

        // Private Methods
        async Task FacebookLogin()
        {
            var result = await _loginService.FacebookLogin();
            if (result)
            {
                await _navigationService.Close(this);
            }
        }

        async Task GoogleLogin()
        {
            var result = await _loginService.GoogleLogin();
            if (result)
            {
                await _navigationService.Close(this);
            }
        }
    }
}
