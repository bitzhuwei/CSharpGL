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
        /// <param name="descending">true for descending sort; otherwise false.</param>
        public static void Sort<T>(this UnmanagedArray<T> array, bool descending) where T : struct, IComparable<T>
        {
            Sort(array, 0, array.Length, descending);
        }

        /// <summary>
        /// Sort unmanaged array specified with <paramref name="array"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="array"/> to bo sorted.</param>
        /// <param name="descending">true for descending sort; otherwise false.</param>
        public static void Sort<T>(this UnmanagedArray<T> array, int start, int length, bool descending) where T : struct, IComparable<T>
        {
            if (array == null) { throw new ArgumentNullException("array"); }
            if (start < 0) { throw new ArgumentOutOfRangeException("start"); }
            if (length < 0) { throw new ArgumentOutOfRangeException("length"); }
            if (array.Length < start + length) { throw new ArgumentOutOfRangeException(string.Format("{0} < {1} + {2}", array.Length, start, length)); }

            Type type = typeof(T);
            MethodInfo method = GetOrderMethod(type);
            object invokeResult = method.Invoke(null, new object[] { array.Header, start, length, descending });
        }

        private static MethodInfo GetOrderMethod(Type type)
        {
            MethodInfo method;
            if (!icomparableDict.TryGetValue(type, out method))
            {
                string order = ManifestResourceLoader.LoadTextFile(@"Resources\SortingHelper.Order`1.cs");
                order = order.Replace("TemplateStructType", type.FullName);
                //string comparer = ManifestResourceLoader.LoadTextFile(@"Resources\SortingHelper.Comparer`1.cs");
                //comparer = comparer.Replace("TemplateStructType", type.FullName);
                var codeProvider = new CSharpCodeProvider();
                var option = new CompilerParameters();
                option.GenerateInMemory = true;
                option.CompilerOptions = "/unsafe";
                option.ReferencedAssemblies.Add("System.dll");
                option.ReferencedAssemblies.Add("CSharpGL.dll");
                CompilerResults result = codeProvider.CompileAssemblyFromSource(option,
                    order);
                Assembly asm = result.CompiledAssembly;
                Type sortingHelper = asm.GetType("CSharpGL.SortingHelper");
                method = sortingHelper.GetMethod("Sort", new Type[] { typeof(IntPtr), typeof(int), typeof(int), typeof(bool) });

                icomparableDict.Add(type, method);
            }

            return method;
        }

        private static readonly Dictionary<Type, MethodInfo> icomparableDict = new Dictionary<Type, MethodInfo>();
    }
}