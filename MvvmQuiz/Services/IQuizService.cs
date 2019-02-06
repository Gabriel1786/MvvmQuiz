using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmQuiz.Core.Models;

namespace MvvmQuiz.Core.Services
{
    public interface IQuizService
    {
        Task<Quiz> GetQuiz(QuizTheme theme);
    }
}
