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

        /// <summary>
        /// Returns the natural logarithm of x, i.e., returns
        /// the value y, which satisfies the equation x = e^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float log(double x) { return 0.0f; }
        /// <summary>
        /// Returns the natural logarithm of x, i.e., returns
        /// the value y, which satisfies the equation x = e^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 log(vec2 x) { return null; }
        /// <summary>
        /// Returns the natural logarithm of x, i.e., returns
        /// the value y, which satisfies the equation x = e^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 log(vec3 x) { return null; }
        /// <summary>
        /// Returns the natural logarithm of x, i.e., returns
        /// the value y, which satisfies the equation x = e^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 log(vec4 x) { return null; }

        /// <summary>
        /// Returns 2 raised to the x power, i.e., 2^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float exp2(double x) { return 0.0f; }
        /// <summary>
        /// Returns 2 raised to the x power, i.e., 2^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 exp2(vec2 x) { return null; }
        /// <summary>
        /// Returns 2 raised to the x power, i.e., 2^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 exp2(vec3 x) { return null; }
        /// <summary>
        /// Returns 2 raised to the x power, i.e., 2^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 exp2(vec4 x) { return null; }

        /// <summary>
        /// Returns the base 2 log of x, i.e., returns the
        /// value y, which satisfies the equation x = 2^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float log2(double x) { return 0.0f; }
        /// <summary>
        /// Returns the base 2 log of x, i.e., returns the
        /// value y, which satisfies the equation x = 2^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 log2(vec2 x) { return null; }
        /// <summary>
        /// Returns the base 2 log of x, i.e., returns the
        /// value y, which satisfies the equation x = 2^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 log2(vec3 x) { return null; }
        /// <summary>
        /// Returns the base 2 log of x, i.e., returns the
        /// value y, which satisfies the equation x = 2^y.
        /// Results are undefined if x <= 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 log2(vec4 x) { return null; }

        /// <summary>
        /// Returns the positive square root of x. Results
        /// are undefined if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float sqrt(double x) { return 0.0f; }
        /// <summary>
        /// Returns the positive square root of x. Results
        /// are undefined if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 sqrt(vec2 x) { return null; }
        /// <summary>
        /// Returns the positive square root of x. Results
        /// are undefined if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 sqrt(vec3 x) { return null; }
        /// <summary>
        /// Returns the positive square root of x. Results
        /// are undefined if x < 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 sqrt(vec4 x) { return null; }

    }
}
