using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Specify a cuboid that marks a model's edges.
    /// </summary>
    public class BoundingBox : IBoundingBox
    {
        /// <summary>
        /// Maximum position of this cuboid.
        /// </summary>
        public vec3 MaxPosition { get; set; }

        /// <summary>
        /// Minimum position of this cuboid.
        /// </summary>
        public vec3 MinPosition { get; set; }

        public BoundingBox() { }

        public BoundingBox(vec3 min, vec3 max)
        {
            this.MinPosition = min;
            this.MaxPosition = max;
        }

        public vec3 GetCenter()
        {
            return this.MaxPosition / 2 + this.MinPosition / 2;
        }

        public override string ToString()
        {
            return string.Format("min: {0} max: {1}", this.MinPosition, this.MaxPosition);
        }
        ///// <summary>
        ///// Get center position of this cuboid.
        ///// </summary>
        ///// <param name="x">x position.</param>
        ///// <param name="y">y position.</param>
        ///// <param name="z">z position.</param>
        //void GetCenter(out float x, out float y, out float z);

        ///// <summary>
        ///// Gets the bound dimensions.
        ///// </summary>
        ///// <param name="xSize">The x size.</param>
        ///// <param name="ySize">The y size.</param>
        ///// <param name="zSize">The z size.</param>
        //void GetBoundDimensions(out float xSize, out float ySize, out float zSize);

        ///// <summary>
        ///// Render to the provided instance of OpenGL.
        ///// </summary>
        ///// <param name="renderMode">The render mode.</param>
        //void Render(RenderModes renderMode);

        ///// <summary>
        ///// Only way to set bounding box'es values.
        ///// </summary>
        ///// <param name="minX"></param>
        ///// <param name="minY"></param>
        ///// <param name="minZ"></param>
        ///// <param name="maxX"></param>
        ///// <param name="maxY"></param>
        ///// <param name="maxZ"></param>
        //void Set(float minX, float minY, float minZ, float maxX, float maxY, float maxZ);


    }
}
