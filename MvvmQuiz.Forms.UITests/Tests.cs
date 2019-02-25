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
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Repl();
            // Arrange
            AppResult[] result = app.Query(c => c.Marked("welcomeLabel"));

            // Act

            // Assert
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void NavigatesToCelebrityQuiz()
        {
            app.Repl();

            app.Tap(c => c.Marked("celebrityStartQuizButton"));

            AppResult[] result = app.Query(c => c.Marked("questionListView"));
            Assert.IsTrue(result.Any());
        }
    }
}
