using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    static class PickingGeometryTypeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometryType"></param>
        /// <returns></returns>
        public static PolygonMode GetPolygonMode(this PickingGeometryType geometryType)
        {
            PolygonMode mode;
            switch (geometryType)
            {
                case PickingGeometryType.None:
                    // whatever it is.
                    mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Point:
                    mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Line:
                    mode = PolygonMode.Line;
                    break;

                case PickingGeometryType.Triangle:
                    mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Quad:
                    mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Polygon:
                    mode = PolygonMode.Fill;
                    break;

                default:
                    throw new NotImplementedException();
            }

            return mode;
        }

    }
}
