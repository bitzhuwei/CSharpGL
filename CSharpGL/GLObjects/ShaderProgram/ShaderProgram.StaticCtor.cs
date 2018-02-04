using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    public partial class ShaderProgram
    {
        internal static readonly GLDelegates.uint_void glCreateProgram;
        internal static readonly GLDelegates.void_uint_uint glAttachShader;
        internal static readonly GLDelegates.void_uint glLinkProgram;
        internal static readonly GLDelegates.void_uint_uint glDetachShader;
        internal static readonly GLDelegates.void_uint glDeleteProgram;
        internal static readonly GLDelegates.int_uint_string glGetAttribLocation;
        internal static readonly GLDelegates.void_uint_uint_int_intN_intN_uintN_string glGetActiveUniform;
        internal static readonly GLDelegates.void_uint_int_IntPtr_StringBuilder glGetProgramInfoLog;
        internal static readonly GLDelegates.void_uint_int_floatN glGetUniformfv;
        internal static readonly GLDelegates.void_uint_int_intN glGetUniformiv;
        internal static readonly GLDelegates.void_uint glUseProgram;
        internal static readonly GLDelegates.void_uint_uint_intN glGetProgramiv;
        private static GLDelegates.int_uint_string glGetUniformLocation;
        private static GLDelegates.void_int_uint glUniform1ui;
        private static GLDelegates.void_int_uint_uint glUniform2ui;
        private static GLDelegates.void_int_uint_uint_uint glUniform3ui;
        private static GLDelegates.void_int_uint_uint_uint_uint glUniform4ui;
        private static GLDelegates.void_int_int_uintN glUniform1uiv;
        private static GLDelegates.void_int_int_uintN glUniform2uiv;
        private static GLDelegates.void_int_int_uintN glUniform3uiv;
        private static GLDelegates.void_int_int_uintN glUniform4uiv;
        private static GLDelegates.void_int_int glUniform1i;
        private static GLDelegates.void_int_int_int glUniform2i;
        private static GLDelegates.void_int_int_int_int glUniform3i;
        private static GLDelegates.void_int_int_int_int_int glUniform4i;
        private static GLDelegates.void_int_int_intN glUniform1iv;
        private static GLDelegates.void_int_int_intN glUniform2iv;
        private static GLDelegates.void_int_int_intN glUniform3iv;
        private static GLDelegates.void_int_int_intN glUniform4iv;
        private static GLDelegates.void_int_float glUniform1f;
        private static GLDelegates.void_int_float_float glUniform2f;
        private static GLDelegates.void_int_float_float_float glUniform3f;
        private static GLDelegates.void_int_float_float_float_float glUniform4f;
        private static GLDelegates.void_int_int_floatN glUniform1fv;
        private static GLDelegates.void_int_int_floatN glUniform2fv;
        private static GLDelegates.void_int_int_floatN glUniform3fv;
        private static GLDelegates.void_int_int_floatN glUniform4fv;
        private static GLDelegates.void_int_int_bool_floatN glUniformMatrix2fv;
        private static GLDelegates.void_int_int_bool_floatN glUniformMatrix3fv;
        private static GLDelegates.void_int_int_bool_floatN glUniformMatrix4fv;
        private static GLDelegates.void_uint_int_stringN_uint glTransformFeedbackVaryings;
        //private static GLDelegates.int_uint_uint_string glGetSubroutineUniformLocation;
        //private static GLDelegates.uint_uint_uint_string glGetSubroutineIndex;
        //private static GLDelegates.void_uint_int_uintN glUniformSubroutinesuiv;

        static ShaderProgram()
        {
            glCreateProgram = GL.Instance.GetDelegateFor("glCreateProgram", GLDelegates.typeof_uint_void) as GLDelegates.uint_void;
            glAttachShader = GL.Instance.GetDelegateFor("glAttachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glLinkProgram = GL.Instance.GetDelegateFor("glLinkProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glDetachShader = GL.Instance.GetDelegateFor("glDetachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDeleteProgram = GL.Instance.GetDelegateFor("glDeleteProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glGetAttribLocation = GL.Instance.GetDelegateFor("glGetAttribLocation", GLDelegates.typeof_int_uint_string) as GLDelegates.int_uint_string;
            glGetActiveUniform = GL.Instance.GetDelegateFor("glGetActiveUniform", GLDelegates.typeof_void_uint_uint_int_intN_intN_uintN_string) as GLDelegates.void_uint_uint_int_intN_intN_uintN_string;
            glGetProgramInfoLog = GL.Instance.GetDelegateFor("glGetProgramInfoLog", GLDelegates.typeof_void_uint_int_IntPtr_StringBuilder) as GLDelegates.void_uint_int_IntPtr_StringBuilder;
            glGetUniformfv = GL.Instance.GetDelegateFor("glGetUniformfv", GLDelegates.typeof_void_uint_int_floatN) as GLDelegates.void_uint_int_floatN;
            glGetUniformiv = GL.Instance.GetDelegateFor("glGetUniformiv", GLDelegates.typeof_void_uint_int_intN) as GLDelegates.void_uint_int_intN;
            glUseProgram = GL.Instance.GetDelegateFor("glUseProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glGetProgramiv = GL.Instance.GetDelegateFor("glGetProgramiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN;
            glGetUniformLocation = GL.Instance.GetDelegateFor("glGetUniformLocation", GLDelegates.typeof_int_uint_string) as GLDelegates.int_uint_string;
        }
    }
}
