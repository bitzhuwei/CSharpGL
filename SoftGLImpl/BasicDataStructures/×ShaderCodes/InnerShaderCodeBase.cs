using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public abstract unsafe class InnerShaderCodeBase : ICloneable {
        //public abstract void main();

        #region ICloneable 成员

        public object Clone() {
            return this.MemberwiseClone();
        }

        #endregion
    }

    static class InnerShaderTypeHelper {
        /// <summary>
        /// mapping from shader type to shader code type.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <returns></returns>
        public static Type GetShaderCodeBaseType(this Shader.Kind shaderType) {
            Type? type = null;
            switch (shaderType) {
            case Shader.Kind.VertexShader: type = typeof(InnerVertexShaderCodeBase); break;
            case Shader.Kind.TessControlShader: type = typeof(InnerTessControlShaderCodeBase); break;
            case Shader.Kind.TessEvaluationShader: type = typeof(InnerTessEvaluationShaderCodeBase); break;
            case Shader.Kind.GeometryShader: type = typeof(InnerGeometryShaderCodeBase); break;
            case Shader.Kind.FragmentShader: type = typeof(InnerFragmentShaderCodeBase); break;
            case Shader.Kind.ComputeShader: type = typeof(InnerComputeShaderCodeBase); break;
            default:
            throw new NotImplementedException();
            }

            return type;
        }
    }
}
