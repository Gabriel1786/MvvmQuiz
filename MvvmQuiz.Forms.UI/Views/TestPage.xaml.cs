using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmQuiz.Core.ViewModels;
using Xamarin.Forms;

namespace MvvmQuiz.Forms.UI.Views
{
    [MvxContentPagePresentation]
    public partial class TestPage : MvxContentPage<TestViewModel>
    {
        public TestPage()
        {
            InitializeComponent();
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("Tap gesture!!!");
        }

        void Handle_PinchUpdated(object sender, Xamarin.Forms.PinchGestureUpdatedEventArgs e)
        {
            System.Console.WriteLine($"Pinching at x:{e.ScaleOrigin.X} y: {e.ScaleOrigin.Y} scale: {e.Scale}");
        }
    }
}
