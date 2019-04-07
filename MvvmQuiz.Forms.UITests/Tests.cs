using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MvvmQuiz.Forms.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            if (platform == Platform.Android)
            {
                app = ConfigureApp.Android
                    .EnableLocalScreenshots()
                    .PreferIdeSettings()
                    .ApkFile("../../../../MvvmQuiz.Droid/bin/Release/MvvmQuiz_Droid.MvvmQuiz_Droid.apk")
                    .StartApp();
            }
            else if (platform == Platform.iOS)
            {
                app = ConfigureApp.iOS
                    .EnableLocalScreenshots()
                    .PreferIdeSettings()
                    .DeviceIdentifier("AFCEF309-F1E6-4966-AE48-50DBAFC96AF9") //TODO: how to detect simulator dynamically?
                    .AppBundle("../../../../MvvmQuiz.iOS/bin/iPhoneSimulator/Debug/MvvmQuiz.iOS.app")
                    .StartApp(Xamarin.UITest.Configuration.AppDataMode.Auto);
            }
        }

        [Test]
        public void AppLaunches()
        {
            //app.Repl();
            // Arrange
            AppResult[] result = app.Query(c => c.Marked("welcomeLabel"));

            // Act

            // Assert
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void NavigatesToCelebrityQuiz()
        {
            app.Tap(c => c.Marked("celebrityStartQuizButton"));

            AppResult[] result = app.Query(c => c.Marked("questionListView"));
            Assert.IsTrue(result.Any());
        }
    }
}
