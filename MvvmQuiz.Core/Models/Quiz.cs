using System;
using System.Collections.Generic;

namespace MvvmQuiz.Core.Models
{
    public class Quiz
    {
        public QuizTheme Theme { get; set; }

        public List<MultipleChoice> MultipleChoices { get; set; }

        public bool CanSubmit()
        {
            if (MultipleChoices == null || MultipleChoices.Count == 0)
                return false;

            foreach (var multipleChoice in MultipleChoices)
            {
                if (!multipleChoice.CanSubmit())
                    return false;
            }

            return true;
        }

        public void Reset()
        {
            foreach (var multipleChoice in MultipleChoices)
            {
                multipleChoice.Reset();
            }
        }
    }
}
