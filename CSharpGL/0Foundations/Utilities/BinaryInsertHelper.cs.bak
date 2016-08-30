using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class BinaryInsertHelper
    {
        /// <summary>
        /// 尝试插入新元素。如果存在相同的元素，就不插入，并返回false。否则返回true。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int TryBinaryInsert<T>(this List<T> list, T item)
            where T : IComparable<T>
        {
            int insertedIndex = -1;

            if (list == null || item == null) { return insertedIndex; }

            int left = 0, right = list.Count - 1;
            if (right < 0)
            {
                list.Add(item);
                insertedIndex = 0;
            }
            else
            {
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    T current = list[mid];
                    int result = item.CompareTo(current);
                    if (result < 0)
                    { right = mid; }
                    else if (result == 0)
                    { left = mid; right = mid; }
                    else
                    { left = mid + 1; }
                }
                {
                    T current = list[left];
                    int result = item.CompareTo(current);
                    if (result < 0)
                    {
                        list.Insert(left, item);
                        insertedIndex = left;
                    }
                    else if (result > 0)
                    {
                        list.Insert(left + 1, item);
                        insertedIndex = left + 1;
                    }
                }
            }

            return insertedIndex;
        }

    }
}
