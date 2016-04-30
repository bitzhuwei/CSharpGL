using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// picking a point, line, triangle, quad, or polygon from specified VBO?
    /// </summary>
    public enum PickingPrimitiveType
    {
        /// <summary>
        /// picking a point from specified VBO
        /// </summary>
        Point,
        /// <summary>
        /// picking a line from specified VBO
        /// </summary>
        Line,
        /// <summary>
        /// picking a triangle from specified VBO
        /// </summary>
        Triangle,
        /// <summary>
        /// picking a quad from specified VBO
        /// </summary>
        Quad,
        /// <summary>
        /// picking a polygon from specified VBO
        /// </summary>
        Polygon,
    }
}
