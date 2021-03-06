﻿using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmQuiz.Core.ViewModels;

namespace MvvmQuiz.Forms.UI.Views
{
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class StartPage : MvxContentPage<StartViewModel>
    {
        public StartPage()
        {
            InitializeComponent();
        }
    }
}
