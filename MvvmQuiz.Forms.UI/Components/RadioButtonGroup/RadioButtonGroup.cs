using System;
using Xamarin.Forms;

namespace MvvmQuiz.Forms.UI.Components
{
    public class RadioButtonGroup : StackLayout
    {
        public event EventHandler<object> DidSelect;

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child is View view)
            {
                var tap = new TapGestureRecognizer
                {
                    Command = new Command<View>(HandleTap),
                    CommandParameter = view
                };

                view.GestureRecognizers.Add(tap);
            }
        }

        protected override void OnChildRemoved(Element child)
        {
            base.OnChildRemoved(child);

            if (child is View view)
            {
                view.GestureRecognizers.Clear();
            }
        }

        void HandleTap(View view)
        {
            DidSelect?.Invoke(this, view.BindingContext);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}
