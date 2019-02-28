using System;
using MvvmCross.Commands;
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

            SubmitCommand = new MvxCommand(Submit);
            ResetCommand = new MvxCommand(Reset);
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
            set 
            {
                if (_multipleChoices != null)
                {
                    foreach (var multipleChoice in _multipleChoices)
                    {
                        multipleChoice.PropertyChanged -= MultipleChoices_PropertyChanged;
                    }
                }

                if (value != null)
                {
                    foreach (var multipleChoice in value)
                    {
                        multipleChoice.PropertyChanged += MultipleChoices_PropertyChanged;
                    }
                }

                SetProperty(ref _multipleChoices, value);
            }
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

        /// <summary>
        /// Utilizing this property instead of CanExecute in MvxCommand because apparently CanExecute is not yet supported (as of MvvmCross 6.2.3).
        /// </summary>
        /// <value><c>true</c> if can submit; otherwise, <c>false</c>.</value>
        public bool CanSubmit
        {
            get => InternalCanSubmit();
        }

        // MVVM Commands
        public IMvxCommand SubmitCommand { get; }
        public IMvxCommand ResetCommand { get; }

        // Private Methods
        void Submit()
        {
            if (!InternalCanSubmit())
                return;

            
        }

        bool InternalCanSubmit()
        {
            if (MultipleChoices.Count == 0)
                return false;

            foreach (var multipleChoice in MultipleChoices)
            {
                if (string.IsNullOrEmpty(multipleChoice.SelectedChoice))
                    return false;
            }

            return true;
        }

        void Reset()
        {
            foreach (var multipleChoice in MultipleChoices)
            {
                multipleChoice.SelectedChoice = null;

                foreach (var choice in multipleChoice.Choices)
                {
                    choice.IsSelected = false;
                }
            }

            Console.WriteLine("Reset Tapped");
        }

        void MultipleChoices_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MultipleChoice.SelectedChoice))
            {
                Console.WriteLine("RaisePropertyChanged SelectedChoice");
                RaisePropertyChanged(nameof(CanSubmit));
            }
        }
    }
}
