using System.Collections.Generic;
using System.Linq;

namespace Marsman.Toolkit
{
    public static class NewList<T>
    {
        public static List<T> With(params T[] values)
        {
            return new List<T>(values);
        }

        public static List<T> With(params IEnumerable<T>[] values)
        {
            var list = new List<T>();
            foreach (var value in values)
            {
                list.AddRange(value);
            }
            return list;
        }
    }
}