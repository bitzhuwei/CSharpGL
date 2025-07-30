using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL {
    public partial class WinGL {
        public unsafe override Delegate GetDelegateFor(string functionName, Type functionDeclaration) {
            // ftlPhysicsGuy - Better way
            Delegate del = null;
            if (!extensionFunctions.TryGetValue(functionName, out del)) {
                IntPtr proc = GetProc(functionName);

                if (proc != IntPtr.Zero) {
                    //  Get the delegate for the function pointer.
                    del = Marshal.GetDelegateForFunctionPointer(proc, functionDeclaration);

                    //  Add to the dictionary.
                    extensionFunctions.Add(functionName, del);
                }
            }

            return del;
        }
        public unsafe override T GetDelegateFor<T>(string functionName) {
            T result = default(T);
            // ftlPhysicsGuy - Better way
            if (!extensionFunctions.TryGetValue(functionName, out var del)) {
                IntPtr proc = GetProc(functionName);

                if (proc != IntPtr.Zero) {
                    //  Get the delegate for the function pointer.

                    result = System.Runtime.CompilerServices.Unsafe.ReadUnaligned<T>((void*)proc);
                    //  Add to the dictionary.
                    extensionFunctions.Add(functionName, result);
                }
            }
            else { result = (T)del; }

            return result;
        }
        public static IntPtr GetProc(string name) {
            IntPtr proc = IntPtr.Zero;
            // check https://www.GL.org/wiki/Load_OpenGL_Functions
            proc = Win32.wglGetProcAddress(name);
            long pointer = proc.ToInt64();
            if (-1 <= pointer && pointer <= 3) {
                proc = Win32.GetProcAddress(name);
                pointer = proc.ToInt64();
                if (-1 <= pointer && pointer <= 3) {
                    Debug.WriteLine(string.Format(
                        "Extension function [{0}] not supported!", name));
                    proc = IntPtr.Zero;
                }
            }

            return proc;
        }

        /// <summary>
        /// The set of extension functions.
        /// </summary>
        private static readonly Dictionary<string, Delegate> extensionFunctions = new Dictionary<string, Delegate>();

    }
}