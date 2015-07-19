using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// The OpenGL class wraps Sun's OpenGL 3D library.
    /// </summary>
    public static partial class GL
    {

        /// <summary>
        /// Returns a delegate for an extension function. This delegate  can be called to execute the extension function.
        /// </summary>
        /// <typeparam name="T">The extension delegate type.</typeparam>
        /// <returns>The delegate that points to the extension function.</returns>
        private static T GetDelegateFor<T>() where T : class
        {
            //  Get the type of the extension function.
            Type delegateType = typeof(T);

            //  Get the name of the extension function.
            string name = delegateType.Name;

            // ftlPhysicsGuy - Better way
            Delegate del = null;
            if (!extensionFunctions.TryGetValue(name, out del))
            {
                // check https://www.opengl.org/wiki/Load_OpenGL_Functions
                IntPtr proc = Win32.wglGetProcAddress(name);
                int pointer = proc.ToInt32();
                if (-1 <= pointer && pointer <= 3)
                {
                    proc = Win32.GetProcAddress(name);
                    pointer = proc.ToInt32();
                    if (-1 <= pointer && pointer <= 3)
                    { throw new Exception("Extension function " + name + " not supported"); }
                }

                //  Get the delegate for the function pointer.
                del = Marshal.GetDelegateForFunctionPointer(proc, delegateType);

                //  Add to the dictionary.
                extensionFunctions.Add(name, del);
            }

            return del as T;
        }

        /// <summary>
        /// The set of extension functions.
        /// </summary>
        private static readonly Dictionary<string, Delegate> extensionFunctions = new Dictionary<string, Delegate>();

    }
}
