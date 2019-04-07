using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmQuiz.Core.ViewModels;

namespace MvvmQuiz.Forms.UI.Views
{
    [MvxContentPagePresentation]
    public partial class LoginPage : MvxContentPage<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
