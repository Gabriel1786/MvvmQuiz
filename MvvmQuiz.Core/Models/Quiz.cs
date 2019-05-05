using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MvvmQuiz.Core.Models
{
    public class Quiz
    {
        public QuizTheme Theme { get; set; }

        public List<SingleMultipleChoice> MultipleChoices { get; set; }

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
