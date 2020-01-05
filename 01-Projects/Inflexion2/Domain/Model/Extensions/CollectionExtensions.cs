namespace Inflexion2
{
    using System.Collections.Generic;

    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                target.Add(item);
            }
        }

        public static bool CollectionIsNullOrEmpty<T>( IEnumerable<T> target)
        {
            if (target == null)
            {
                return true;
            }

            if (target is ICollection<T>)
            {
                    return ((ICollection<T>)target).Count == 0;
            }

            return false;
        }

    }
}
