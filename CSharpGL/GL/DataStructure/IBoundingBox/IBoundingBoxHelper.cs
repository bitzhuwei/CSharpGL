﻿using System;
using System.Drawing;

namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public static class IBoundingBoxHelper {
        /// <summary>
        /// Gets all maximum parts from two <see cref="vec3"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static vec3 Max(vec3 a, vec3 b) {
            vec3 result = a;
            if (result.x < b.x) { result.x = b.x; }
            if (result.y < b.y) { result.y = b.y; }
            if (result.z < b.z) { result.z = b.z; }

            return result;
        }

        /// <summary>
        /// Gets all minimum parts from two <see cref="vec3"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static vec3 Min(vec3 a, vec3 b) {
            vec3 result = a;
            if (result.x > b.x) { result.x = b.x; }
            if (result.y > b.y) { result.y = b.y; }
            if (result.z > b.z) { result.z = b.z; }

            return result;
        }

        /// <summary>
        /// Gets center position of this bounding box.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <returns></returns>
        public static vec3 GetCenter(this IBoundingBox boundingBox) {
            return boundingBox.MaxPosition / 2 + boundingBox.MinPosition / 2;
        }

        /// <summary>
        /// expand this boudning box's positions to wrap another one.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="another"></param>
        public static BoundingBox Union(this IBoundingBox boundingBox, IBoundingBox another) {
            vec3 min = Min(boundingBox.MinPosition, another.MinPosition);
            vec3 max = Max(boundingBox.MaxPosition, another.MaxPosition);

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Expands the <see cref="IBoundingBox"/>'s values.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="factor">0 for no expanding.</param>
        public static BoundingBox Expand(this IBoundingBox boundingBox, float factor = 0.1f) {
            if (boundingBox == null) { throw new ArgumentNullException("boundingBox"); }

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

            return new BoundingBox(newMin, newMax);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="box"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static BoundingBox Union(this IBoundingBox box, vec3 point) {
            vec3 min = box.MinPosition;
            vec3 max = box.MaxPosition;
            {
                if (min.x > point.x) { min.x = point.x; }
                if (min.y > point.y) { min.y = point.y; }
                if (min.z > point.z) { min.z = point.z; }
                if (max.x < point.x) { max.x = point.x; }
                if (max.y < point.y) { max.y = point.y; }
                if (max.z < point.z) { max.z = point.z; }
            }

            return new BoundingBox(min, max);
        }
    }
}