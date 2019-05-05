using System;
using System.Collections.Generic;
using Moq;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Services;
using MvvmQuiz.Core.ViewModels;
using NUnit.Framework;

namespace MvvmQuiz.Core.UnitTests.ViewModels
{
    [TestFixture]
    public class QuizViewModelTests : MvxIoCSupportingTest
    {
        QuizViewModel _quizViewModel;
        Mock<IMvxNavigationService> _mvxNavigationService;
        Mock<IQuizService> _quizService;

        protected override void AdditionalSetup()
        {
            _mvxNavigationService = new Mock<IMvxNavigationService>();
            _quizService = new Mock<IQuizService>();
            _quizViewModel = new QuizViewModel(_mvxNavigationService.Object, _quizService.Object);
        }

        [Test, Description("UseCase: A user may submit a quiz with all questions answered.")]
        public void CanSubmit_MultipleChoicesFullyFilled_ReturnsTrue()
        {
            base.Setup();

            var quiz = new Quiz
            {
                MultipleChoices = new List<SingleMultipleChoice>
                {
                    new SingleMultipleChoice { Choices = new List<Choice> { new Choice { Text = "Choice 1" }}, SelectedChoice = "SomeChoice" },
                    new SingleMultipleChoice { Choices = new List<Choice> { new Choice { Text = "Choice 1" }}, SelectedChoice = "SelectedChoice" }
                }
            };

            _quizViewModel.Quiz = quiz;

            var result = _quizViewModel.CanSubmit;
            Assert.That(result, Is.True);
        }

        [Test, Description("UseCase: A user may not submit a quiz with unanswered questions.")]
        public void CanSubmit_MultipleChoicesPartiallyFilled_ReturnsFalse()
        {
            base.Setup();

            var quiz = new Quiz
            {
                MultipleChoices = new List<SingleMultipleChoice>
                {
                    new SingleMultipleChoice { Choices = new List<Choice> { new Choice { Text = "Choice 1" }}, SelectedChoice = "SomeChoice" },
                    new SingleMultipleChoice { Choices = new List<Choice> { new Choice { Text = "Choice 1" }}, SelectedChoice = null }
                }
            };

            _quizViewModel.Quiz = quiz;
            
            var result = _quizViewModel.CanSubmit;
            Assert.That(result, Is.False);
        }
    }
}
