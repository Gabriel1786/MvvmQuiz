using System;
using System.IO;
using System.Reflection;
using MvvmCross.Tests;
using MvvmQuiz.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MvvmQuiz.Core.UnitTests.Models
{
    [TestFixture]
    public class ParseTests : MvxIoCSupportingTest
    {
        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();

            SetupJsonConverter();
        }

        void SetupJsonConverter()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = AppConfigurations.PropertyNamesContractResolver
            };
        }

        [Test]
        public void Parse_QuizModel_ReturnsObject()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "MvvmQuiz.Core.UnitTests.Files.quiz_response.json";
            string json = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            Assert.That(json, Is.Not.Empty);

            var quizModel = JsonConvert.DeserializeObject<Quiz>(json);

            Assert.That(quizModel, Is.Not.Null);
            Assert.That(quizModel.MultipleChoices.Count, Is.GreaterThan(0));
            Assert.That(quizModel.MultipleChoices[0].Choices.Count, Is.GreaterThan(0));
            Assert.That(quizModel.MultipleChoices[0].CorrectChoice, Is.Not.Empty);
        }
    }
}
