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

        public static vec2 vec2(double v0) { return null; }
        public static vec2 vec2(double v1, double v2) { return null; }
        public static vec2 vec2(vec2 v1) { return null; }
        public static vec2 vec2(vec3 v1) { return null; }
        public static vec2 vec2(vec4 v1) { return null; }
        public static vec3 vec3(double v0) { return null; }
        public static vec3 vec3(double v1, double v2, double v3) { return null; }
        public static vec3 vec3(vec2 v1, double v2) { return null; }
        public static vec3 vec3(double v1, vec2 v2) { return null; }
        public static vec3 vec3(vec3 v1) { return null; }
        public static vec3 vec3(vec4 v1) { return null; }
        public static vec4 vec4(double v0) { return null; }
        public static vec4 vec4(double v1, double v2, double v3, double v4) { return null; }
        public static vec4 vec4(vec2 v2, double v3, double v4) { return null; }
        public static vec4 vec4(vec2 v2, vec2 v4) { return null; }
        public static vec4 vec4(double v1, vec2 v3, double v4) { return null; }
        public static vec4 vec4(double v1, double v2, vec2 v4) { return null; }
        public static vec4 vec4(vec3 v3, double v4) { return null; }
        public static vec4 vec4(double v1, vec3 v4) { return null; }
        public static vec4 vec4(vec4 v1) { return null; }


        public static vec4 texture(sampler1D texture, double uv) { return null; }
        public static vec4 texture(sampler2D texture, vec2 uv) { return null; }
        public static vec4 texture(sampler3D texture, vec3 uv) { return null; }


        #endregion

        #region matrix functions




        /// <summary>
        /// float()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [BuildInFunction("float")]
        public static float float__(double value) { return 0.0f; }

        /// <summary>
        /// int()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [BuildInFunction("int")]
        public static float int__(double value) { return 0; }

        /// <summary>
        /// uint()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [BuildInFunction("uint")]
        public static float uint__(double value) { return 0; }

        public static mat4 mat4(double value) { return null; }

        #endregion matrix functions

        #region others


        public static vec4 texture1D(sampler1D simplexTexture, double sindex) { return null; }
        public static vec4 texture2D(sampler2D simplexTexture, vec2 sindex) { return null; }
        public static vec4 texture3D(sampler3D simplexTexture, vec3 sindex) { return null; }


        #endregion others
    }
}
