using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShadingLanguage
{
    /// <summary>
    /// 所有CSSL都共有的内容。
    /// </summary>
    public abstract partial class CSShaderCode
    {

        #region build-in functions

        protected vec2 vec2(float v1, float v2) { throw new NotNeedToImplementException(); }
        protected vec2 vec2(vec2 v1) { throw new NotNeedToImplementException(); }
        protected vec2 vec2(vec3 v1) { throw new NotNeedToImplementException(); }
        protected vec2 vec2(vec4 v1) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(float v1, float v2, float v3) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(vec2 v1, float v2) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(float v1, vec2 v2) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(vec3 v1) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(vec4 v1) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(float v1, float v2, float v3, float v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(vec2 v2, float v3, float v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(vec2 v2, vec2 v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(float v1, vec2 v3, float v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(float v1, float v2, vec2 v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(vec3 v3, float v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(float v1, vec3 v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(vec4 v1) { throw new NotNeedToImplementException(); }


        protected vec4 texture(sampler1D texture, float uv) { throw new NotNeedToImplementException(); }
        protected vec4 texture(sampler2D texture, vec2 uv) { throw new NotNeedToImplementException(); }
        protected vec4 texture(sampler3D texture, vec3 uv) { throw new NotNeedToImplementException(); }

        protected vec2 normalize(vec2 v) { throw new NotNeedToImplementException(); }
        protected vec3 normalize(vec3 v) { throw new NotNeedToImplementException(); }
        protected vec4 normalize(vec4 v) { throw new NotNeedToImplementException(); }

        protected float dot(vec2 v1, vec2 v2) { throw new NotNeedToImplementException(); }
        protected float dot(vec3 v1, vec3 v2) { throw new NotNeedToImplementException(); }
        protected float dot(vec4 v1, vec4 v2) { throw new NotNeedToImplementException(); }

        protected float max(float a, float b) { throw new NotNeedToImplementException(); }

        protected float pow(float a, float b) { throw new NotNeedToImplementException(); }

        #endregion

        #region matrix functions

        protected mat2 inverse(mat2 matrix) { throw new NotNeedToImplementException(); }
        protected mat3 inverse(mat3 matrix) { throw new NotNeedToImplementException(); }
        protected mat4 inverse(mat4 matrix) { throw new NotNeedToImplementException(); }

        protected mat2 transpose(mat2 matrix) { throw new NotNeedToImplementException(); }
        protected mat3 transpose(mat3 matrix) { throw new NotNeedToImplementException(); }
        protected mat4 transpose(mat4 matrix) { throw new NotNeedToImplementException(); }


        [BuildInFunction("float")]
        protected float Float(float value) { throw new NotNeedToImplementException(); }

        #endregion matrix functions

    }
}
