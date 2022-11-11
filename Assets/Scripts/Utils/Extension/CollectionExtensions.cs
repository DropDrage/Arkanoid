using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Utils
{
    public static class CollectionExtensions
    {
        #region Emptiness

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>([NotNull] this IList<T> enumerable) => enumerable.Count == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotEmpty<T>([NotNull] this IList<T> enumerable) => enumerable.Count != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>([NotNull] this IEnumerable<T> enumerable) =>
            !enumerable.GetEnumerator().MoveNext();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotEmpty<T>([NotNull] this IEnumerable<T> enumerable) =>
            !enumerable.IsEmpty();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>([CanBeNull] this IEnumerable<T> enumerable) =>
            enumerable == null || enumerable.IsEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNullOrEmpty<T>([CanBeNull] this IEnumerable<T> enumerable) =>
            !enumerable.IsNullOrEmpty();

        #endregion
    }
}
