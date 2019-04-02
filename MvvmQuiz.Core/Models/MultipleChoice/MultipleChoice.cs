using System;
using System.Collections.Generic;

namespace MvvmQuiz.Core.Models
{
    /// <summary>
    /// Base class for a MultipleChoice.
    /// </summary>
    public abstract class MultipleChoice : ObservableObject
    {
        public string Question { get; set; }

        public List<Choice> Choices { get; set; }
    }
}
