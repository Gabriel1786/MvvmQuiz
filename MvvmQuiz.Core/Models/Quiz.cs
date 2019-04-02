using System;
using System.Collections.Generic;

namespace MvvmQuiz.Core.Models
{
    public class Quiz
    {
        public QuizTheme Theme { get; set; }

        public List<SingleMultipleChoice> MultipleChoices { get; set; }
    }
}
