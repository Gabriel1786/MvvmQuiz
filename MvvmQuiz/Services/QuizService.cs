using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmQuiz.Core.Extensions;
using MvvmQuiz.Core.Models;

namespace MvvmQuiz.Core.Services
{
    public class QuizService : IQuizService
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
                MultipleChoices = new List<MultipleChoice>
                {
                    new MultipleChoice
                    {
                        Question = "He shocked the industry when he named his first child Pilot Inspektor.",
                        CorrectChoice = "Jason Lee",
                        Choices = new List<string> { "Hugh Jackman", "Jason Lee", "Matthew McConaughey", "Ben Affleck" }
                    },
                    new MultipleChoice
                    {
                        Question = "She faced major criticism for wearing blackface to dress up as Crazy Eyes from \"Orange Is the New Black\" for Halloween in 2013.",
                        CorrectChoice = "Julianne Hough",
                        Choices = new List<string> { "Kim Kardashian", "Christina Aguilera", "Miley Cyrus", "Julianne Hough" }
                    },
                    new MultipleChoice
                    {
                        Question = "This actress was caught cheating on her longtime boyfriend with the married director of a film she starred in.",
                        CorrectChoice = "Kristen Stewart",
                        Choices = new List<string> { "Kristen Stewart", "Jennifer Lawrence", "Blake Lively", "Scarlett Johansson" }
                    },
                    new MultipleChoice
                    {
                        Question = "On the eve of the 2012 Grammy Awards, this singer died of a drug overdose.",
                        CorrectChoice = "Whitney Houston",
                        Choices = new List<string> { "Aaliyah", "Amy Winehouse", "Whitney Houston", "Selena" }
                    },
                    new MultipleChoice
                    {
                        Question = "He stripped down to his boxers on stage at the 2014 Fashion Rocks and received nothing but boos.",
                        CorrectChoice = "Justin Bieber",
                        Choices = new List<string> { "Justin Bieber", "Harry Styles", "Usher", "Chris Brown" }
                    },
                    new MultipleChoice
                    {
                        Question = "This actress was arrested on a disorderly conduct charge after refusing to stay in her car while her husband was given a sobriety test.",
                        CorrectChoice = "Reese Witherspoon",
                        Choices = new List<string> { "Lindsay Lohan", "Paris Hilton", "Reese Witherspoon", "Jessica Simpson" }
                    },
                    new MultipleChoice
                    {
                        Question = "He found himself at the center of a scandal when a 17-year-old fan claimed this actor arranged to meet her at a hotel room after they exchanged messages on Instagram.",
                        CorrectChoice = "James Franco",
                        Choices = new List<string> { "Adam Levine", "Dave Franco", "Zach Efron", "James Franco" }
                    }
                }
            };

            ShuffleQuestionsAndAnswers(quiz);

            return Task.FromResult(quiz);
        }

        private Task<Quiz> CountryQuiz()
        {
            var quiz = new Quiz
            {
                Theme = QuizTheme.Country,
                MultipleChoices = new List<MultipleChoice>
                {
                    new MultipleChoice
                    {
                        Question = "",
                        CorrectChoice = "",
                        Choices = new List<string> { "", "", "", "" }
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
                MultipleChoices = new List<MultipleChoice>
                {
                    new MultipleChoice
                    {
                        Question = "",
                        CorrectChoice = "",
                        Choices = new List<string> { "", "", "", "" }
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
}
