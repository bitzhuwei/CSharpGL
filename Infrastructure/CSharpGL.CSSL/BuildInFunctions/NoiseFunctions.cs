using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.CSSL
{
    /// <summary>
    /// 所有CSSL都共有的内容。
    /// </summary>
    public abstract partial class CSShaderCode
    {

        /// <summary>
        /// Returns a 1D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float noise1(double x) { return 0.0f; }
        /// <summary>
        /// Returns a 1D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float noise1(vec2 x) { return 0.0f; }
        /// <summary>
        /// Returns a 1D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float noise1(vec3 x) { return 0.0f; }
        /// <summary>
        /// Returns a 1D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float noise1(vec4 x) { return 0.0f; }

        /// <summary>
        /// Returns a 2D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 noise2(double x) { return null; }
        /// <summary>
        /// Returns a 2D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 noise2(vec2 x) { return null; }
        /// <summary>
        /// Returns a 2D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 noise2(vec3 x) { return null; }
        /// <summary>
        /// Returns a 2D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 noise2(vec4 x) { return null; }

        /// <summary>
        /// Returns a 3D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 noise3(double x) { return null; }
        /// <summary>
        /// Returns a 3D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 noise3(vec2 x) { return null; }
        /// <summary>
        /// Returns a 3D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 noise3(vec3 x) { return null; }
        /// <summary>
        /// Returns a 3D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 noise3(vec4 x) { return null; }

        /// <summary>
        /// Returns a 4D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 noise4(double x) { return null; }
        /// <summary>
        /// Returns a 4D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 noise4(vec2 x) { return null; }
        /// <summary>
        /// Returns a 4D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 noise4(vec3 x) { return null; }
        /// <summary>
        /// Returns a 4D noise value based on the input value x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 noise4(vec4 x) { return null; }

    }
}