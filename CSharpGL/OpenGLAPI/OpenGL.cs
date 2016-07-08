using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpGL
{
    /// <summary>
    /// The OpenGL class wraps Sun's OpenGL 3D library.
    /// </summary>
    public static partial class OpenGL
    {

        // https://msdn.microsoft.com/zh-cn/library/ms379564(VS.80).aspx
        // 如果客户端指定引用类型，则 JIT 编译器将服务器 IL 中的一般参数替换为 Object，并将其编译为本机代码。
        // 在以后的任何针对引用类型而不是一般类型参数的请求中，都将使用该代码。
        // 请注意，采用这种方式，JIT 编译器只会重新使用实际代码。实例仍然按照它们离开托管堆的大小分配空间，并且没有强制类型转换。
        // 
        // http://blog.csdn.net/yjjm1990/article/details/9498923
        // CLR 为所有类型参数为“ 引用类型” 的泛型类型产生同一份代码；但如果类型参数为“ 值类型” ，对每一个不同的“ 值类型” ，CLR将为其产生一份独立的代码
        // 
        /// <summary>
        /// Returns a delegate for an extension function. This delegate  can be called to execute the extension function.
        /// </summary>
        /// <typeparam name="T">The extension delegate type.</typeparam>
        /// <returns>The delegate that points to the extension function.</returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetDelegateFor<T>() where T : class
        {
            //  Get the type of the extension function.
            Type delegateType = typeof(T);

            //  Get the name of the extension function.
            string name = delegateType.Name;

            // ftlPhysicsGuy - Better way
            Delegate del = null;
            if (!extensionFunctions.TryGetValue(name, out del))
            {
                IntPtr proc = IntPtr.Zero;
                if (CurrentOS.IsWindows)
                {
                    // check https://www.opengl.org/wiki/Load_OpenGL_Functions
                    proc = Win32.wglGetProcAddress(name);
                    long pointer = proc.ToInt64();
                    if (-1 <= pointer && pointer <= 3)
                    {
                        proc = Win32.GetProcAddress(Win32.opengl32Library, name);
                        pointer = proc.ToInt64();
                        if (-1 <= pointer && pointer <= 3)
                        {
                            throw new Exception("Extension function " + name + " not supported");
                        }
                    }
                }
                else if (CurrentOS.IsLinux)
                {
                    proc = glxGetProcAddress(name);
                    if (proc == IntPtr.Zero)
                    {
                        throw new Exception("Extension function " + name + " not supported");
                    }
                }
                else
                {
                    throw new NotImplementedException("Unsupported OS.");
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

        //const string fixedPipelineIsNotGood = "fixed pipeline is no longer nice for opengl.";
        //const string obsoleteGluDll = "suggest that not to use Glu Dll any more.";

        //const bool error = false;

        //TODO: 在linux还能正常使用CSharpGL吗？我没有试验过。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [DllImport("libGL.so", EntryPoint = "glXGetProcAddress")]
        internal static extern IntPtr glxGetProcAddress(string s);
    }
}
