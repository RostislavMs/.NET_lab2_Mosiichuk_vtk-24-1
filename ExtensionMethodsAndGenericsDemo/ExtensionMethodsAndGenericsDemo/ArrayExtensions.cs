using System;
using System.Linq;

namespace ExtensionMethodsAndGenericsDemo
{
    public static class ArrayExtensions
    {
        public static int CountOccurrences<T>(this T[] array, T value) where T : IEquatable<T>
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item.Equals(value)) count++;
            }
            return count;
        }

        public static T[] GetUniqueElements<T>(this T[] array)
        {
            return array.Distinct().ToArray();
        }
    }

}
