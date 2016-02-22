using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class StringKMP
    {
        /// <summary>
        /// This indicates that no pattern found from source.
        /// </summary>
        public const int KMPNoMatch = -1;
        /// <summary>
        /// Special value of next[] array, which means i should be increased by 1 and j sould be reset to 0.
        /// </summary>
        private const int FirstBlood = -1;
        /// <summary>
        /// Find first match for specified pattern in the source.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int KMP(this String source, String pattern)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(pattern))
            { return KMPNoMatch; }
            var i = 0; var j = 0; var result = KMPNoMatch;
            var nextVal = GetNextVal(pattern);

            while (i < source.Length && j < pattern.Length)
            {
                if (j == FirstBlood)
                {// source[i] does NOT equal with pattern[0], so i should be increased by 1 and j should be reset to 0.
                    i++; j = 0;
                }
                else if (source[i].Equals(pattern[j]))
                {
                    i++; j++;
                }
                else
                {// Get next j that should be compared with.
                    j = nextVal[j];
                }
            }

            if (j >= pattern.Length)// Match succeeded.
            { result = i - pattern.Length; }

            return result;
        }
        /// <summary>
        /// nextVal[j]: source[i] should compare with pattern[ nextVal[j] ] in next loop
        /// <para>if source[i] does NOT equal with pattern[j].</para>
        /// <para>Specially, if source[i] does NOT equal with pattern[0], then i should be increased by 1</para>
        /// <para>and j should be reset to 0.</para>
        /// <para>So we should always set nextVal[0] = FirstBlood.</para>
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static int[] GetNextVal(String pattern)
        {
            var j = 0; var k = -1;
            var nextVal = new int[pattern.Length];

            nextVal[0] = FirstBlood;

            while (j < pattern.Length - 1)
            {
                if ((k == -1) || (pattern[j].Equals(pattern[k])))
                {
                    j++; k++;
                    if (!(pattern[j].Equals(pattern[k])))
                    { nextVal[j] = k; }
                    else
                    { nextVal[j] = nextVal[k]; }
                }
                else
                { k = nextVal[k]; }
            }

            return nextVal;
        }
    }

    public static class ArrayKMP
    {
        /// <summary>
        /// This indicates that no pattern found from source.
        /// </summary>
        public const int KMPNoMatch = -1;
        /// <summary>
        /// Special value of next[] array, which means i should be increased by 1 and j sould be reset to 0.
        /// </summary>
        private const int FirstBlood = -1;
        /// <summary>
        /// Find first match for specified pattern in the source.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int KMP(this Array source, Array pattern)
        {
            if (source == null || pattern == null || source.Length == 0 || pattern.Length == 0)
            { return KMPNoMatch; }
            var i = 0; var j = 0; var result = KMPNoMatch;
            var nextVal = GetNextVal(pattern);

            while (i < source.Length && j < pattern.Length)
            {
                if (j == FirstBlood)
                {// source[i] does NOT equal with pattern[0], so i should be increased by 1 and j should be reset to 0.
                    i++; j = 0;
                }
                else if (source.GetValue(i).Equals(pattern.GetValue(j)))
                {
                    i++; j++;
                }
                else
                {// Get next j that should be compared with.
                    j = nextVal[j];
                }
            }

            if (j >= pattern.Length)// Match succeeded.
            { result = i - pattern.Length; }

            return result;
        }
        /// <summary>
        /// nextVal[j]: source[i] should compare with pattern[ nextVal[j] ] in next loop
        /// <para>if source[i] does NOT equal with pattern[j].</para>
        /// <para>Specially, if source[i] does NOT equal with pattern[0], then i should be increased by 1</para>
        /// <para>and j should be reset to 0.</para>
        /// <para>So we should always set nextVal[0] = FirstBlood.</para>
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static int[] GetNextVal(Array pattern)
        {
            var j = 0; var k = -1;
            var nextVal = new int[pattern.Length];

            nextVal[0] = FirstBlood;

            while (j < pattern.Length - 1)
            {
                if ((k == -1) || (pattern.GetValue(j).Equals(pattern.GetValue(k))))
                {
                    j++; k++;
                    if (!(pattern.GetValue(j).Equals(pattern.GetValue(k))))
                    { nextVal[j] = k; }
                    else
                    { nextVal[j] = nextVal[k]; }
                }
                else
                { k = nextVal[k]; }
            }

            return nextVal;
        }
    }

    public static class IListKMP
    {
        /// <summary>
        /// This indicates that no pattern found from source.
        /// </summary>
        public const int KMPNoMatch = -1;
        /// <summary>
        /// Special value of next[] array, which means i should be increased by 1 and j sould be reset to 0.
        /// </summary>
        private const int FirstBlood = -1;
        /// <summary>
        /// Find first match for specified pattern in the source.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int KMP(this IList<IComparable> source, IList<IComparable> pattern)
        {
            if (source == null || pattern == null || source.Count == 0 || pattern.Count == 0)
            { return KMPNoMatch; }
            var i = 0; var j = 0; var result = KMPNoMatch;
            var nextVal = GetNextVal(pattern);

            while (i < source.Count && j < pattern.Count)
            {
                if (j == FirstBlood)
                {// source[i] does NOT equal with pattern[0], so i should be increased by 1 and j should be reset to 0.
                    i++; j = 0;
                }
                else if (source[i].Equals(pattern[j]))
                {
                    i++; j++;
                }
                else
                {// Get next j that should be compared with.
                    j = nextVal[j];
                }
            }

            if (j >= pattern.Count)// Match succeeded.
            { result = i - pattern.Count; }

            return result;
        }
        /// <summary>
        /// nextVal[j]: source[i] should compare with pattern[ nextVal[j] ] in next loop
        /// <para>if source[i] does NOT equal with pattern[j].</para>
        /// <para>Specially, if source[i] does NOT equal with pattern[0], then i should be increased by 1</para>
        /// <para>and j should be reset to 0.</para>
        /// <para>So we should always set nextVal[0] = FirstBlood.</para>
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static int[] GetNextVal(IList<IComparable> pattern)
        {
            var j = 0; var k = -1;
            var nextVal = new int[pattern.Count];

            nextVal[0] = FirstBlood;

            while (j < pattern.Count - 1)
            {
                if ((k == -1) || (pattern[j].Equals(pattern[k])))
                {
                    j++; k++;
                    if (!(pattern[j].Equals(pattern[k])))
                    { nextVal[j] = k; }
                    else
                    { nextVal[j] = nextVal[k]; }
                }
                else
                { k = nextVal[k]; }
            }

            return nextVal;
        }
    }

}