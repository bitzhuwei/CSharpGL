using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeometryTypesHelper
    {
        /// <summary>
        /// Get vertex count of specified geometry's type.
        /// <para>returns -1 if type is <see cref="GeometryType.Polygon"/>.</para>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetVertexCount(this GeometryType type)
        {
            int result = -1;

            switch (type)
            {
                case GeometryType.Point:
                    result = 1;
                    break;
                case GeometryType.Line:
                    result = 2;
                    break;
                case GeometryType.Triangle:
                    result = 3;
                    break;
                case GeometryType.Quad:
                    result = 4;
                    break;
                case GeometryType.Polygon:
                    result = -1;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DrawMode ToDrawMode(this GeometryType type)
        {
            DrawMode mode = DrawMode.Points;
            switch (type)
            {
                case GeometryType.Point:
                    mode = DrawMode.Points;
                    break;
                case GeometryType.Line:
                    mode = DrawMode.Lines;
                    break;
                case GeometryType.Triangle:
                    mode = DrawMode.Triangles;
                    break;
                case GeometryType.Quad:
                    mode = DrawMode.Quads;
                    break;
                case GeometryType.Polygon:
                    mode = DrawMode.Polygon;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return mode;
        }
    }
}
