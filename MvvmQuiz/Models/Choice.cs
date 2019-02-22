using System;
using MvvmCross.ViewModels;

namespace MvvmQuiz.Core.Models
{
    public class Choice : ObservableObject
    {
        public string Text { get; set; }

        bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
