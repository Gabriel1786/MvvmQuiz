using System;
using System.Collections.ObjectModel;
using MvvmQuiz.Core.ViewModels;

namespace MvvmQuiz.Core.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        public TestViewModel()
        {
            Data = new ObservableCollection<string>
            {
                "Teste",
                "Teste2"
            }; 
        }

        ObservableCollection<string> _data;
        public ObservableCollection<string> Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }
    }
}
