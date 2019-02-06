using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmQuiz.Core.ViewModels;

namespace MvvmQuiz.Forms.UI.Views
{
    [MvxContentPagePresentation]
    public partial class HighScorePage : MvxContentPage<HighScoreViewModel>
    {
        public HighScorePage()
        {
            InitializeComponent();
        }
    }
}
