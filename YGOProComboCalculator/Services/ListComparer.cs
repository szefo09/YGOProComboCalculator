using System.Collections.Generic;
using System.Linq;

namespace YGOProComboCalculator.Services
{
    class ListComparer
    {
        public static bool ContainsAllItems<T>(List<T> a, List<T> b)
        {
            return a.Intersect(b).Count() == b.Count();
        }
    }
}
