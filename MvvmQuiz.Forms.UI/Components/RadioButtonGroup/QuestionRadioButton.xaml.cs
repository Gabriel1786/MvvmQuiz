using System;
using System.Threading.Tasks;
using MvvmQuiz.Core.Models;
using Xamarin.Forms;

namespace MvvmQuiz.Forms.UI.Components
{
    public partial class QuestionRadioButton : StackLayout
    {
        public QuestionRadioButton()
        {
            InitializeComponent();

            Setup();
        }

        async void Setup()
        {
            await Task.Delay(10); // this small delay makes it so it renders the lottie view on view appear

            if (BindingContext is Choice choice)
            {
                if (choice.IsSelected)
                    choiceCheckAnimation.PlayProgressSegment(0.8f, 0.8f);
                else
                    choiceCheckAnimation.PlayProgressSegment(0.25f, 0.25f);
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is Choice choice)
            {
                Console.WriteLine("QuestionRadioButton did change context");

                choice.PropertyChanged += Choice_PropertyChanged;

                if (choiceCheckAnimation.IsPlaying)
                    choiceCheckAnimation.Pause();

                if (choice.IsSelected)
                    choiceCheckAnimation.PlayProgressSegment(0.8f, 0.8f);
                else
                    choiceCheckAnimation.PlayProgressSegment(0.25f, 0.25f);
            }
        }

        void Choice_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Choice.IsSelected))
            {
                if (BindingContext is Choice choice)
                {
                    Console.WriteLine("Choice_PropertyChanged");

                    if (choiceCheckAnimation.IsPlaying)
                        choiceCheckAnimation.Pause();

                    if (choice.IsSelected)
                        choiceCheckAnimation.PlayProgressSegment(0.25f, 0.8f);
                    else
                        choiceCheckAnimation.PlayProgressSegment(0.25f, 0.25f);
                }
            }
        }
    }
}