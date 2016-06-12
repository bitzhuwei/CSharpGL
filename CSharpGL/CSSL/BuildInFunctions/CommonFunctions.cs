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
        //TODO: add build in functions
        //TODO: replace – with -
        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float abs(double x) { return 0.0f; }
        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 abs(vec2 x) { return null; }
        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 abs(vec3 x) { return null; }
        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 abs(vec4 x) { return null; }

        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int abs(int x) { return 0; }
        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ivec2 abs(ivec2 x) { return null; }
        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ivec3 abs(ivec3 x) { return null; }
        /// <summary>
        /// Returns x if x >= 0; otherwise, it
        /// returns –x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ivec4 abs(ivec4 x) { return null; }

        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float sign(float x) { return 0; }
        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 sign(vec2 x) { return null; }
        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 sign(vec3 x) { return null; }
        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 sign(vec4 x) { return null; }
        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int sign(int x) { return 0; }
        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ivec2 sign(ivec2 x) { return null; }
        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ivec3 sign(ivec3 x) { return null; }
        /// <summary>
        /// Returns 1.0 if x > 0, 0.0 if x = 0,
        /// or -1.0 if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ivec4 sign(ivec4 x) { return null; }


    }
}