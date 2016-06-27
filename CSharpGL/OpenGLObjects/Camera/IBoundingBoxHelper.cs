using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBoundingBoxHelper
    {
        /// <summary>
        /// Expands the <see cref="IBoundingBox"/>'s values.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="factor">0 for no expanding.</param>
        public static void Expand(this IBoundingBox boundingBox, float factor = 0.1f)
        {
            if (boundingBox == null) { return; }

            vec3 min = boundingBox.MinPosition;
            vec3 max = boundingBox.MaxPosition;

            if (boundingBox.MaxPosition.x < min.x) { min.x = boundingBox.MaxPosition.x; }
            if (boundingBox.MaxPosition.y < min.y) { min.y = boundingBox.MaxPosition.y; }
            if (boundingBox.MaxPosition.z < min.z) { min.z = boundingBox.MaxPosition.z; }

            if (max.x < boundingBox.MinPosition.x) { max.x = boundingBox.MinPosition.x; }
            if (max.y < boundingBox.MinPosition.y) { max.y = boundingBox.MinPosition.y; }
            if (max.z < boundingBox.MinPosition.z) { max.z = boundingBox.MinPosition.z; }

            vec3 vector = (max - min);
            vector *= (1 + factor);
            vec3 newMax = min + vector;
            vec3 newMin = max - vector;
            boundingBox.Set(newMin.x, newMin.y, newMin.z, newMax.x, newMax.y, newMax.z);
        }
    }
}
