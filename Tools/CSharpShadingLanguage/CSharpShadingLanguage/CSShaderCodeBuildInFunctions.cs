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

        public static vec2 vec2(float v1, float v2) { return new vec2(v1, v2); }
        public static vec2 vec2(vec2 v1) { return new vec2(v1.x, v1.y); }
        public static vec2 vec2(vec3 v1) { return new vec2(v1.x, v1.y); }
        public static vec2 vec2(vec4 v1) { return new vec2(v1.x, v1.y); }
        public static vec3 vec3(float v1, float v2, float v3) { return new vec3(v1, v2, v3); }
        public static vec3 vec3(vec2 v1, float v2) { return new vec3(v1.x, v1.y, v2); }
        public static vec3 vec3(float v1, vec2 v2) { return new vec3(v1, v2.x, v2.y); }
        public static vec3 vec3(vec3 v1) { return new vec3(v1.x, v1.y, v1.z); }
        public static vec3 vec3(vec4 v1) { return new vec3(v1.x, v1.y, v1.z); }
        public static vec4 vec4(float v1, float v2, float v3, float v4) { return new vec4(v1, v2, v3, v4); }
        public static vec4 vec4(vec2 v2, float v3, float v4) { return new vec4(v2.x, v2.y, v3, v4); }
        public static vec4 vec4(vec2 v2, vec2 v4) { return new vec4(v2.x, v2.y, v4.x, v4.y); }
        public static vec4 vec4(float v1, vec2 v3, float v4) { return new vec4(v1, v3.x, v3.y, v4); }
        public static vec4 vec4(float v1, float v2, vec2 v4) { return new vec4(v1, v2, v4.x, v4.y); }
        public static vec4 vec4(vec3 v3, float v4) { return new vec4(v3.x, v3.y, v3.z, v4); }
        public static vec4 vec4(float v1, vec3 v4) { return new vec4(v1, v4.x, v4.y, v4.z); }
        public static vec4 vec4(vec4 v1) { return new vec4(v1.x, v1.y, v1.z, v1.w); }


        public static vec4 texture(sampler1D texture, float uv) { throw new NotNeedToImplementException(); }
        public static vec4 texture(sampler2D texture, vec2 uv) { throw new NotNeedToImplementException(); }
        public static vec4 texture(sampler3D texture, vec3 uv) { throw new NotNeedToImplementException(); }

        public static vec2 normalize(vec2 v) { return v.normalize(); }
        public static vec3 normalize(vec3 v) { return v.normalize(); }
        public static vec4 normalize(vec4 v) { return v.normalize(); }

        public static float dot(vec2 v1, vec2 v2) { return v1.dot(v2); }
        public static float dot(vec3 v1, vec3 v2) { return v1.dot(v2); }
        public static float dot(vec4 v1, vec4 v2) { return v1.dot(v2); }

        public static float max(float a, float b) { return Math.Max(a, b); }

        public static float pow(float a, float b) { return (float)Math.Pow(a, b); }

        #endregion

        #region matrix functions

        public static mat2 inverse(mat2 matrix) { throw new NotNeedToImplementException(); }
        public static mat3 inverse(mat3 matrix) { throw new NotNeedToImplementException(); }
        public static mat4 inverse(mat4 matrix) { throw new NotNeedToImplementException(); }

        public static mat2 transpose(mat2 matrix) { throw new NotNeedToImplementException(); }
        public static mat3 transpose(mat3 matrix) { throw new NotNeedToImplementException(); }
        public static mat4 transpose(mat4 matrix) { throw new NotNeedToImplementException(); }


        [BuildInFunction("float")]
        public static float Float(float value) { return value; }

        [BuildInFunction("int")]
        public static float Int(float value) { return value; }

        [BuildInFunction("uint")]
        public static float Uint(float value) { return value; }

        public static mat4 mat4(float value) { return new mat4(value); }

        #endregion matrix functions

        #region others

        public static float mix(float x, float y, float a) { throw new NotNeedToImplementException(); }
        public static vec2 mix(vec2 x, vec2 y, float a) { throw new NotNeedToImplementException(); }
        public static vec3 mix(vec3 x, vec3 y, float a) { throw new NotNeedToImplementException(); }
        public static vec4 mix(vec4 x, vec4 y, float a) { throw new NotNeedToImplementException(); }

        public static float clamp(float x, float minVal, float maxVal) { throw new NotNeedToImplementException(); }
        public static vec2 clamp(vec2 x, float minVal, float maxVal) { throw new NotNeedToImplementException(); }
        public static vec3 clamp(vec3 x, float minVal, float maxVal) { throw new NotNeedToImplementException(); }
        public static vec4 clamp(vec4 x, float minVal, float maxVal) { throw new NotNeedToImplementException(); }

        #endregion others
    }
}
