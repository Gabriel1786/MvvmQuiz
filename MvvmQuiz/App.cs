﻿using System;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmQuiz.Core.ViewModels;

namespace MvvmQuiz.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterCustomAppStart<AppStart>();
        }
    }
}
