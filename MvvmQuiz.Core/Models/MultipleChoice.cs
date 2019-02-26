using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace MvvmQuiz.Core.Models
{
    public class MultipleChoice : ObservableObject
    {
        public string Question { get; set; }

        public string CorrectChoice { get; set; }

        public List<Choice> Choices { get; set; }

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
                        if (choice.IsSelected)
                            choice.IsSelected = false;
                        else
                            choice.IsSelected = true;
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
