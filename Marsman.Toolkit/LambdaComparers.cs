using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marsman.Toolkit
{
    public static class Comparers
    {
        public LambdaComparer<T> Lambda<T>(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            return new LambdaComparer<T>(equals, getHashCode);
        }

        public PropertyComparer<T> Property<T>(Func<T, object> selector)
        {
            return new PropertyComparer<T>(selector);
        }
    }

    public class PropertyComparer<T> : IEqualityComparer<T>
    {
        private Func<T, object> _selector;

        public PropertyComparer(Func<T, object> selector)
        {
            _selector = selector;
        }
            
        public bool Equals(T x, T y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }

            var valx = _selector.Invoke(x);
            var valy = _selector.Invoke(y);

            if (valx == null && valy == null)
            {
                return true;
            }
            else if (valx == null || valy == null)
            {
                return false;
            }

            return valx.Equals(valy);
        }

        public int GetHashCode(T obj)
        {
            var val = _selector.Invoke(obj);
            return val == null ? 0 : val.GetHashCode();
        }
    }

    public class LambdaComparer<T> : IEqualityComparer<T>
    {
        private Func<T, int> _getHashCode;
        private Func<T, T, bool> _equals;

        public LambdaComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            _equals = equals;
            _getHashCode = getHashCode;
        }

        public bool Equals(T x, T y)
        {
            return _equals.Invoke(x, y);
        }

        public int GetHashCode(T obj)
        {
            return _getHashCode.Invoke(obj);
        }
    }

}
