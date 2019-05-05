using System;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace MvvmQuiz.Core.Utils
{
    public static class PreferencesHelpers
    {
        public static T Get<T>(string key, T @default) where T : class
        {
            var serialized = Preferences.Get(key, string.Empty);
            var result = @default;

            try
            {
                result = JsonConvert.DeserializeObject<T>(serialized);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deserializing settings value: {ex}");
            }

            return result;
        }

        public static void Set<T>(string key, T obj) where T : class
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(obj);

                Preferences.Set(key, serialized);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error serializing settings value: {ex}");
            }
        }
    }
}
