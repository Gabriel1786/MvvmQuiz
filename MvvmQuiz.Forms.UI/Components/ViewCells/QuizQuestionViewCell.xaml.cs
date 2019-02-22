using MvvmQuiz.Core.Models;
using Xamarin.Forms;

namespace MvvmQuiz.Forms.UI.Components
{
    public partial class QuizQuestionViewCell : ViewCell
    {
        public QuizQuestionViewCell()
        {
            InitializeComponent();

            questionRadioGroup.DidSelect += (object sender, object e) => 
            {
                System.Console.WriteLine("DidSelect event fired");
                if (e is string answerSelected && BindingContext is MultipleChoice multipleChoice)
                {
                    multipleChoice.SelectedChoice = answerSelected;
                }
            };
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            System.Console.WriteLine("Cell did change context");
        }
    }
}
