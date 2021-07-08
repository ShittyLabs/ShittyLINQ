using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> OrderBy<T, k>(this IEnumerable<T> source, Func<T, k> keySelector)
        {
            return OrderedEnumerable(source, keySelector, null, false);
        }
        public static IEnumerable<T> OrderBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> comparer)
        {
            return OrderedEnumerable(source, keySelector, comparer, false);
        }
        private static IEnumerable<T> OrderedEnumerable<T, K>(IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> comparer,bool descending)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            List<T> buffer = new List<T>();
            Sortable<T, K> sortable = new Sortable<T, K>(keySelector, comparer, descending);
            int count = (int)source.Count();
            sortable.ComputeKeys(source.ToList().ToArray(), count);

            int[] map = new int[count];
            for (int i = 0; i < count; i++) map[i] = i;
            sortable.QuickSort(map, 0, count - 1);
            for (int i = 0; i < source.Count(); i++)
                buffer.Add(source.ElementAt(map[i]));

            return buffer;
        }
        private class Sortable<T, K>
        {
            private Func<T, K> keySelector;
            private IComparer<K> comparer;
            private K[] keys;
            private bool descending;


            public Sortable(Func<T, K> keySelector, IComparer<K> comparer, bool descending)
            {
                this.keySelector = keySelector;
                this.comparer = comparer ?? Comparer<K>.Default;
                this.descending = descending;
            }
            internal void QuickSort(int[] map, int left, int right)
            {
                do
                {
                    int i = left;
                    int j = right;
                    int x = map[i + ((j - i) >> 1)];
                    do
                    {
                        while (i < map.Length && CompareKeys(x, map[i]) > 0) i++;
                        while (j >= 0 && CompareKeys(x, map[j]) < 0) j--;
                        if (i > j) break;
                        if (i < j)
                        {
                            int temp = map[i];
                            map[i] = map[j];
                            map[j] = temp;
                        }
                        i++;
                        j--;
                    } while (i <= j);
                    if (j - left <= right - i)
                    {
                        if (left < j) QuickSort(map, left, j);
                        left = i;
                    }
                    else
                    {
                        if (i < right) QuickSort(map, i, right);
                        right = j;
                    }
                } while (left < right);
            }

            internal void ComputeKeys(T[] elements, int count)
            {
                keys = new K[count];
                for (int i = 0; i < count; i++) keys[i] = keySelector(elements[i]);
            }
            internal int CompareKeys(int index1, int index2)
            {
                int c = comparer.Compare(keys[index1], keys[index2]);
                if (c == 0)
                {
                     return index1 - index2;
                }
                return descending ? -c : c;
            }


        }

    }
}
