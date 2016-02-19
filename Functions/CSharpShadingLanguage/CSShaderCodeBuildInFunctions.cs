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

        protected static vec2 vec2(float v1, float v2) { return new vec2() { x = v1, y = v2, }; }
        protected static vec2 vec2(vec2 v1) { return new vec2() { x = v1.x, y = v1.y, }; }
        protected static vec2 vec2(vec3 v1) { return new vec2() { x = v1.x, y = v1.y, }; }
        protected static vec2 vec2(vec4 v1) { return new vec2() { x = v1.x, y = v1.y, }; }
        protected static vec3 vec3(float v1, float v2, float v3) { return new vec3() { x = v1, y = v2, z = v3, }; }
        protected static vec3 vec3(vec2 v1, float v2) { return new vec3() { x = v1.x, y = v1.x, z = v2, }; }
        protected static vec3 vec3(float v1, vec2 v2) { return new vec3() { x = v1, y = v2.x, z = v2.y, }; }
        protected static vec3 vec3(vec3 v1) { return new vec3() { x = v1.x, y = v1.y, z = v1.z, }; }
        protected static vec3 vec3(vec4 v1) { return new vec3() { x = v1.x, y = v1.y, z = v1.z, }; }
        protected static vec4 vec4(float v1, float v2, float v3, float v4) { return new vec4() { x = v1, y = v2, z = v3, w = v4, }; }
        protected static vec4 vec4(vec2 v2, float v3, float v4) { return new vec4() { x = v2.x, y = v2.y, z = v3, w = v4, }; }
        protected static vec4 vec4(vec2 v2, vec2 v4) { return new vec4() { x = v2.x, y = v2.y, z = v4.x, w = v4.y, }; }
        protected static vec4 vec4(float v1, vec2 v3, float v4) { return new vec4() { x = v1, y = v3.x, z = v3.y, w = v4, }; }
        protected static vec4 vec4(float v1, float v2, vec2 v4) { return new vec4() { x = v1, y = v2, z = v4.x, w = v4.y, }; }
        protected static vec4 vec4(vec3 v3, float v4) { return new vec4() { x = v3.x, y = v3.y, z = v3.z, w = v4, }; }
        protected static vec4 vec4(float v1, vec3 v4) { return new vec4() { x = v1, y = v4.x, z = v4.y, w = v4.z, }; }
        protected static vec4 vec4(vec4 v1) { return new vec4() { x = v1.x, y = v1.y, z = v1.z, w = v1.w, }; }


        protected static vec4 texture(sampler1D texture, float uv) { throw new NotNeedToImplementException(); }
        protected static vec4 texture(sampler2D texture, vec2 uv) { throw new NotNeedToImplementException(); }
        protected static vec4 texture(sampler3D texture, vec3 uv) { throw new NotNeedToImplementException(); }

        protected static vec2 normalize(vec2 v) { return v.normalize(); }
        protected static vec3 normalize(vec3 v) { return v.normalize(); }
        protected static vec4 normalize(vec4 v) { return v.normalize(); }

        protected static float dot(vec2 v1, vec2 v2) { return v1.dot(v2); }
        protected static float dot(vec3 v1, vec3 v2) { return v1.dot(v2); }
        protected static float dot(vec4 v1, vec4 v2) { return v1.dot(v2); }

        protected static float max(float a, float b) { return Math.Max(a, b); }

        protected static float pow(float a, float b) { return (float)Math.Pow(a, b); }

        #endregion

        #region matrix functions

        protected static mat2 inverse(mat2 matrix) { throw new NotNeedToImplementException(); }
        protected static mat3 inverse(mat3 matrix) { throw new NotNeedToImplementException(); }
        protected static mat4 inverse(mat4 matrix) { throw new NotNeedToImplementException(); }

        protected static mat2 transpose(mat2 matrix) { throw new NotNeedToImplementException(); }
        protected static mat3 transpose(mat3 matrix) { throw new NotNeedToImplementException(); }
        protected static mat4 transpose(mat4 matrix) { throw new NotNeedToImplementException(); }


        [BuildInFunction("float")]
        protected static float Float(float value) { return value; }

        protected static mat4 mat4(float value) { return new mat4(value); }

        #endregion matrix functions

    }
}
