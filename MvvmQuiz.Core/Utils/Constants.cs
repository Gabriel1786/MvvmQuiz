using System;

namespace MvvmQuiz.Core
{
    public static class Constants
    {
        // Preference Keys
        public const string AUTH_TOKEN = "auth_token";
        public const string AUTH_RESULT = "auth_result";

        // Firebase Database
        public const string DATABASE_URL = "https://mvvmquiz.firebaseio.com/";
        public const string USER_CHILD = "users";
        public const string QUIZ_CHILD = "quiz";
        public const string CELEBRITY_CHILD = "celebrity";
        public const string MOVIE_CHILD = "movie";
        public const string COUNTRY_CHILD = "country";
    }
}
