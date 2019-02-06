using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmQuiz.Core.ViewModels;

namespace MvvmQuiz.Forms.UI.Views
{
    [MvxContentPagePresentation]
    public partial class QuizPage : MvxContentPage<QuizViewModel>
    {
        public QuizPage()
        {
            InitializeComponent();
        }
    }
}
