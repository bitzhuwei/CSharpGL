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
        internal static readonly GLDelegates.void_uint_floatN glPatchParameterfv;
        internal static readonly GLDelegates.void_uint glEnableVertexAttribArray;
        internal static readonly GLDelegates.void_uint_uint glVertexAttribDivisor;
        /// <summary>
        /// void glDrawArraysInstanced(GLenum mode​, GLint first​, GLsizei count​, GLsizei primcount​);
        /// <para>mode: Specifies what kind of primitives to render. Symbolic constants GL_POINTS, GL_LINE_STRIP, GL_LINE_LOOP, GL_LINES, GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN, GL_TRIANGLES, GL_LINES_ADJACENCY, GL_LINE_STRIP_ADJACENCY, GL_TRIANGLES_ADJACENCY, GL_TRIANGLE_STRIP_ADJACENCY and GL_PATCHES are accepted.</para>
        /// <para>first: Specifies the starting index in the enabled arrays.</para>
        /// <para>count: Specifies the number of indices to be rendered.</para>
        /// <para>primcount: Specifies the number of instances of the specified range of indices to be rendered.</para>
        /// </summary>
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
            glPatchParameterfv = GL.Instance.GetDelegateFor("glPatchParameterfv", GLDelegates.typeof_void_uint_floatN) as GLDelegates.void_uint_floatN;
            glEnableVertexAttribArray = GL.Instance.GetDelegateFor("glEnableVertexAttribArray", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glVertexAttribDivisor = GL.Instance.GetDelegateFor("glVertexAttribDivisor", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDrawElementsInstanced = GL.Instance.GetDelegateFor("glDrawElementsInstanced", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
            glDrawElementsBaseVertex = GL.Instance.GetDelegateFor("glDrawElementsBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
            glDrawElementsInstancedBaseVertex = GL.Instance.GetDelegateFor("glDrawElementsInstancedBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int_int) as GLDelegates.void_uint_int_uint_IntPtr_int_int;
        }
    }
}