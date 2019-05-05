using System.Linq;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace MvvmQuiz.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var services = CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces();

            //var servicesList = services.ToList();

            SetupJsonConvert();

            services.RegisterAsLazySingleton();

            RegisterCustomAppStart<AppStart>();
        }

        private void SetupJsonConvert()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = AppConfigurations.PropertyNamesContractResolver
            };
        }
    }
}
