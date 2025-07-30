
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glu {
        public static string ErrorString(GLenum error) {
            switch (error) {
            case GL.GL_NO_ERROR:
            return "No error";
            case GL.GL_INVALID_ENUM:
            return "Invalid enum";
            case GL.GL_INVALID_VALUE:
            return "Invalid value";
            case GL.GL_INVALID_OPERATION:
            return "Invalid operation";
            case GL.GL_STACK_OVERFLOW:
            return "Stack overflow";
            case GL.GL_STACK_UNDERFLOW:
            return "Stack underflow";
            case GL.GL_OUT_OF_MEMORY:
            return "Out of memory";
            //case GL.GL_TABLE_TOO_LARGE:
            //return "Table too large";  // GLU-specific error
            default:
            return $"errorCode:{error}";  // 无效错误代码
            }
        }
    }
}