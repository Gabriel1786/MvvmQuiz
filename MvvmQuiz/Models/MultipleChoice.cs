using System;
using System.Collections.Generic;

namespace MvvmQuiz.Core.Models
{
    public class MultipleChoice
    {
        public string Question { get; set; }

        public string CorrectChoice { get; set; }

        public List<string> Choices { get; set; }
    }
}
