﻿using MvvmCross.Forms.Platforms.Uap.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MvvmQuiz.UWP
{
    public sealed partial class App : WinApp
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class WinApp : MvxWindowsApplication<Setup, Core.App, Forms.UI.App, MainPage>
    {
    }
}
