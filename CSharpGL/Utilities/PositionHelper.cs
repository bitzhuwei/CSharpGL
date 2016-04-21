using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class PositionHelper
    {
        /// <summary>
        /// 将模型顶点的位置移动到坐标系中心。
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static vec3[] Move2Center(this vec3[] positions)
        {
            var result = new vec3[positions.Length];
            if (positions.Length == 0) { return result; }
            vec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Length; i++)
            {
                if (positions[i].x < min.x) { min.x = positions[i].x; }
                if (positions[i].y < min.y) { min.y = positions[i].y; }
                if (positions[i].z < min.z) { min.z = positions[i].z; }
                if (max.x < positions[i].x) { max.x = positions[i].x; }
                if (max.y < positions[i].y) { max.y = positions[i].y; }
                if (max.z < positions[i].z) { max.z = positions[i].z; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = positions[i] - mid;
            }

            return result;
        }

        /// <summary>
        /// 将模型顶点的位置移动到坐标系中心。
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static List<vec3> Move2Center(this IList<vec3> positions)
        {
            var result = new List<vec3>();
            if (positions.Count == 0) { return result; }
            vec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Count; i++)
            {
                if (positions[i].x < min.x) { min.x = positions[i].x; }
                if (positions[i].y < min.y) { min.y = positions[i].y; }
                if (positions[i].z < min.z) { min.z = positions[i].z; }
                if (max.x < positions[i].x) { max.x = positions[i].x; }
                if (max.y < positions[i].y) { max.y = positions[i].y; }
                if (max.z < positions[i].z) { max.z = positions[i].z; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Count; i++)
            {
                result.Add(positions[i] - mid);
            }

            return result;
        }

    }
}
