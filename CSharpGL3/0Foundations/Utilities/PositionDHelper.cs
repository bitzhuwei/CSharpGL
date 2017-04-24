using System.Collections.Generic;

namespace EMGraphics
{
    /// <summary>
    ///
    /// </summary>
    public static class PositionDHelper
    {
        /// <summary>
        /// Move positions where around (0, 0)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static BoundingBox2D Move2Center(this dvec2[] positions)
        {
            if (positions.Length == 0) { return new BoundingBox2D(); }

            dvec2 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Length; i++)
            {
                dvec2 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
            }
            dvec2 mid = max / 2 + min / 2;
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
        public static BoundingBox2D Move2Center(this IList<dvec2> positions)
        {
            if (positions.Count == 0) { return new BoundingBox2D(); }

            dvec2 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Count; i++)
            {
                dvec2 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
            }
            dvec2 mid = max / 2 + min / 2;
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
        public static BoundingBox Move2Center(this dvec3[] positions)
        {
            if (positions.Length == 0) { return new BoundingBox(); }

            dvec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Length; i++)
            {
                dvec3 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (value.z < min.z) { min.z = value.z; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
                if (max.z < value.z) { max.z = value.z; }
            }
            dvec3 mid = max / 2 + min / 2;
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
        public static BoundingBox Move2Center(this IList<dvec3> positions)
        {
            if (positions.Count == 0) { return new BoundingBox(); }

            dvec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Count; i++)
            {
                dvec3 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (value.z < min.z) { min.z = value.z; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
                if (max.z < value.z) { max.z = value.z; }
            }
            dvec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Count; i++)
            {
                positions[i] = positions[i] - mid;
            }

            return new BoundingBox(min, max);
        }
    }
}