using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    public abstract partial class GLBuffer
    {
        private static GLDelegates.void_int_uintN glGenBuffers;
        private static GLDelegates.void_uint_uint glBindBuffer;
        private static GLDelegates.void_uint_int_IntPtr_uint glBufferData;
        private static GLDelegates.IntPtr_uint_uint glMapBuffer;
        private static GLDelegates.IntPtr_uint_int_int_uint glMapBufferRange;
        private static GLDelegates.bool_uint glUnmapBuffer;

        static GLBuffer()
        {
            glGenBuffers = GL.Instance.GetDelegateFor("glGenBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindBuffer = GL.Instance.GetDelegateFor("glBindBuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glBufferData = GL.Instance.GetDelegateFor("glBufferData", GLDelegates.typeof_void_uint_int_IntPtr_uint) as GLDelegates.void_uint_int_IntPtr_uint;
            glMapBuffer = GL.Instance.GetDelegateFor("glMapBuffer", GLDelegates.typeof_IntPtr_uint_uint) as GLDelegates.IntPtr_uint_uint;
            glMapBufferRange = GL.Instance.GetDelegateFor("glMapBufferRange", GLDelegates.typeof_IntPtr_uint_int_int_uint) as GLDelegates.IntPtr_uint_int_int_uint;
            glUnmapBuffer = GL.Instance.GetDelegateFor("glUnmapBuffer", GLDelegates.typeof_bool_uint) as GLDelegates.bool_uint;
        }
    }
}