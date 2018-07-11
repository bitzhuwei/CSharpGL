using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class SoftGL
    {
        private static readonly Type thisType = typeof(SoftGL);
        //private static 
        public override Delegate GetDelegateFor(string functionName, Type functionDeclaration)
        {
            Delegate result = null;
            if (!extensionFunctions.TryGetValue(functionName, out result))
            {
                MethodInfo methodInfo = thisType.GetMethod(functionName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                if (methodInfo != null)
                {
                    result = System.Delegate.CreateDelegate(functionDeclaration, methodInfo);
                }

                if (result != null)
                {
                    //  Add to the dictionary.
                    extensionFunctions.Add(functionName, result);
                }
            }

            return result;
        }

        /// <summary>
        /// The set of extension functions.
        /// </summary>
        private static readonly Dictionary<string, Delegate> extensionFunctions = new Dictionary<string, Delegate>();

    }
}