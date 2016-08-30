using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class PositionHelper
    {
        /// <summary>
        /// Move positions where around (0, 0)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static BoundingBox2D Move2Center(this vec2[] positions)
        {
            if (positions.Length == 0) { return new BoundingBox2D(); }

            vec2 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Length; i++)
            {
                vec2 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
            }
            vec2 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = positions[i] - mid;
            }

            return new BoundingBox2D(min, max);
        }

        /// <summary>
        /// Move positions where around (0, 0)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static BoundingBox2D Move2Center(this IList<vec2> positions)
        {
            if (positions.Count == 0) { return new BoundingBox2D(); }

            vec2 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Count; i++)
            {
                vec2 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
            }
            vec2 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Count; i++)
            {
                positions[i] = positions[i] - mid;
            }

            return new BoundingBox2D(min, max);
        }
        /// <summary>
        /// Move positions where around (0, 0, 0)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static BoundingBox Move2Center(this vec3[] positions)
        {
            if (positions.Length == 0) { return new BoundingBox(); }

            vec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Length; i++)
            {
                vec3 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (value.z < min.z) { min.z = value.z; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
                if (max.z < value.z) { max.z = value.z; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = positions[i] - mid;
            }

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Move positions where around (0, 0, 0)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static BoundingBox Move2Center(this IList<vec3> positions)
        {
            if (positions.Count == 0) { return new BoundingBox(); }

            vec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Count; i++)
            {
                vec3 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (value.z < min.z) { min.z = value.z; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
                if (max.z < value.z) { max.z = value.z; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Count; i++)
            {
                positions[i] = positions[i] - mid;
            }

            return new BoundingBox(min, max);
        }

    }
}
