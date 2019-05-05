using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Services;

namespace MvvmQuiz.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;
        readonly ILoginService _loginService;
        readonly IUserService _userService;

        public LoginViewModel(IMvxNavigationService navigationService, ILoginService loginService, IUserService userService)
        {
            _navigationService = navigationService;
            _loginService = loginService;
            _userService = userService;

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
            var user = await _loginService.FacebookLogin();
            await InternalLogin(user);
        }

        async Task GoogleLogin()
        {
            var user = await _loginService.GoogleLogin();
            await InternalLogin(user);
        }

        async Task InternalLogin(User user)
        {
            if (user == null)
            {
                return;
            }

            var result = await _userService.CreateOrUpdateUser(user);
            if (result)
            {
                await _userService.SetCurrentUser(user);
            }

            await _navigationService.Close(this);
        }
    }
}
