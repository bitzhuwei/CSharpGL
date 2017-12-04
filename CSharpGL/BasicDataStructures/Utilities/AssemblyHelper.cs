﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Get all derived non-abstract types of specified base type from all loaded assemblies.
        /// </summary>
        /// <param name="baseType"></param>
        /// <param name="addtionalFilter">addtional filter.</param>
        /// <returns></returns>
        public static List<Type> GetAllDerivedTypes(this Type baseType, Func<Type, bool> addtionalFilter = null)
        {
            //if (addtionalFilter == null) { addtionalFilter = x => !x.IsAbstract; }
            var result = new List<Type>();
            Assembly[] assemblies = AssemblyHelper.GetAssemblies(Application.ExecutablePath);
            foreach (Assembly asm in assemblies)
            {
                try
                {
                    var list = from item in asm.GetTypes()
                               where baseType.IsAssignableFrom(item)
                               && (addtionalFilter == null || (addtionalFilter(item)))
                               orderby item.FullName
                               select item;
                    foreach (Type item in list.Distinct())
                    {
                        result.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Assembly Helper: {0}", ex));
                }
            }

            return result;
        }

        /// <summary>
        /// Get all assemblies referenced by specified <paramref name="asmFilename"/>(self included) recursively.
        /// </summary>
        /// <param name="asmFilename"></param>
        /// <returns></returns>
        public static Assembly[] GetAssemblies(string asmFilename)
        {
            var result = new List<Assembly>();
            var asmPaths = new List<string>();
            var stack = new Stack<string>();
            stack.Push(asmFilename);
            while (stack.Count > 0)
            {
                string path = stack.Pop();
                Assembly asm = null;
                try
                {
                    // 检查这个路径
                    // 看是一个程序名还是一个路径
                    if ((path.IndexOf(Path.DirectorySeparatorChar, 0, path.Length) != -1) || (path.IndexOf(Path.AltDirectorySeparatorChar, 0, path.Length) != -1))
                    {
                        // 从这个路径加载程序集
                        //asm = Assembly.ReflectionOnlyLoadFrom(path);
                        asm = Assembly.LoadFrom(path);
                    }
                    else
                    {
                        // 是一个程序集名称
                        //asm = Assembly.ReflectionOnlyLoad(path);
                        asm = Assembly.Load(path);
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex);
                }

                // 把程序集添加到列表中
                if (asm != null)
                {
                    if (!asmPaths.Contains(path))
                    { asmPaths.Add(path); result.Add(asm); }
                    var referenced = from item in asm.GetReferencedAssemblies() select item;
                    foreach (AssemblyName item in referenced.Distinct())
                    {
                        if (!asmPaths.Contains(item.FullName))
                        {
                            stack.Push(item.FullName);
                        }
                    }
                }
            }

            return result.ToArray();
        }
    }
}