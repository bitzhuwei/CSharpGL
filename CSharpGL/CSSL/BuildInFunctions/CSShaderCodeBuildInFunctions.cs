using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// 所有CSSL都共有的内容。
    /// </summary>
    public abstract partial class CSShaderCode
    {

        #region build-in functions

        public static vec2 vec2(float v1, float v2) { return null; }
        public static vec2 vec2(vec2 v1) { return null; }
        public static vec2 vec2(vec3 v1) { return null; }
        public static vec2 vec2(vec4 v1) { return null; }
        public static vec3 vec3(float v1, float v2, float v3) { return null; }
        public static vec3 vec3(vec2 v1, float v2) { return null; }
        public static vec3 vec3(float v1, vec2 v2) { return null; }
        public static vec3 vec3(vec3 v1) { return null; }
        public static vec3 vec3(vec4 v1) { return null; }
        public static vec4 vec4(float v1, float v2, float v3, float v4) { return null; }
        public static vec4 vec4(vec2 v2, float v3, float v4) { return null; }
        public static vec4 vec4(vec2 v2, vec2 v4) { return null; }
        public static vec4 vec4(float v1, vec2 v3, float v4) { return null; }
        public static vec4 vec4(float v1, float v2, vec2 v4) { return null; }
        public static vec4 vec4(vec3 v3, float v4) { return null; }
        public static vec4 vec4(float v1, vec3 v4) { return null; }
        public static vec4 vec4(vec4 v1) { return null; }


        public static vec4 texture(sampler1D texture, float uv) { return null; }
        public static vec4 texture(sampler2D texture, vec2 uv) { return null; }
        public static vec4 texture(sampler3D texture, vec3 uv) { return null; }

        public static vec2 normalize(vec2 v) { return null; }
        public static vec3 normalize(vec3 v) { return null; }
        public static vec4 normalize(vec4 v) { return null; }

        public static float dot(vec2 v1, vec2 v2) { return 0.0f; }
        public static float dot(vec3 v1, vec3 v2) { return 0.0f; }
        public static float dot(vec4 v1, vec4 v2) { return 0.0f; }

        public static float max(float a, float b) { return 0.0f; }

        public static float pow(float a, float b) { return 0.0f; }

        #endregion

        #region matrix functions

        public static mat2 inverse(mat2 matrix) { return null; }
        public static mat3 inverse(mat3 matrix) { return null; }
        public static mat4 inverse(mat4 matrix) { return null; }

        public static mat2 transpose(mat2 matrix) { return null; }
        public static mat3 transpose(mat3 matrix) { return null; }
        public static mat4 transpose(mat4 matrix) { return null; }


        /// <summary>
        /// float()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [BuildInFunction("float")]
        public static float float__(float value) { return 0.0f; }

        /// <summary>
        /// int()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [BuildInFunction("int")]
        public static float int__(float value) { return 0; }

        /// <summary>
        /// uint()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [BuildInFunction("uint")]
        public static float uint__(float value) { return 0; }

        public static mat4 mat4(float value) { return null; }

        #endregion matrix functions

        #region others

        public static float mix(float x, float y, float a) { return 0.0f; }
        public static vec2 mix(vec2 x, vec2 y, float a) { return null; }
        public static vec3 mix(vec3 x, vec3 y, float a) { return null; }
        public static vec4 mix(vec4 x, vec4 y, float a) { return null; }

        public static float clamp(float x, float minVal, float maxVal){ return 0.0f; }
        public static vec2 clamp(vec2 x, float minVal, float maxVal) { return null; }
        public static vec3 clamp(vec3 x, float minVal, float maxVal) { return null; }
        public static vec4 clamp(vec4 x, float minVal, float maxVal) { return null; }

        public static float length(vec2 v) { return 0.0f; }
        public static float length(vec3 v) { return 0.0f; }
        public static float length(vec4 v) { return 0.0f; }

        #endregion others
    }
}
