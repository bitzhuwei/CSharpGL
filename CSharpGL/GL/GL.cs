using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL {
    /// <summary>
    /// collection of openGL function pointers.
    /// <para>each operating system should has its own openGL implementation(ie. an class that implements this <see cref="GL"/> class).</para>
    /// <para><see cref="GLRenderContext"/> objects with the same initial parameters share function pointers in <see cref="GL"/>.</para>
    /// </summary>
    public unsafe partial class GL {

        internal static GL? current;
        /// <summary>
        /// openGL function pointers that bind to current <see cref="GLRenderContext"/>
        /// </summary>
        public static GL? Current => current;

        ///// <summary>
        ///// the function that gets openGL function with specified <paramref name="funcName"/>
        ///// </summary>
        //public readonly Func<string, IntPtr> GetProcAddress;

        ///// <summary>
        ///// get current opengl context.
        ///// </summary>
        ///// <returns></returns>
        //public abstract IntPtr GetCurrentContext();

        /// <summary>
        /// 控制 OpenGL 垂直同步（VSync）：指定帧缓冲区交换的时机，从而控制画面刷新与显示器垂直同步信号的关系。
        /// 0：禁用垂直同步（允许撕裂，可能提高帧率）。
        /// 1：启用垂直同步（消除撕裂，帧率受限于显示器刷新率）。
        /// 负值（如 -1）：部分显卡支持延迟交换（允许提前渲染下一帧）。
        /// 返回值：TRUE 表示成功，FALSE 表示失败。
        /// </summary>
        public readonly delegate* unmanaged<int, bool> wglSwapIntervalEXT;
        /// <summary>
        /// macOS 平台：使用 CGL 接口
        /// </summary>
        public readonly delegate* unmanaged<int, bool> kCGLCPSwapInterval;
        /// <summary>
        /// Linux/X11 平台：使用 GLX 扩展
        /// </summary>
        public readonly delegate* unmanaged<int, bool> glXSwapIntervalEXT;
    }
}
