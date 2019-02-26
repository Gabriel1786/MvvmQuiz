using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MvvmQuiz.Core.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;

        public StartViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowQuizViewModelCommand = new MvxAsyncCommand<QuizTheme>(ShowQuizViewModel);
            ShowHighScoreViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HighScoreViewModel>());
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxAsyncCommand<QuizTheme> ShowQuizViewModelCommand { get; }
        public IMvxAsyncCommand ShowHighScoreViewModelCommand { get; }

        // Private Methods
        private async Task ShowQuizViewModel(QuizTheme theme)
        {
            await _navigationService.Navigate<QuizViewModel, QuizTheme>(theme);
        }
    }
}
