using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Specify a bounding box that marks a model's edges.
    /// </summary>
    public class BoundingBox : IBoundingBox
    {
        /// <summary>
        /// Maximum position of this bounding box.
        /// </summary>
        public vec3 MaxPosition { get; set; }

        /// <summary>
        /// Minimum position of this bounding box.
        /// </summary>
        public vec3 MinPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BoundingBox() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public BoundingBox(vec3 min, vec3 max)
        {
            this.MinPosition = new vec3(
                Math.Min(min.x, max.x),
                Math.Min(min.y, max.y),
                Math.Min(min.z, max.z));
            this.MaxPosition = new vec3(
                Math.Max(min.x, max.x),
                Math.Max(min.y, max.y),
                Math.Max(min.z, max.z));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("min: {0} max: {1}", this.MinPosition, this.MaxPosition);
        }
    }
}
