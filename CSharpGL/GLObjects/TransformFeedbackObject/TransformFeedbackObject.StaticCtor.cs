using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// manages <see cref="TransformFeedbackBuffer"/>s.
    /// </summary>
    public unsafe partial class TransformFeedbackObject {
        //internal static readonly GLDelegates.void_int_uintN glGenTransformFeedbacks;
        //internal static readonly GLDelegates.void_uint_uint glBindTransformFeedback;
        //internal static readonly GLDelegates.void_int_uintN glDeleteTransformFeedbacks;
        //internal static readonly GLDelegates.void_uint_uint_uint glBindBufferBase;
        ////void glBindBufferRange(uint target, uint index, uint buffer, int offset, int size);
        //internal static readonly GLDelegates.void_uint_uint_uint_int_int glBindBufferRange;
        ////void glTransformFeedbackVaryings(uint program, int count, string[] varyings, uint bufferMode);
        ////internal static readonly GLDelegates.void_uint_int_stringN_uint glTransformFeedbackVaryings;
        ////void glGetTransformFeedbackVarying(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string name);
        //internal static readonly GLDelegates.void_uint_uint_int_intN_intN_uintN_string glGetTransformFeedbackVarying;
        //internal static readonly GLDelegates.void_uint glBeginTransformFeedback;
        //internal static readonly GLDelegates.void_void glPauseTransformFeedback;
        //internal static readonly GLDelegates.void_void glResumeTransformFeedback;
        //internal static readonly GLDelegates.void_void glEndTransformFeedback;
        //internal static readonly GLDelegates.void_uint_uint glDrawTransformFeedback;

        //static TransformFeedbackObject() {
        //    glGenTransformFeedbacks = gl.glGetDelegateFor("glGenTransformFeedbacks", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glBindTransformFeedback = gl.glGetDelegateFor("glBindTransformFeedback", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //    glDeleteTransformFeedbacks = gl.glGetDelegateFor("glDeleteTransformFeedbacks", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glBindBufferBase = gl.glGetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
        //    glBindBufferRange = gl.glGetDelegateFor("glBindBufferRange", GLDelegates.typeof_void_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_int_int;
        //    //glTransformFeedbackVaryings = GL.Instance.GetDelegateFor("glTransformFeedbackVaryings", GLDelegates.typeof_void_uint_int_stringN_uint) as GLDelegates.void_uint_int_stringN_uint;
        //    glGetTransformFeedbackVarying = gl.glGetDelegateFor("glGetTransformFeedbackVarying", GLDelegates.typeof_void_uint_uint_int_intN_intN_uintN_string) as GLDelegates.void_uint_uint_int_intN_intN_uintN_string;
        //    glBeginTransformFeedback = gl.glGetDelegateFor("glBeginTransformFeedback", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glPauseTransformFeedback = gl.glGetDelegateFor("glPauseTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
        //    glResumeTransformFeedback = gl.glGetDelegateFor("glResumeTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
        //    glEndTransformFeedback = gl.glGetDelegateFor("glEndTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
        //    glDrawTransformFeedback = gl.glGetDelegateFor("glDrawTransformFeedback", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //}
    }
}
