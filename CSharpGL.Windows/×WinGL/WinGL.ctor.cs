using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpGL.Windows {
    unsafe partial class WinGL {

        ///// <summary>
        ///// HGLRC WINAPI wglCreateContextAttribsARB(
        ///// <para>HDC hDC,                        // 设备上下文句柄</para>
        ///// <para>HGLRC hShareContext,            // 共享的上下文句柄（通常为NULL）</para>
        ///// <para>const int* attribList           // 上下文属性键值对数组</para>
        ///// <para>);</para>
        ///// </summary>
        //public readonly delegate* unmanaged<IntPtr, IntPtr, int[], IntPtr> wglCreateContextAttribsARB;
        ///// <summary>
        ///// BOOL WINAPI wglChoosePixelFormatARB(
        ///// <para>HDC hdc,                        // 设备上下文句柄</para>
        ///// <para>const int* piAttribIList,        // 整数属性列表</para>
        ///// <para>const FLOAT* pfAttribFList,     // 浮点数属性列表（通常设为NULL）</para>
        ///// <para>UINT nMaxFormats,                // 最大返回的像素格式数量</para>
        ///// <para>int* piFormats,                  // 输出匹配的像素格式索引数组</para>
        ///// <para>UINT* nNumFormats                // 实际找到的像素格式数量</para>
        ///// <para>);</para>
        ///// </summary>
        //public readonly delegate* unmanaged<IntPtr, int[], GLfloat[], uint, int[], uint[], bool> wglChoosePixelFormatARB;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GetProcAddress">the function that gets openGL function with specified <paramref name="funcName"/></param>
        public WinGL(Func<string, IntPtr> GetProcAddress)
            : base(GetProcAddress) {

            #region windows functions

            //wglCreateContextAttribsARB = (delegate* unmanaged<IntPtr, IntPtr, int[], IntPtr>)GetProcAddress("wglCreateContextAttribsARB");
            //wglChoosePixelFormatARB = (delegate* unmanaged<IntPtr, int[], GLfloat[], uint, int[], uint[], bool>)GetProcAddress("wglChoosePixelFormatARB");

            #endregion windows functions

        }
    }
}
