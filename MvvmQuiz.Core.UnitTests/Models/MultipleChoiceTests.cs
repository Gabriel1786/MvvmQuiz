using System;
using System.Collections.Generic;
using MvvmCross.Tests;
using MvvmQuiz.Core.Models;
using NUnit.Framework;

namespace MvvmQuiz.Core.UnitTests.Models
{
    [TestFixture]
    public class MultipleChoiceTests : MvxIoCSupportingTest
    {
        protected override void AdditionalSetup()
        {
        }

        [Test, Description("UseCase: SingleMultipleChoice model if set same SelectedChoice will mark it as unselected.")]
        public void SelectedChoice_UnselectsChoiceIfAlreadySelected_ReturnsTrue()
        {
            base.Setup();

            var selectedChoice = "SomeChoice";
            var choice = new Choice { Text = selectedChoice };
            var singleMultipleChoice = new SingleMultipleChoice { Choices = new List<Choice> { choice } };

            singleMultipleChoice.SelectedChoice = selectedChoice;
            Assert.That(choice.IsSelected, Is.True);

            singleMultipleChoice.SelectedChoice = selectedChoice;
            Assert.That(choice.IsSelected, Is.False);
        }
    }
}
