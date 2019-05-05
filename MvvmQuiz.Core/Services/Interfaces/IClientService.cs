using System;
using System.Threading.Tasks;
using Firebase.Database;

namespace MvvmQuiz.Core.Services.Interfaces
{
    public interface IClientService
    {
        FirebaseClient Client { get; set; }
    }
}
