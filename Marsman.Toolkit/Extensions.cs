using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Marsman.Toolkit
{
    public static class Extensions
    {
        public static class Extensions
        {
            public static List<T> PickRandom<T>(this List<T> input, int count)
            {
                var result = new List<T>();
                var rand = new Random();
                for (int i = 0; i < count; i++)
                {
                    result.Add(input[rand.Next(input.Count)]);
                }
                return result;
            }

            public static List<T> Shuffle<T>(this List<T> input, int count)
            {
                var result = new List<T>();
                var indexes = new List<int>();
                for (int i = 0; i < input.Count; i++)
                {
                    indexes.Add(i);
                }
                var rand = new Random();
                for (int i = 0; i < input.Count; i++)
                {
                    int index = indexes[rand.Next(indexes.Count)];
                    indexes.Remove(index);
                    result.Add(input[index]);
                }
                return result;
            }
        }
    }

}
