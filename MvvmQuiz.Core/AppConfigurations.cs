using System;
using Newtonsoft.Json.Serialization;

namespace MvvmQuiz.Core
{
    public static class AppConfigurations
    {
        // Authentication
        public static string FacebookAppId { get; set; }
        public static string FacebookRedirectUrl { get; set; }
        public static string GoogleClientId { get; set; }
        public static string GoogleRedirectUrl { get; set; }
        public static string FirebaseApiKey { get; set; }

        // Newtonsoft Parser
        public static IContractResolver PropertyNamesContractResolver => new CamelCasePropertyNamesContractResolver();
    }
}
