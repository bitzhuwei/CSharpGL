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
        /// <summary>
        /// Returns x raised to the y power, i.e., x^y. Results
        /// are undefined if x < 0. Results are undefined if
        /// x = 0 and y = 0.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float pow(double x, double y) { return 0.0f; }
        /// <summary>
        /// Returns x raised to the y power, i.e., x^y. Results
        /// are undefined if x < 0. Results are undefined if
        /// x = 0 and y = 0.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec2 pow(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns x raised to the y power, i.e., x^y. Results
        /// are undefined if x < 0. Results are undefined if
        /// x = 0 and y = 0.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec3 pow(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns x raised to the y power, i.e., x^y. Results
        /// are undefined if x < 0. Results are undefined if
        /// x = 0 and y = 0.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec4 pow(vec4 x, vec4 y) { return null; }

        /// <summary>
        /// Returns the natural exponentiation of x, i.e., e^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float exp(double x) { return 0.0f; }
        /// <summary>
        /// Returns the natural exponentiation of x, i.e., e^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 exp(vec2 x) { return null; }
        /// <summary>
        /// Returns the natural exponentiation of x, i.e., e^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 exp(vec3 x) { return null; }
        /// <summary>
        /// Returns the natural exponentiation of x, i.e., e^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 exp(vec4 x) { return null; }

    }
}
