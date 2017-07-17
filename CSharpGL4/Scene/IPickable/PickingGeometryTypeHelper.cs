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
        /// <param name="geometryTypes"></param>
        /// <returns></returns>
        public static PolygonMode GetPolygonMode(this PickingGeometryTypes geometryTypes)
        {
            PolygonMode mode;
            if ((geometryTypes & PickingGeometryTypes.Point) == PickingGeometryTypes.Point)
            { mode = PolygonMode.Point; }
            else if ((geometryTypes & PickingGeometryTypes.Line) == PickingGeometryTypes.Line)
            { mode = PolygonMode.Line; }
            else
            { mode = PolygonMode.Fill; }

            return mode;
        }

    }
}
