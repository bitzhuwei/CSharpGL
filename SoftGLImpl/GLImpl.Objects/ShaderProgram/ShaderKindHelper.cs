using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    //enum ShaderType : uint
    //{
    //    VertexShader = GL.GL_VERTEX_SHADER,
    //    TessControlShader = GL.GL_TESS_CONTROL_SHADER,
    //    TessEvaluationShader = GL.GL_TESS_EVALUATION_SHADER,
    //    GeometryShader = GL.GL_GEOMETRY_SHADER,
    //    FragmentShader = GL.GL_FRAGMENT_SHADER,
    //    ComputeShader = GL.GL_COMPUTE_SHADER
    //}

    static class ShaderKindHelper {
        /// <summary>
        /// mapping from shader type to shader code type.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <returns></returns>
        public static Type GetShaderCodeType(this GLShader.Kind shaderType) {
            Type? type = null;
            switch (shaderType) {
            case GLShader.Kind.VertexShader: type = typeof(VertexCodeBase); break;
            case GLShader.Kind.TessControlShader: type = typeof(TessControlCodeBase); break;
            case GLShader.Kind.TessEvaluationShader: type = typeof(TessEvaluationCodeBase); break;
            case GLShader.Kind.GeometryShader: type = typeof(GeometryCodeBase); break;
            case GLShader.Kind.FragmentShader: type = typeof(FragmentCodeBase); break;
            case GLShader.Kind.ComputeShader: type = typeof(ComputeCodeBase); break;
            default:
            throw new NotImplementedException();
            }

            return type;
        }

        public static string GetIDName(this GLShader.Kind shaderType) {
            string result = string.Empty;
            switch (shaderType) {
            case GLShader.Kind.VertexShader: result = "gl_VertexID"; break;
            case GLShader.Kind.TessControlShader:
            break;
            case GLShader.Kind.TessEvaluationShader:
            break;
            case GLShader.Kind.GeometryShader:
            break;
            case GLShader.Kind.FragmentShader: result = "fragmentID"; break;
            case GLShader.Kind.ComputeShader:
            break;
            default:
            break;
            }

            if (result == string.Empty) { throw new NotImplementedException(); }

            return result;
        }
    }
}
