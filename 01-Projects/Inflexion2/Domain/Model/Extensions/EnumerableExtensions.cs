namespace Inflexion2
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Extension methods for the <see cref="IEnumerable{T}"/> interface.
    /// </summary>
    public static class EnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            var hashSet = new HashSet<TKey>();
            return source.Where(item => hashSet.Add(keySelector(item)));
        }

        public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> source, IEnumerable<T> second, Func<T, TKey> selectKey)
        {
            var keysToExclude = new HashSet<TKey>(second.Select(selectKey));
            return source.Where(c => !keysToExclude.Contains(selectKey(c)));
        }

        public static bool UniqueBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            var hashSet = new HashSet<TKey>();
            return source.All(item => hashSet.Add(keySelector(item)));
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
    }
}
