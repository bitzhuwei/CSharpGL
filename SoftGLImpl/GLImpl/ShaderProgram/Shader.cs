using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SoftGLImpl {
    unsafe partial class SoftGL {

        /// <summary>
        /// name -> ShaderProgram object.
        /// </summary>
        private readonly Dictionary<uint, GLShader> nameShaderDict = new Dictionary<uint, GLShader>();

        public static GLuint glCreateShader(GLenum shaderType) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return 0; }

            if (!Enum.IsDefined(typeof(GLShader.Kind), shaderType)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return 0; }

            var name = context.nextShaderName;
            var shader = GLShader.Create(shaderType, name);
            ArgumentNullException.ThrowIfNull(shader);
            context.name2Shader.Add(name, shader);
            context.nextShaderName++;

            return name;
        }

        public static unsafe void glShaderSource(GLuint name, GLsizei count, IntPtr* codes, GLint* lengths) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (name == 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (!context.name2Shader.TryGetValue(name, out var shader)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < count; i++) { // byte in C# matches char in C.
                var segment = (byte*)codes[i]; var length = lengths[i];
                for (int j = 0; j < length; j++) {
                    var c = (char)(segment[j]);
                    builder.Append(c);
                }
                //var str = new string((char*)codes[i]);
                //builder.AppendLine(str);
                builder.AppendLine();
            }
            shader.Code = builder.ToString();
        }

        public static void glCompileShader(GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (name == 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (!context.name2Shader.TryGetValue(name, out var shader)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            shader.Compile();
        }

        public static unsafe void glGetShaderiv(GLuint name, GLenum pname, GLint* pValues) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (name == 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (!context.name2Shader.TryGetValue(name, out var shader)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (!Enum.IsDefined(typeof(ShaderStatus), pname)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }

            shader.GetShaderStatus((ShaderStatus)pname, pValues);
        }

        public static unsafe void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, GLsizei* length, byte* infoLog) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (shader == 0 || bufSize < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (!context.name2Shader.TryGetValue(shader, out var shaderObj)) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            throw new NotImplementedException();
        }
    }

    enum ShaderStatus : uint {
        ShaderType = GL.GL_SHADER_TYPE,
        DeleteStatus = GL.GL_DELETE_STATUS,
        CompileStatus = GL.GL_COMPILE_STATUS,
        InfoLogLength = GL.GL_INFO_LOG_LENGTH,
        ShaderSourceLength = GL.GL_SHADER_SOURCE_LENGTH
    }
}
