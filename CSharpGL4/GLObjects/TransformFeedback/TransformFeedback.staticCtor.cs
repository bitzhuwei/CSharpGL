using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    public abstract partial class TransformFeedback
    {
        private static readonly GLDelegates.void_int_uintN glGenTransformFeedbacks;
        private static readonly GLDelegates.void_uint_uint glBindTransformFeedback;
        private static readonly GLDelegates.void_int_uintN glDeleteTransformFeedbacks;
        private static readonly GLDelegates.void_uint_uint_uint glBindBufferBase;
        //void glBindBufferRange(uint target, uint index, uint buffer, int offset, int size);
        private static readonly GLDelegates.void_uint_uint_uint_int_int glBindBufferRange;
        //void glTransformFeedbackVaryings(uint program, int count, string[] varyings, uint bufferMode);
        private static readonly GLDelegates.void_uint_int_stringN_uint glTransformFeedbackVaryings;
        //void glGetTransformFeedbackVarying(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string name);
        private static readonly GLDelegates.void_uint_uint_int_intN_intN_uintN_string glGetTransformFeedbackVarying;
        private static readonly GLDelegates.void_uint glBeginTransformFeedback;
        private static readonly GLDelegates.void_void glPauseTransformFeedback;
        private static readonly GLDelegates.void_void glResumeTransformFeedback;
        private static readonly GLDelegates.void_void glEndTransformFeedback;

        static TransformFeedback()
        {
            glGenTransformFeedbacks = GL.Instance.GetDelegateFor("glGenTransformFeedbacks", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindTransformFeedback = GL.Instance.GetDelegateFor("glBindTransformFeedback", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDeleteTransformFeedbacks = GL.Instance.GetDelegateFor("glDeleteTransformFeedbacks", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindBufferBase = GL.Instance.GetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
            glBindBufferRange = GL.Instance.GetDelegateFor("glBindBufferRange", GLDelegates.typeof_void_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_int_int;
            glTransformFeedbackVaryings = GL.Instance.GetDelegateFor("glTransformFeedbackVaryings", GLDelegates.typeof_void_uint_int_stringN_uint) as GLDelegates.void_uint_int_stringN_uint;
            glGetTransformFeedbackVarying = GL.Instance.GetDelegateFor("glGetTransformFeedbackVarying", GLDelegates.typeof_void_uint_uint_int_intN_intN_uintN_string) as GLDelegates.void_uint_uint_int_intN_intN_uintN_string;
            glBeginTransformFeedback = GL.Instance.GetDelegateFor("glBeginTransformFeedback", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glPauseTransformFeedback = GL.Instance.GetDelegateFor("glPauseTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
            glResumeTransformFeedback = GL.Instance.GetDelegateFor("glResumeTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
            glEndTransformFeedback = GL.Instance.GetDelegateFor("glEndTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
        }
    }
}