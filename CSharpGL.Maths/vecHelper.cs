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

        public static vec4 ToVec4(this float[] array, int startIndex = 0)
        {
            vec4 result = new vec4(array[startIndex], array[startIndex + 1], array[startIndex + 2], array[startIndex + 3]);

            return result;
        }

        public static vec3 ToVec3(this float[] array, int startIndex = 0)
        {
            vec3 result = new vec3(array[startIndex], array[startIndex + 1], array[startIndex + 2]);

            return result;
        }

        public static vec2 ToVec2(this float[] array, int startIndex = 0)
        {
            vec2 result = new vec2(array[startIndex], array[startIndex + 1]);

            return result;
        }

    }
}
