using System;
using System.Collections.Generic;
using System.Reflection;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static unsafe GLint glGetUniformLocation(GLuint progName, IntPtr varNname) {
            var result = -1;
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return result; }

            if (progName == 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return result; }
            if (!context.name2Program.TryGetValue(progName, out var program)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return result; }
            if (program.LogInfo != string.Empty) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return result; }

            var str = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(varNname);
            if (str != null) { result = program.GetUniformLocation(str); }

            return result;
        }

        public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 16) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            program.SetUniform4fv(location, count, transpose, value);
        }

        public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 9) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            program.SetUniform3fv(location, count, transpose, value);
        }

        public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 4) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            program.SetUniform2fv(location, count, transpose, value);
        }

        public static void glUniform4uiv(GLint location, GLsizei count, GLuint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 4) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new uvec4[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new uvec4(value[i * 4 + 0], value[i * 4 + 1], value[i * 4 + 2], value[i * 4 + 3]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform3uiv(GLint location, GLsizei count, GLuint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 3) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new uvec3[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new uvec3(value[i * 3 + 0], value[i * 3 + 1], value[i * 3 + 2]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform2uiv(GLint location, GLsizei count, GLuint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 2) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new uvec2[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new uvec2(value[i * 2 + 0], value[i * 2 + 1]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform1uiv(GLint location, GLsizei count, GLuint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 1) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new uint[count];
            for (int i = 0; i < count; i++) {
                copy[i] = value[i];
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform4iv(GLint location, GLsizei count, GLint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 4) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new ivec4[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new ivec4(value[i * 4 + 0], value[i * 4 + 1], value[i * 4 + 2], value[i * 4 + 3]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform3iv(GLint location, GLsizei count, GLint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 3) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new ivec3[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new ivec3(value[i * 3 + 0], value[i * 3 + 1], value[i * 3 + 2]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform2iv(GLint location, GLsizei count, GLint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 2) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new ivec2[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new ivec2(value[i * 2 + 0], value[i * 2 + 1]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform1iv(GLint location, GLsizei count, GLint* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 1) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new int[count];
            for (int i = 0; i < count; i++) {
                copy[i] = value[i];
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform4fv(GLint location, GLsizei count, GLfloat* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 4) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new vec4[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new vec4(value[i * 4 + 0], value[i * 4 + 1], value[i * 4 + 2], value[i * 4 + 3]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform3fv(GLint location, GLsizei count, GLfloat* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 3) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new vec3[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new vec3(value[i * 3 + 0], value[i * 3 + 1], value[i * 3 + 2]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform2fv(GLint location, GLsizei count, GLfloat* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 2) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new vec2[count];
            for (int i = 0; i < count; i++) {
                copy[i] = new vec2(value[i * 2 + 0], value[i * 2 + 1]);
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform1fv(GLint location, GLsizei count, GLfloat* value) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            //if (location < 0 || value == null || value.Length != 1) { return; }
            if (location < 0 || value == null) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO:GL_INVALID_OPERATION is generated if the size of the uniform variable declared in the shader does not match the size indicated by the glUniform command.
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if ((count > 1) && (!fieldInfo.FieldType.IsArray)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            var copy = new float[count];
            for (int i = 0; i < count; i++) {
                copy[i] = value[i];
            }
            program.SetUniform(location, copy);
        }

        public static void glUniform4ui(GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform4ui(location, v0, v1, v2, v3);
        }

        public static void glUniform3ui(GLint location, GLuint v0, GLuint v1, GLuint v2) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform3ui(location, v0, v1, v2);
        }

        public static void glUniform2ui(GLint location, GLuint v0, GLuint v1) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform2ui(location, v0, v1);
        }

        public static void glUniform1ui(GLint location, GLuint v0) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform1ui(location, v0);
        }

        public static void glUniform4i(GLint location, GLint v0, GLint v1, GLint v2, GLint v3) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform4i(location, v0, v1, v2, v3);
        }

        public static void glUniform3i(GLint location, GLint v0, GLint v1, GLint v2) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform3i(location, v0, v1, v2);
        }

        public static void glUniform2i(GLint location, GLint v0, GLint v1) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform2i(location, v0, v1);
        }

        public static void glUniform1i(GLint location, GLint v0) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform1i(location, v0);
        }

        public static void glUniform4f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform4f(location, v0, v1, v2, v3);
        }

        public static void glUniform3f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform3f(location, v0, v1, v2);
        }

        public static void glUniform2f(GLint location, GLfloat v0, GLfloat v1) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform2f(location, v0, v1);
        }

        public static void glUniform1f(GLint location, GLfloat v0) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (location < 0) { return; }

            var program = context.currentShaderProgram;
            if (program == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var v = program.GetUniformVariable(location);
            if (v == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            FieldInfo fieldInfo = v.fieldInfo;
            if (fieldInfo.FieldType.IsArray) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; } // TODO: not sure about this line.

            program.SetUniform1f(location, v0);
        }

    }
}
