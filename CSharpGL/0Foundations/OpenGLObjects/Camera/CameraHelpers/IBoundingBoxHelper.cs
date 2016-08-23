using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// Gets all maximum parts from two <see cref="vec3"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static vec3 Max(vec3 a, vec3 b)
        {
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
        public static vec3 Min(vec3 a, vec3 b)
        {
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
        public static vec3 GetCenter(this IBoundingBox boundingBox)
        {
            return boundingBox.MaxPosition / 2 + boundingBox.MinPosition / 2;
        }

        /// <summary>
        /// expand this boudning box's positions to wrap another one.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="another"></param>
        public static BoundingBox Union(this IBoundingBox boundingBox, IBoundingBox another)
        {
            vec3 min = Min(boundingBox.MinPosition, another.MinPosition);
            vec3 max = Max(boundingBox.MaxPosition, another.MaxPosition);

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Expands the <see cref="IBoundingBox"/>'s values.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="factor">0 for no expanding.</param>
        public static BoundingBox Expand(this IBoundingBox boundingBox, float factor = 0.1f)
        {
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

        private static BoundingBoxRenderer renderer;
        /// <summary>
        /// Render this bounding box.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="color"></param>
        /// <param name="arg"></param>
        public static void Render(this IBoundingBox boundingBox, Color color, RenderEventArgs arg)
        {
            if (renderer == null)
            {
                var lengths = new vec3(1, 1, 1);
                renderer = BoundingBoxRenderer.Create(lengths);
                renderer.Initialize();
            }
            mat4 model = glm.translate(mat4.identity(), boundingBox.MaxPosition / 2 + boundingBox.MinPosition / 2);
            model = glm.scale(model, boundingBox.MaxPosition - boundingBox.MinPosition);
            renderer.ModelMatrix = model;
            renderer.BoundingBoxColor = color;
            renderer.Render(arg);
        }
    }
}
