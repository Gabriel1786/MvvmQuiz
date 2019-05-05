using System;
using System.Threading.Tasks;
using MvvmQuiz.Core.Models;

namespace MvvmQuiz.Core.Services
{
    public interface IUserService
    {
        Task<bool> CreateOrUpdateUser(User user);
        Task<bool> IsLoggedIn();
        Task<User> CurrentUser();
        Task SetCurrentUser(User user);
        Task Logout();
    }
}
