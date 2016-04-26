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
        public static bool InTheSameLine(this vec3 walker, vec3 start, vec3 end, out float percent, float allowableError = 0.01f)
        {
            vec3 v1 = walker - start;
            vec3 v2 = end - start;
            var values = new List<float>();
            for (int i = 0; i < 3; i++)
            {
                if (v2[i] == 0.0f)
                {
                    if (v1[i] != 0.0f)
                    {
                        percent = 0;
                        return false;
                    }
                }
                else
                {
                    values.Add(v1[i] / v2[i]);
                }
            }

            float average, variance;
            values.ToArray().AverageVariance(out average, out variance);
            if (variance <= allowableError)
            {
                percent = average;
                return true;
            }
            else
            {
                percent = 0;
                return false;
            }
        }
    }
}
