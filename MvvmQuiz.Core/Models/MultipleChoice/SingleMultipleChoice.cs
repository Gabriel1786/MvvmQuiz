using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace MvvmQuiz.Core.Models
{
    /// <summary>
    /// A multiple choice question with only 1 selectable answer.
    /// </summary>
    public class SingleMultipleChoice : MultipleChoice
    {
        public string CorrectChoice { get; set; }

        string _selectedChoice;
        public string SelectedChoice
        {
            get => _selectedChoice;
            set
            {
                foreach (var choice in Choices)
                {
                    if (choice.Text.Equals(value, StringComparison.InvariantCulture))
                    {
                        choice.IsSelected = !choice.IsSelected;
                    }
                    else
                    {
                        choice.IsSelected = false;
                    }
                }

                if (_selectedChoice != null && _selectedChoice.Equals(value, StringComparison.InvariantCulture))
                    value = null;

                SetProperty(ref _selectedChoice, value);
            }
        }

        public bool IsCorrectChoice()
        {
            return CorrectChoice.Equals(SelectedChoice, StringComparison.InvariantCulture);
        }
    }
}
