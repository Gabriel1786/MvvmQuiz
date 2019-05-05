using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database.Query;
using MvvmCross;
using MvvmQuiz.Core.Extensions;
using MvvmQuiz.Core.Models;
using MvvmQuiz.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace MvvmQuiz.Core.Services
{
    #region Firebase
    public class QuizService : IQuizService
    {
        readonly IClientService _clientService;

        public QuizService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<Quiz> GetQuiz(QuizTheme theme)
        {
            string quizThemePath = string.Empty;
            switch (theme)
            {
                case QuizTheme.Celebrity:
                    quizThemePath = Constants.CELEBRITY_CHILD;
                    break;
                case QuizTheme.Country:
                    quizThemePath = Constants.COUNTRY_CHILD;
                    break;
                case QuizTheme.Movie:
                    quizThemePath = Constants.MOVIE_CHILD;
                    break;
            }

            try
            {
                var result = await _clientService.Client.Child(Constants.QUIZ_CHILD)
                                                    .Child(quizThemePath)
                                                    .OnceSingleAsync<Quiz>();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
    #endregion

    #region Mock
    public class MockQuizService //: IQuizService
    {
        public Task<Quiz> GetQuiz(QuizTheme theme)
        {
            switch (theme)
            {
                case QuizTheme.Celebrity:
                    return CelebrityQuiz();
                case QuizTheme.Country:
                    return CountryQuiz();
                case QuizTheme.Movie:
                    return MovieQuiz();
            }

            return null;
        }

        // Private Methods
        private Task<Quiz> CelebrityQuiz()
        {
            var quiz = new Quiz
            {
                Theme = QuizTheme.Celebrity,
                MultipleChoices = new List<SingleMultipleChoice>
                {
                    new SingleMultipleChoice
                    {
                        Question = "He shocked the industry when he named his first child Pilot Inspektor.",
                        CorrectChoice = "Jason Lee",
                        Choices = new List<Choice> { new Choice { Text = "Hugh Jackman" },
                                                     new Choice { Text = "Jason Lee" },
                                                     new Choice { Text = "Matthew McConaughey" },
                                                     new Choice { Text = "Ben Affleck" }}
                    },
                    new SingleMultipleChoice
                    {
                        Question = "She faced major criticism for wearing blackface to dress up as Crazy Eyes from \"Orange Is the New Black\" for Halloween in 2013.",
                        CorrectChoice = "Julianne Hough",
                        Choices = new List<Choice> { new Choice { Text = "Kim Kardashian" },
                                                     new Choice { Text = "Christina Aguilera" },
                                                     new Choice { Text = "Miley Cyrus" },
                                                     new Choice { Text = "Julianne Hough" }}
                    },
                    new SingleMultipleChoice
                    {
                        Question = "This actress was caught cheating on her longtime boyfriend with the married director of a film she starred in.",
                        CorrectChoice = "Kristen Stewart",
                        Choices = new List<Choice> { new Choice { Text = "Kristen Stewart" },
                                                     new Choice { Text = "Jennifer Lawrence" },
                                                     new Choice { Text = "Blake Lively" },
                                                     new Choice { Text = "Scarlett Johansson" }}
                    },
                    new SingleMultipleChoice
                    {
                        Question = "On the eve of the 2012 Grammy Awards, this singer died of a drug overdose.",
                        CorrectChoice = "Whitney Houston",
                        Choices = new List<Choice> { new Choice { Text = "Aaliyah" },
                                                     new Choice { Text = "Amy Winehouse" },
                                                     new Choice { Text = "Whitney Houston" },
                                                     new Choice { Text = "Selena" }}
                    },
                    new SingleMultipleChoice
                    {
                        Question = "He stripped down to his boxers on stage at the 2014 Fashion Rocks and received nothing but boos.",
                        CorrectChoice = "Justin Bieber",
                        Choices = new List<Choice> { new Choice { Text = "Justin Bieber" },
                                                     new Choice { Text = "Harry Styles" },
                                                     new Choice { Text = "Usher" },
                                                     new Choice { Text = "Chris Brown" }}
                    },
                    new SingleMultipleChoice
                    {
                        Question = "This actress was arrested on a disorderly conduct charge after refusing to stay in her car while her husband was given a sobriety test.",
                        CorrectChoice = "Reese Witherspoon",
                        Choices = new List<Choice> { new Choice { Text = "Lindsay Lohan" },
                                                     new Choice { Text = "Paris Hilton" },
                                                     new Choice { Text = "Reese Witherspoon" },
                                                     new Choice { Text = "Jessica Simpson" }}
                    },
                    new SingleMultipleChoice
                    {
                        Question = "He found himself at the center of a scandal when a 17-year-old fan claimed this actor arranged to meet her at a hotel room after they exchanged messages on Instagram.",
                        CorrectChoice = "James Franco",
                        Choices = new List<Choice> { new Choice { Text = "Adam Levine" },
                                                     new Choice { Text = "Dave Franco" },
                                                     new Choice { Text = "Zach Efron" },
                                                     new Choice { Text = "James Franco" }}
                    }
                }
            };


            //TODO: removeme
            //var json = JsonConvert.SerializeObject(quiz);
            //var _clientService = Mvx.IoCProvider.Resolve<IClientService>();
            //var result = _clientService.Client.Child(Constants.QUIZ_CHILD)
            //                                  .Child("celebrity")
            //                                  .PutAsync(json);
            //Console.WriteLine(result);

            ShuffleQuestionsAndAnswers(quiz);

            return Task.FromResult(quiz);
        }

        private Task<Quiz> CountryQuiz()
        {
            var quiz = new Quiz
            {
                Theme = QuizTheme.Country,
                MultipleChoices = new List<SingleMultipleChoice>
                {
                    new SingleMultipleChoice
                    {
                        Question = "",
                        CorrectChoice = "",
                        Choices = new List<Choice> { new Choice(), new Choice(), new Choice(), new Choice() }
                    }
                }
            };

            ShuffleQuestionsAndAnswers(quiz);

            return Task.FromResult(quiz);
        }

        private Task<Quiz> MovieQuiz()
        {
            var quiz = new Quiz
            {
                Theme = QuizTheme.Movie,
                MultipleChoices = new List<SingleMultipleChoice>
                {
                    new SingleMultipleChoice
                    {
                        Question = "",
                        CorrectChoice = "",
                        Choices = new List<Choice> { new Choice(), new Choice(), new Choice(), new Choice() }
                    }
                }
            };

            ShuffleQuestionsAndAnswers(quiz);

            return Task.FromResult(quiz);
        }

        private void ShuffleQuestionsAndAnswers(Quiz quiz)
        {
            foreach (var multipleChoice in quiz.MultipleChoices)
            {
                multipleChoice.Choices.Shuffle();
            }

            quiz.MultipleChoices.Shuffle();
        }
    }
    #endregion
}
