using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProComboCalculator.Services
{
    public class ValueCounter<T> : IEnumerable<KeyValuePair<T, int>>
    {
        private readonly Dictionary<T, int> _valueCounter;
        private int _nullCount;

        public ValueCounter(IEnumerable<T> values,
                            IEqualityComparer<T> comparer)
        {
            // double ? operator don't works in syntax highlighter,
            // so I used the ?: operator to display correct
            _valueCounter = new Dictionary<T, int>
                (comparer != null ? comparer : EqualityComparer<T>.Default);
            if (values == null)
                return;
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public ValueCounter(IEqualityComparer<T> comparer)
            : this(null, comparer)
        {
        }

        public ValueCounter(IEnumerable<T> values)
            : this(values, null)
        {
        }

        public ValueCounter()
            : this(null, null)
        {
        }

        public void Add(T value)
        {
            if (value == null)
            {
                _nullCount++;
            }
            else
            {
                int count;
                if (_valueCounter.TryGetValue(value, out count))
                {
                    // Double lookup is faster then creating a StrongBox
                    _valueCounter[value] = count + 1;
                }
                else
                {
                    _valueCounter.Add(value, 1);
                }
            }
        }

        public bool Remove(T value)
        {
            if (value == null)
            {
                if (_nullCount > 0)
                {
                    _nullCount--;
                    return true;
                }
            }
            else
            {
                int count;
                if (_valueCounter.TryGetValue(value, out count))
                {
                    if (count == 0)
                    {
                        return false;
                    }
                    // Double lookup is faster then creating a StrongBox
                    _valueCounter[value] = count - 1;
                    return true;
                }
            }
            return false;
        }

        public int GetCount(T value)
        {
            if (value == null)
            {
                return _nullCount;
            }
            int result;
            _valueCounter.TryGetValue(value, out result);
            return result;
        }

        public IEnumerator<KeyValuePair<T, int>> GetEnumerator()
        {
            return _valueCounter.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
