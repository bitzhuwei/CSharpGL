using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public static class GeometryTypesHelper
    {
        /// <summary>
        /// Get vertex count of specified geometry's type.
        /// <para>returns -1 if type is <see cref="Geometry.Polygon"/>.</para>
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
    }
}
