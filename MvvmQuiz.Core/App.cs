using System.Linq;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace MvvmQuiz.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var services = CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces();

            var servicesList = services.ToList();

            services.RegisterAsLazySingleton();

            RegisterCustomAppStart<AppStart>();
        }
    }
}
