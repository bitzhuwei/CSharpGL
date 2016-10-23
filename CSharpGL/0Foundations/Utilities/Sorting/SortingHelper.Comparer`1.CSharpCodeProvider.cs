using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for sorting unmanaged array.
    /// </summary>
    public static partial class SortingHelper
    {
        /// <summary>
        /// Sort unmanaged array specified with <paramref name="array"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer">
        /// If you want descending sort, make it returns -1 when <paramref name="array"/>[left] &lt; <paramref name="array"/>[right].
        /// <para>Otherwise, make it returns -1 when <paramref name="array"/>[left] &gt; <paramref name="array"/>[right].</para></param>
        public static void Sort<T>(this UnmanagedArray<T> array, Comparer<T> comparer) where T : struct
        {
            QuickSort(array, 0, array.Length, comparer);
        }

        /// <summary>
        /// Sort unmanaged array specified with <paramref name="array"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="array"/> to bo sorted.</param>
        /// <param name="comparer">
        /// If you want descending sort, make it returns -1 when <paramref name="array"/>[left] &lt; <paramref name="array"/>[right].
        /// <para>Otherwise, make it returns -1 when <paramref name="array"/>[left] &gt; <paramref name="array"/>[right].</para></param>
        public static void Sort<T>(this UnmanagedArray<T> array, int start, int length, Comparer<T> comparer) where T : struct
        {
            QuickSort(array, start, length, comparer);
        }

        private static void QuickSort<T>(UnmanagedArray<T> array, int start, int length, Comparer<T> comparer) where T : struct
        {
            if (array == null) { throw new ArgumentNullException("array"); }
            if (start < 0) { throw new ArgumentOutOfRangeException("start"); }
            if (length < 0) { throw new ArgumentOutOfRangeException("length"); }
            if (array.Length < start + length) { throw new ArgumentOutOfRangeException(string.Format("{0} < {1} + {2}", array.Length, start, length)); }
            if (comparer == null) { throw new ArgumentNullException("comparer"); }

            MethodInfo method = GetOuterComparerMethod<T>();
            object invokeResult = method.Invoke(null, new object[] { array.Header, start, length, comparer });
        }

        private static MethodInfo GetOuterComparerMethod<T>()
        {
            Type type = typeof(T);
            MethodInfo method;
            if (!outerComparerDict.TryGetValue(type, out method))
            {
                string comparer = ManifestResourceLoader.LoadTextFile(@"Resources\SortingHelper.Comparer`1.cs");
                comparer = comparer.Replace("TemplateStructType", type.FullName);
                var codeProvider = new CSharpCodeProvider();
                var option = new CompilerParameters();
                option.GenerateInMemory = true;
                option.CompilerOptions = "/unsafe";
                option.ReferencedAssemblies.Add("System.dll");
                option.ReferencedAssemblies.Add("CSharpGL.dll");
                CompilerResults result = codeProvider.CompileAssemblyFromSource(option,
                    comparer);
                Assembly asm = result.CompiledAssembly;
                Type sortingHelper = asm.GetType("CSharpGL.SortingHelper");
                Type unmanagedArrayGeneric = typeof(UnmanagedArray<>);
                Type unmanagedArray = unmanagedArrayGeneric.MakeGenericType(type);
                method = sortingHelper.GetMethod("Sort", new Type[] { typeof(IntPtr), typeof(int), typeof(int), typeof(Comparer<T>) });

                outerComparerDict.Add(type, method);
            }

            return method;
        }

        private static readonly Dictionary<Type, MethodInfo> outerComparerDict = new Dictionary<Type, MethodInfo>();
    }
}