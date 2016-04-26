using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class SpaceGeometryHelper
    {
        /// <summary>
        /// 判定三点是否共线。
        /// </summary>
        /// <param name="walker"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="percent">如果三点共线，<paramref name="percent"/>代表(<paramref name="walker"/> - <paramref name="start"/>)/(<paramref name="end"/> - <paramref name="start"/>)</param>
        /// <returns></returns>
        public static bool InTheSameLine(this vec3 walker, vec3 start, vec3 end, out float percent, float allowableError = 0.001f)
        {
            percent = 0;
            vec3 v1 = walker - start;
            vec3 v2 = end - start;
            float x = v1.x / v2.x;
            float y = v1.y / v2.y;
            float z = v1.z / v2.z;
            float average = x / 3 + y / 3 + z / 3;
            if (Math.Abs(x - average) <= allowableError
                && Math.Abs(y - average) <= allowableError
                && Math.Abs(z - average) <= allowableError)
            {
                percent = average;
                return true;
            }


            return false;
        }
    }
}
