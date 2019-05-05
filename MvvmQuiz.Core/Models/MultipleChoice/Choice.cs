using System;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace MvvmQuiz.Core.Models
{
    public class Choice : ObservableObject
    {
        public string Text { get; set; }

        bool _isSelected;
        [JsonIgnore]
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
