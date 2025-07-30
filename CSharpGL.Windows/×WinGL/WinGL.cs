using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CSharpGL.Windows {
    public unsafe partial class WinGL : CSharpGL.GL {

        //public static readonly WinGL instance = new();

        //public override nint GetCurrentContext() {
        //    return Win32.wglGetCurrentContext();
        //}


        //public override IntPtr GetProcAddress(string funcName) {
        //    IntPtr proc = IntPtr.Zero;
        //    // check https://www.GL.org/wiki/Load_OpenGL_Functions
        //    proc = Win32.wglGetProcAddress(funcName);// from opengl32.dll
        //    long pointer = proc.ToInt64();
        //    if (-1 <= pointer && pointer <= 3) {
        //        proc = Win32.GetProcAddress(funcName);// from kernel32.dll
        //        pointer = proc.ToInt64();
        //        if (-1 <= pointer && pointer <= 3) {
        //            //Debug.WriteLine($"openGL function [{funcName}] not supported!");
        //            proc = IntPtr.Zero;
        //        }
        //    }

        //    return proc;
        //}

    }
}
