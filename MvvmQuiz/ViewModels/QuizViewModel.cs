using System;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Services;

namespace MvvmQuiz.Core.ViewModels
{
    public class QuizViewModel : BaseViewModel, IMvxViewModel<QuizTheme>
    {
        readonly IMvxNavigationService _navigationService;
        readonly IQuizService _quizService;

        public QuizViewModel(IMvxNavigationService navigationService, IQuizService quizService)
        {
            _navigationService = navigationService;
            _quizService = quizService;
        }

        // MvvmCross Lifecycle
        async void IMvxViewModel<QuizTheme>.Prepare(QuizTheme parameter)
        {
            Quiz = await _quizService.GetQuiz(parameter);
        }

        // MVVM Properties
        MvxObservableCollection<MultipleChoice> _multipleChoices;
        public MvxObservableCollection<MultipleChoice> MultipleChoices
        {
            get => _multipleChoices;
            set => SetProperty(ref _multipleChoices, value);
        }

        Quiz _quiz;
        public Quiz Quiz
        {
            get => _quiz;
            set
            {
                MultipleChoices = new MvxObservableCollection<MultipleChoice>(value.MultipleChoices);
                SetProperty(ref _quiz, value);
            }
        }

        // MVVM Commands

        // Private Methods
    }
}
