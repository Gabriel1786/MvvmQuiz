using System;
using MvvmCross.Navigation;

namespace MvvmQuiz.Core.ViewModels
{
    public class HighScoreViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;

        public HighScoreViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands

        // Private Methods
    }
}
