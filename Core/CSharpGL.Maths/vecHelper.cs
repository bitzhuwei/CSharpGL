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
