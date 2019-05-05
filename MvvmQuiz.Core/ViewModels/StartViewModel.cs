using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Services;

namespace MvvmQuiz.Core.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;
        readonly IUserService _userService;
        readonly IQuizService _quizService;

        public StartViewModel(IMvxNavigationService navigationService, IUserService userService, IQuizService quizService)
        {
            _navigationService = navigationService;
            _userService = userService;
            _quizService = quizService;

            ShowQuizViewModelCommand = new MvxAsyncCommand<QuizTheme>(ShowQuizViewModel, null, allowConcurrentExecutions: true);
            ShowHighScoreViewModelCommand = new MvxAsyncCommand(ShowHighScoreViewModel);
            ShowLoginViewModelCommand = new MvxAsyncCommand(ShowLoginViewModel);
        }

        // MvvmCross Lifecycle
        public override async Task Initialize()
        {
            await VerifyLoginStatus();
        }

        // MVVM Properties
        string _loginButtonTitle;
        public string LoginButtonTitle
        {
            get => _loginButtonTitle;
            set => SetProperty(ref _loginButtonTitle, value);
        }

        // MVVM Commands
        public IMvxAsyncCommand<QuizTheme> ShowQuizViewModelCommand { get; }
        public IMvxAsyncCommand ShowHighScoreViewModelCommand { get; }
        public IMvxAsyncCommand ShowLoginViewModelCommand { get; }

        // Private Methods
        private async Task VerifyLoginStatus()
        {
            LoginButtonTitle = await _userService.IsLoggedIn() ? "Logout" : "Login";
        }

        private async Task ShowQuizViewModel(QuizTheme theme)
        {
            try
            {
                if (await _userService.IsLoggedIn())
                {
                    Console.WriteLine($"Starting quiz: {theme}");
                    var quiz = await _quizService.GetQuiz(theme);
                    if (quiz != null)
                    {
                        await _navigationService.Navigate<QuizViewModel, Quiz>(quiz);
                    }
                }
                else
                {
                    //TODO: alert user?
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task ShowHighScoreViewModel()
        {
            try
            {
                if (await _userService.IsLoggedIn())
                {
                    await _navigationService.Navigate<HighScoreViewModel>();
                }
                else
                {
                    //TODO: alert user?
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task ShowLoginViewModel()
        {
            try
            {
                if (await _userService.IsLoggedIn())
                {
                    await _userService.Logout();
                    LoginButtonTitle = "Login";
                }
                else
                {
                    await _navigationService.Navigate<LoginViewModel>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
