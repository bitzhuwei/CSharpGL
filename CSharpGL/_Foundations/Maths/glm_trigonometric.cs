using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class glm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float acos(float x)
        {
            return (float)Math.Acos(x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float acosh(float x)
        {

            if (x < (1f))
                return (0f);
            return (float)Math.Log(x + Math.Sqrt(x * x - (1f)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float asin(float x)
        {
            return (float)Math.Asin(x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float asinh(float x)
        {
            return (float)(x < 0f ? -1f : (x > 0f ? 1f : 0f)) * (float)Math.Log(Math.Abs(x) + Math.Sqrt(1f + x * x));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float atan(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y_over_x"></param>
        /// <returns></returns>
        public static float atan(float y_over_x)
        {
            return (float)Math.Atan(y_over_x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float atanh(float x)
        {
            if (Math.Abs(x) >= 1f)
                return 0;
            return (0.5f) * (float)Math.Log((1f + x) / (1f - x));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float cos(float angle)
        {
            return (float)Math.Cos(angle);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float cosh(float angle)
        {
            return (float)Math.Cosh(angle);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float degrees(float radians)
        {
            return radians * (57.295779513082320876798154814105f);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static float radians(float degrees)
        {
            return degrees * (0.01745329251994329576923690768489f);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float sin(float angle)
        {
            return (float)Math.Sin(angle);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float sinh(float angle)
        {
            return (float)Math.Sinh(angle);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float tan(float angle)
        {
            return (float)Math.Tan(angle);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float tanh(float angle)
        {
            return (float)Math.Tanh(angle);
        }
    }

}
