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
        /// Converts degrees to radians and returns the
        /// result, i.e., result = π/180 * degrees.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static float radians(double degrees) { return 0.0f; }
        /// <summary>
        /// Converts degrees to radians and returns the
        /// result, i.e., result = π/180 * degrees.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static vec2 radians(vec2 degrees) { return null; }
        /// <summary>
        /// Converts degrees to radians and returns the
        /// result, i.e., result = π/180 * degrees.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static vec3 radians(vec3 degrees) { return null; }
        /// <summary>
        /// Converts degrees to radians and returns the
        /// result, i.e., result = π/180 * degrees.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static vec4 radians(vec4 degrees) { return null; }

        /// <summary>
        /// Converts radians to degrees and returns the
        /// result, i.e., result = 180 / π * radians.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float degrees(double radians) { return 0.0f; }
        /// <summary>
        /// Converts radians to degrees and returns the
        /// result, i.e., result = 180 / π * radians.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec2 degrees(vec2 radians) { return null; }
        /// <summary>
        /// Converts radians to degrees and returns the
        /// result, i.e., result = 180 / π * radians.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec3 degrees(vec3 radians) { return null; }
        /// <summary>
        /// Converts radians to degrees and returns the
        /// result, i.e., result = 180 / π * radians.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec4 degrees(vec4 radians) { return null; }

        /// <summary>
        /// The standard trigonometric sine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float sin(double radians) { return 0.0f; }
        /// <summary>
        /// The standard trigonometric sine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec2 sin(vec2 radians) { return null; }
        /// <summary>
        /// The standard trigonometric sine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec3 sin(vec3 radians) { return null; }
        /// <summary>
        /// The standard trigonometric sine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec4 sin(vec4 radians) { return null; }

        /// <summary>
        /// The standard trigonometric cosine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float cos(double radians) { return 0.0f; }
        /// <summary>
        /// The standard trigonometric cosine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec2 cos(vec2 radians) { return null; }
        /// <summary>
        /// The standard trigonometric cosine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec3 cos(vec3 radians) { return null; }
        /// <summary>
        /// The standard trigonometric cosine function.
        /// The values returned by this function are in the range [-1,1].
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec4 cos(vec4 radians) { return null; }

        /// <summary>
        /// The standard trigonometric tangent function.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float tan(double radians) { return 0.0f; }
        /// <summary>
        /// The standard trigonometric tangent function.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec2 tan(vec2 radians) { return null; }
        /// <summary>
        /// The standard trigonometric tangent function.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec3 tan(vec3 radians) { return null; }
        /// <summary>
        /// The standard trigonometric tangent function.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec4 tan(vec4 radians) { return null; }

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x.
        /// The range of values returned by this function
        /// is [-π / 2, π / 2]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float asin(double radians) { return 0.0f; }
        /// <summary>
        /// Arc sine. Returns an angle whose sine is x.
        /// The range of values returned by this function
        /// is [-π / 2, π / 2]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec2 asin(vec2 radians) { return null; }
        /// <summary>
        /// Arc sine. Returns an angle whose sine is x.
        /// The range of values returned by this function
        /// is [-π / 2, π / 2]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec3 asin(vec3 radians) { return null; }
        /// <summary>
        /// Arc sine. Returns an angle whose sine is x.
        /// The range of values returned by this function
        /// is [-π / 2, π / 2]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec4 asin(vec4 radians) { return null; }

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x.
        /// The range of values returned by this function is
        /// [0, π]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float acos(double radians) { return 0.0f; }
        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x.
        /// The range of values returned by this function is
        /// [0, π]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec2 acos(vec2 radians) { return null; }
        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x.
        /// The range of values returned by this function is
        /// [0, π]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec3 acos(vec3 radians) { return null; }
        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x.
        /// The range of values returned by this function is
        /// [0, π]. Results are undefined if |x| > 1.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static vec4 acos(vec4 radians) { return null; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y/x. The signs of x and y determine what
        /// quadrant the angle is in. The range of values
        /// returned by this function is [-π, π]. Results are
        /// undefined if x and y are both 0.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float atan(double y, double x) { return 0.0f; }
        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y/x. The signs of x and y determine what
        /// quadrant the angle is in. The range of values
        /// returned by this function is [-π, π]. Results are
        /// undefined if x and y are both 0.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 atan(vec2 y, vec2 x) { return null; }
        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y/x. The signs of x and y determine what
        /// quadrant the angle is in. The range of values
        /// returned by this function is [-π, π]. Results are
        /// undefined if x and y are both 0.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 atan(vec3 y, vec3 x) { return null; }
        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y/x. The signs of x and y determine what
        /// quadrant the angle is in. The range of values
        /// returned by this function is [-π, π]. Results are
        /// undefined if x and y are both 0.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 atan(vec4 y, vec4 x) { return null; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y_over_x. The range of values returned by this
        /// function is [-π / 2, π / 2]
        /// </summary>
        /// <param name="y_over_x"></param>
        /// <returns></returns>
        public static float atan(double y_over_x) { return 0.0f; }
        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y_over_x. The range of values returned by this
        /// function is [-π / 2, π / 2]
        /// </summary>
        /// <param name="y_over_x"></param>
        /// <returns></returns>
        public static vec2 atan(vec2 y_over_x) { return null; }
        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y_over_x. The range of values returned by this
        /// function is [-π / 2, π / 2]
        /// </summary>
        /// <param name="y_over_x"></param>
        /// <returns></returns>
        public static vec3 atan(vec3 y_over_x) { return null; }
        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is
        /// y_over_x. The range of values returned by this
        /// function is [-π / 2, π / 2]
        /// </summary>
        /// <param name="y_over_x"></param>
        /// <returns></returns>
        public static vec4 atan(vec4 y_over_x) { return null; }

        /// <summary>
        /// Hyperbolic sine. Returns (e^x - e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float sinh(double x) { return 0.0f; }
        /// <summary>
        /// Hyperbolic sine. Returns (e^x - e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 sinh(vec2 x) { return null; }
        /// <summary>
        /// Hyperbolic sine. Returns (e^x - e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 sinh(vec3 x) { return null; }
        /// <summary>
        /// Hyperbolic sine. Returns (e^x - e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 sinh(vec4 x) { return null; }

        /// <summary>
        /// Hyperbolic cosine. Returns (e^x + e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float cosh(double x) { return 0.0f; }
        /// <summary>
        /// Hyperbolic cosine. Returns (e^x + e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 cosh(vec2 x) { return null; }
        /// <summary>
        /// Hyperbolic cosine. Returns (e^x + e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 cosh(vec3 x) { return null; }
        /// <summary>
        /// Hyperbolic cosine. Returns (e^x + e^(-x)) / 2.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 cosh(vec4 x) { return null; }

        /// <summary>
        /// Hyperbolic tangent. Returns (e^x - e^(-x)) / (e^x + e^(-x)).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float tanh(double x) { return 0.0f; }
        /// <summary>
        /// Hyperbolic tangent. Returns (e^x - e^(-x)) / (e^x + e^(-x)).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 tanh(vec2 x) { return null; }
        /// <summary>
        /// Hyperbolic tangent. Returns (e^x - e^(-x)) / (e^x + e^(-x)).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 tanh(vec3 x) { return null; }
        /// <summary>
        /// Hyperbolic tangent. Returns (e^x - e^(-x)) / (e^x + e^(-x)).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 tanh(vec4 x) { return null; }

        /// <summary>
        /// Arc hyperbolic sine. Returns the inverse of sinh.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float asinh(double x) { return 0.0f; }
        /// <summary>
        /// Arc hyperbolic sine. Returns the inverse of sinh.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 asinh(vec2 x) { return null; }
        /// <summary>
        /// Arc hyperbolic sine. Returns the inverse of sinh.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 asinh(vec3 x) { return null; }
        /// <summary>
        /// Arc hyperbolic sine. Returns the inverse of sinh.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 asinh(vec4 x) { return null; }

        /// <summary>
        /// Arc hyperbolic cosine. Returns the non-negative
        /// inverse of cosh. Results are undefined if x < 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float acosh(double x) { return 0.0f; }
        /// <summary>
        /// Arc hyperbolic cosine. Returns the non-negative
        /// inverse of cosh. Results are undefined if x < 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 acosh(vec2 x) { return null; }
        /// <summary>
        /// Arc hyperbolic cosine. Returns the non-negative
        /// inverse of cosh. Results are undefined if x < 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 acosh(vec3 x) { return null; }
        /// <summary>
        /// Arc hyperbolic cosine. Returns the non-negative
        /// inverse of cosh. Results are undefined if x < 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 acosh(vec4 x) { return null; }

        /// <summary>
        /// Arc hyperbolic tangent. Returns the inverse of
        /// tanh. Results are undefined if |x| &gt;= 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float atanh(double x) { return 0.0f; }
        /// <summary>
        /// Arc hyperbolic tangent. Returns the inverse of
        /// tanh. Results are undefined if |x| &gt;= 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 atanh(vec2 x) { return null; }
        /// <summary>
        /// Arc hyperbolic tangent. Returns the inverse of
        /// tanh. Results are undefined if |x| &gt;= 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 atanh(vec3 x) { return null; }
        /// <summary>
        /// Arc hyperbolic tangent. Returns the inverse of
        /// tanh. Results are undefined if |x| &gt;= 1.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 atanh(vec4 x) { return null; }

    }
}
