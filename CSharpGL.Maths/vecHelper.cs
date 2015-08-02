using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Maths
{
    public static class vecHelper
    {
        /// <summary>
        /// 获取向量长度
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Magnitude(this vec2 vector)
        {
            double result = Math.Sqrt(vector.x * vector.x + vector.y * vector.y);

            return (float)result;
        }

        /// <summary>
        /// 获取归一化的向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static vec2 Normalize(this vec2 vector)
        {
            var frt = (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y);

            var result = new vec2(vector.x / frt, vector.y / frt);

            return result;
        }

        public static string FormatVertex(this vec2 vector)
        {
            return string.Format("{0:0.00},{1:0.00}", vector.x, vector.y);
        }

        /// <summary>
        /// 获取向量长度
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Magnitude(this vec3 vector)
        {
            double result = Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);

            return (float)result;
        }

        /// <summary>
        /// 获取归一化的向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static vec3 Normalize(this vec3 vector)
        {
            var frt = (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);

            var result = new vec3(vector.x / frt, vector.y / frt, vector.z / frt);

            return result;
        }

        /// <summary>
        /// 计算向量积
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 VectorProduct(this vec3 vector, vec3 rhs)
        {
            var result = new vec3((vector.y * rhs.z) - (vector.z * rhs.y), (vector.z * rhs.x) - (vector.x * rhs.z),
                (vector.x * rhs.y) - (vector.y * rhs.x));
            return result;
        }

        public static string FormatVertex(this vec3 vector)
        {
            return string.Format("{0:0.00},{1:0.00},{2:0.00}", vector.x, vector.y, vector.z);
        }

        /// <summary>
        /// 获取向量长度
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Magnitude(this vec4 vector)
        {
            double result = Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z + vector.w * vector.w);

            return (float)result;
        }

        /// <summary>
        /// 获取归一化的向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static vec4 Normalize(this vec4 vector)
        {
            var frt = (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z + vector.w * vector.w);

            var result = new vec4(vector.x / frt, vector.y / frt, vector.z / frt, vector.w / frt);

            return result;
        }

        public static string FormatVertex(this vec4 vector)
        {
            return string.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00}", vector.x, vector.y, vector.z, vector.w);
        }
    }
}
