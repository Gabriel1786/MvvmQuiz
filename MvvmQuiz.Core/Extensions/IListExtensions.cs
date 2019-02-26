using System;
using System.Collections.Generic;

namespace MvvmQuiz.Core.Extensions
{
    public static class IListExtensions
    {
        /// <summary>
        /// Shuffle the specified list. Fisher-Yates shuffle.
        /// </summary>
        /// <param name="list">List.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
