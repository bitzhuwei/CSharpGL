using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    public abstract partial class GLBuffer
    {
        internal static readonly GLDelegates.void_int_uintN glGenBuffers;
        internal static readonly GLDelegates.void_uint_uint glBindBuffer;
        internal static readonly GLDelegates.void_uint_int_IntPtr_uint glBufferData;
        internal static readonly GLDelegates.IntPtr_uint_uint glMapBuffer;
        internal static readonly GLDelegates.IntPtr_uint_int_int_uint glMapBufferRange;
        internal static readonly GLDelegates.bool_uint glUnmapBuffer;
        internal static readonly GLDelegates.void_uint_int_uint_bool_int_IntPtr glVertexAttribPointer;
        internal static readonly GLDelegates.void_uint_int_uint_int_IntPtr glVertexAttribIPointer;
        internal static readonly GLDelegates.void_uint_int_uint_int_IntPtr glVertexAttribLPointer;
        internal static readonly GLDelegates.void_uint_int glPatchParameteri;
        internal static readonly GLDelegates.void_uint glEnableVertexAttribArray;
        internal static readonly GLDelegates.void_uint_uint glVertexAttribDivisor;
        internal static readonly GLDelegates.void_uint_int_int_int glDrawArraysInstanced;
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsInstanced;
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsBaseVertex;
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int_int glDrawElementsInstancedBaseVertex;

        static GLBuffer()
        {
            glGenBuffers = GL.Instance.GetDelegateFor("glGenBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindBuffer = GL.Instance.GetDelegateFor("glBindBuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glBufferData = GL.Instance.GetDelegateFor("glBufferData", GLDelegates.typeof_void_uint_int_IntPtr_uint) as GLDelegates.void_uint_int_IntPtr_uint;
            glMapBuffer = GL.Instance.GetDelegateFor("glMapBuffer", GLDelegates.typeof_IntPtr_uint_uint) as GLDelegates.IntPtr_uint_uint;
            glMapBufferRange = GL.Instance.GetDelegateFor("glMapBufferRange", GLDelegates.typeof_IntPtr_uint_int_int_uint) as GLDelegates.IntPtr_uint_int_int_uint;
            glUnmapBuffer = GL.Instance.GetDelegateFor("glUnmapBuffer", GLDelegates.typeof_bool_uint) as GLDelegates.bool_uint;
            glVertexAttribPointer = GL.Instance.GetDelegateFor("glVertexAttribPointer", GLDelegates.typeof_void_uint_int_uint_bool_int_IntPtr) as GLDelegates.void_uint_int_uint_bool_int_IntPtr;
            glVertexAttribIPointer = GL.Instance.GetDelegateFor("glVertexAttribIPointer", GLDelegates.typeof_void_uint_int_uint_int_IntPtr) as GLDelegates.void_uint_int_uint_int_IntPtr;
            glVertexAttribLPointer = GL.Instance.GetDelegateFor("glVertexAttribLPointer", GLDelegates.typeof_void_uint_int_uint_int_IntPtr) as GLDelegates.void_uint_int_uint_int_IntPtr;
            glPatchParameteri = GL.Instance.GetDelegateFor("glPatchParameteri", GLDelegates.typeof_void_uint_int) as GLDelegates.void_uint_int;
            glEnableVertexAttribArray = GL.Instance.GetDelegateFor("glEnableVertexAttribArray", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glVertexAttribDivisor = GL.Instance.GetDelegateFor("glVertexAttribDivisor", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDrawArraysInstanced = GL.Instance.GetDelegateFor("glDrawArraysInstanced", GLDelegates.typeof_void_uint_int_int_int) as GLDelegates.void_uint_int_int_int;
            glDrawElementsInstanced = GL.Instance.GetDelegateFor("glDrawElementsInstanced", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
            glDrawElementsBaseVertex = GL.Instance.GetDelegateFor("glDrawElementsBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
            glDrawElementsInstancedBaseVertex = GL.Instance.GetDelegateFor("glDrawElementsInstancedBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int_int) as GLDelegates.void_uint_int_uint_IntPtr_int_int;
        }
    }
}