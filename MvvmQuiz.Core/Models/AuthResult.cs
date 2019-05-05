using System;

namespace MvvmQuiz.Core.Models
{
    public class AuthResult
    {
        public Firebase.Auth.FirebaseAuthType AuthType { get; set; }

        public string AccessToken { get; set; }

        public Firebase.Auth.FirebaseAuth Auth { get; set; }
    }
}
