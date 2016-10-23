using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

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
            Type type = typeof(T);
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
            Type unmanagedArrayGeneric = typeof(UnmanagedArray<>);
            Type unmanagedArray = unmanagedArrayGeneric.MakeGenericType(type);
            MethodInfo method = sortingHelper.GetMethod("Sort", new Type[] { unmanagedArray, typeof(int), typeof(int), typeof(bool) });
            object invokeResult = method.Invoke(null, new object[] { array, 0, array.Length, descending });
        }

    }
}