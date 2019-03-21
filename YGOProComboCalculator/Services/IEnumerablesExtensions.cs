using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProComboCalculator.Services
{
    static class IEnumerablesExtensions
    {
        public static IEnumerable<TSource> ExceptAll<TSource>(
this IEnumerable<TSource> first,
IEnumerable<TSource> second)
        {
            return ExceptAll(first, second, null);
        }

        public static IEnumerable<TSource> ExceptAll<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null) { throw new ArgumentNullException("first"); }
            if (second == null) { throw new ArgumentNullException("second"); }

            return ExceptAllImplementation(first, second, comparer);
        }

        private static IEnumerable<TSource> ExceptAllImplementation<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {

            var valueCounter = new ValueCounter<TSource>(second, comparer);

            // Do not convert to Where, this enumerates wrong the second time
            foreach (TSource s in first)
            {
                if (!valueCounter.Remove(s))
                {
                    yield return s;
                }
            }
        }

        public static IEnumerable<TSource> IntersectAll<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            return IntersectAll(first, second, null);
        }

        public static IEnumerable<TSource> IntersectAll<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null) { throw new ArgumentNullException("first"); }
            if (second == null) { throw new ArgumentNullException("second"); }

            return IntersectAllImplementation(first, second, comparer);
        }

        private static IEnumerable<TSource> IntersectAllImplementation<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {

            var valueCounter = new ValueCounter<TSource>(second, comparer);

            // Do not convert to Where, this enumerates wrong the second time
            foreach (TSource s in first)
            {
                if (valueCounter.Remove(s))
                {
                    yield return s;
                }
            }
        }

        public static IEnumerable<TSource> UnionAll<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            return UnionAll(first, second, null);
        }

        public static IEnumerable<TSource> UnionAll<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null) { throw new ArgumentNullException("first"); }
            if (second == null) { throw new ArgumentNullException("second"); }

            var firstCache = first.ToList();
            return firstCache.Concat(second.ExceptAll(firstCache, comparer));
        }
    }
}
