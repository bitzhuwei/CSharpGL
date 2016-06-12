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
        public static float sign(double x) { return 0; }
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

        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is less than or equal to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float floor(double x) { return 0.0f; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is less than or equal to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 floor(vec2 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is less than or equal to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 floor(vec3 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is less than or equal to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 floor(vec4 x) { return null; }

        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x whose absolute value is
        /// not larger than the absolute value
        /// of x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float trunc(double x) { return 0.0f; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x whose absolute value is
        /// not larger than the absolute value
        /// of x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 trunc(vec2 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x whose absolute value is
        /// not larger than the absolute value
        /// of x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 trunc(vec3 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x whose absolute value is
        /// not larger than the absolute value
        /// of x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 trunc(vec4 x) { return null; }

        /// <summary>
        /// Returns a value equal to the nearest
        /// integer of x. A fractional part of 0.5
        /// will round in an implementation
        /// direction.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float round(double x) { return 0.0f; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer of x. A fractional part of 0.5
        /// will round in an implementation
        /// direction.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 round(vec2 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer of x. A fractional part of 0.5
        /// will round in an implementation
        /// direction.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 round(vec3 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer of x. A fractional part of 0.5
        /// will round in an implementation
        /// direction.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 round(vec4 x) { return null; }

        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x. A fractional part of 0.5
        /// will round toward the nearest even
        /// integer. (Example: Both 3.5 and 4.5
        /// for x will return 4.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float roundEven(double x) { return 0.0f; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x. A fractional part of 0.5
        /// will round toward the nearest even
        /// integer. (Example: Both 3.5 and 4.5
        /// for x will return 4.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 roundEven(vec2 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x. A fractional part of 0.5
        /// will round toward the nearest even
        /// integer. (Example: Both 3.5 and 4.5
        /// for x will return 4.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 roundEven(vec3 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer to x. A fractional part of 0.5
        /// will round toward the nearest even
        /// integer. (Example: Both 3.5 and 4.5
        /// for x will return 4.0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 roundEven(vec4 x) { return null; }

        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is greater than or equal
        /// to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float ceil(double x) { return 0.0f; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is greater than or equal
        /// to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 ceil(vec2 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is greater than or equal
        /// to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 ceil(vec3 x) { return null; }
        /// <summary>
        /// Returns a value equal to the nearest
        /// integer that is greater than or equal
        /// to x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 ceil(vec4 x) { return null; }

        /// <summary>
        /// Returns x – floor (x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float fract(double x) { return 0.0f; }
        /// <summary>
        /// Returns x – floor (x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 fract(vec2 x) { return null; }
        /// <summary>
        /// Returns x – floor (x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 fract(vec3 x) { return null; }
        /// <summary>
        /// Returns x – floor (x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 fract(vec4 x) { return null; }

        /// <summary>
        /// Modulus. Returns x – y 􀀍 floor (x/y)
        /// for each component in x using the
        /// floating-point value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float mod(double x, double y) { return 0.0of; }
        /// <summary>
        /// Modulus. Returns x – y 􀀍 floor (x/y)
        /// for each component in x using the
        /// floating-point value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec2 mod(vec2 x, double y) { return null; }
        /// <summary>
        /// Modulus. Returns x – y 􀀍 floor (x/y)
        /// for each component in x using the
        /// floating-point value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec3 mod(vec3 x, double y) { return null; }
        /// <summary>
        /// Modulus. Returns x – y 􀀍 floor (x/y)
        /// for each component in x using the
        /// floating-point value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec4 mod(vec4 x, double y) { return null; }

        /// <summary>
        /// Modulus. Returns x – y 􀀍 floor (x/y)
        /// for each component in x using the
        /// corresponding component of y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec2 mod(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Modulus. Returns x – y 􀀍 floor (x/y)
        /// for each component in x using the
        /// corresponding component of y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec3 mod(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Modulus. Returns x – y 􀀍 floor (x/y)
        /// for each component in x using the
        /// corresponding component of y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec4 mod(vec4 x, vec4 y) { return null; }

        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float min(double x, double y) { return 0.0f; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec2 min(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec3 min(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec4 min(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int min(int x, int y) { return 0; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec2 min(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec3 min(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec4 min(ivec4 x, ivec4 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uint min(uint x, uint y) { return 0u; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec2 min(uvec2 x, uvec2 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec3 min(uvec3 x, uvec3 y) { return null; }
        /// <summary>
        /// Returns y if y &lt; x; otherwise, it 
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec4 min(uvec4 x, uvec4 y) { return null; }

        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec2 min(vec2 x, double y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec3 min(vec3 x, double y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec4 min(vec4 x, double y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec2 min(ivec2 x, int y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec3 min(ivec3 x, int y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec4 min(ivec4 x, int y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec2 min(uvec2 x, uint y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec3 min(uvec3 x, uint y) { return null; }
        /// <summary>
        /// Returns minimum for each
        /// component of x compared with the
        /// scalar value y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec4 min(uvec4 x, uint y) { return null; }

        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float max(double x, double y) { return 0.0f; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec2 max(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec3 max(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec4 max(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int max(int x, int y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec2 max(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec3 max(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ivec4 max(ivec4 x, ivec4 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uint max(uint x, uint y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec2 max(uvec2 x, uvec2 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec3 max(uvec3 x, uvec3 y) { return null; }
        /// <summary>
        /// Returns y if x &lt; y; otherwise, it
        /// returns x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uvec4 max(uvec4 x, uvec4 y) { return null; }


    }
}