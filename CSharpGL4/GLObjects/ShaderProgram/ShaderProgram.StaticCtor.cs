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
        internal static GLDelegates.uint_void glCreateProgram;
        internal static GLDelegates.void_uint_uint glAttachShader;
        internal static GLDelegates.void_uint glLinkProgram;
        internal static GLDelegates.void_uint_uint glDetachShader;
        internal static GLDelegates.void_uint glDeleteProgram;
        internal static GLDelegates.int_uint_string glGetAttribLocation;
        internal static GLDelegates.void_uint_uint_int_intN_intN_uintN_string glGetActiveUniform;
        internal static GLDelegates.void_uint_int_floatN glGetUniformfv;
        internal static GLDelegates.void_uint_int_intN glGetUniformiv;
        internal static GLDelegates.void_uint glUseProgram;
        internal static GLDelegates.void_uint_uint_intN glGetProgramiv;
        internal static GLDelegates.void_int_uint glUniform1ui;
        internal static GLDelegates.void_int_uint_uint glUniform2ui;
        internal static GLDelegates.void_int_uint_uint_uint glUniform3ui;
        internal static GLDelegates.void_int_uint_uint_uint_uint glUniform4ui;
        internal static GLDelegates.void_int_int_uintN glUniform1uiv;
        internal static GLDelegates.void_int_int_uintN glUniform2uiv;
        internal static GLDelegates.void_int_int_uintN glUniform3uiv;
        internal static GLDelegates.void_int_int_uintN glUniform4uiv;
        internal static GLDelegates.void_int_int glUniform1i;
        internal static GLDelegates.void_int_int_int glUniform2i;
        internal static GLDelegates.void_int_int_int_int glUniform3i;
        internal static GLDelegates.void_int_int_int_int_int glUniform4i;
        internal static GLDelegates.void_int_int_intN glUniform1iv;
        internal static GLDelegates.void_int_int_intN glUniform2iv;
        internal static GLDelegates.void_int_int_intN glUniform3iv;
        internal static GLDelegates.void_int_int_intN glUniform4iv;
        internal static GLDelegates.void_int_float glUniform1f;
        internal static GLDelegates.void_int_float_float glUniform2f;
        internal static GLDelegates.void_int_float_float_float glUniform3f;
        internal static GLDelegates.void_int_float_float_float_float glUniform4f;
        internal static GLDelegates.void_int_int_floatN glUniform1fv;
        internal static GLDelegates.void_int_int_floatN glUniform2fv;
        internal static GLDelegates.void_int_int_floatN glUniform3fv;
        internal static GLDelegates.void_int_int_floatN glUniform4fv;
        internal static GLDelegates.void_int_int_bool_floatN glUniformMatrix2fv;
        internal static GLDelegates.void_int_int_bool_floatN glUniformMatrix3fv;
        internal static GLDelegates.void_int_int_bool_floatN glUniformMatrix4fv;
        internal static GLDelegates.int_uint_string glGetUniformLocation;
        internal static GLDelegates.void_uint_int_stringN_uint glTransformFeedbackVaryings;

        static ShaderProgram()
        {
            glCreateProgram = GL.Instance.GetDelegateFor("glCreateProgram", GLDelegates.typeof_uint_void) as GLDelegates.uint_void;
            glAttachShader = GL.Instance.GetDelegateFor("glAttachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glLinkProgram = GL.Instance.GetDelegateFor("glLinkProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glDetachShader = GL.Instance.GetDelegateFor("glDetachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDeleteProgram = GL.Instance.GetDelegateFor("glDeleteProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glGetAttribLocation = GL.Instance.GetDelegateFor("glGetAttribLocation", GLDelegates.typeof_int_uint_string) as GLDelegates.int_uint_string;
            glGetActiveUniform = GL.Instance.GetDelegateFor("glGetActiveUniform", GLDelegates.typeof_void_uint_uint_int_intN_intN_uintN_string) as GLDelegates.void_uint_uint_int_intN_intN_uintN_string;
            glGetUniformfv = GL.Instance.GetDelegateFor("glGetUniformfv", GLDelegates.typeof_void_uint_int_floatN) as GLDelegates.void_uint_int_floatN;
            glGetUniformiv = GL.Instance.GetDelegateFor("glGetUniformiv", GLDelegates.typeof_void_uint_int_intN) as GLDelegates.void_uint_int_intN;
            glUseProgram = GL.Instance.GetDelegateFor("glUseProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glGetProgramiv = GL.Instance.GetDelegateFor("glGetProgramiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN;
            glGetUniformLocation = GL.Instance.GetDelegateFor("glGetUniformLocation", GLDelegates.typeof_int_uint_string) as GLDelegates.int_uint_string;
        }
    }
}
