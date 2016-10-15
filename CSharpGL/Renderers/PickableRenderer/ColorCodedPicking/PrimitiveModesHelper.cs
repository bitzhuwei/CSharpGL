using System;

namespace CSharpGL
{
    internal static class PrimitiveModesHelper
    {
        /// <summary>
        /// Convert <see cref="DrawMode"/> to <see cref="PickingGeometryType"/>.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static PickingGeometryType ToGeometryType(this DrawMode mode)
        {
            PickingGeometryType result = PickingGeometryType.Point;
            switch (mode)
            {
                case DrawMode.Points:
                    result = PickingGeometryType.Point;
                    break;

                case DrawMode.LineStrip:
                    result = PickingGeometryType.Line;
                    break;

                case DrawMode.LineLoop:
                    result = PickingGeometryType.Line;
                    break;

                case DrawMode.Lines:
                    result = PickingGeometryType.Line;
                    break;

                case DrawMode.LineStripAdjacency:
                    result = PickingGeometryType.Line;
                    break;

                case DrawMode.LinesAdjacency:
                    result = PickingGeometryType.Line;
                    break;

                case DrawMode.TriangleStrip:
                    result = PickingGeometryType.Triangle;
                    break;

                case DrawMode.TriangleFan:
                    result = PickingGeometryType.Triangle;
                    break;

                case DrawMode.Triangles:
                    result = PickingGeometryType.Triangle;
                    break;

                case DrawMode.TriangleStripAdjacency:
                    result = PickingGeometryType.Triangle;
                    break;

                case DrawMode.TrianglesAdjacency:
                    result = PickingGeometryType.Triangle;
                    break;

                case DrawMode.Patches:// this is about tessellation shader. I've no idea about it now.
                    throw new NotImplementedException();
                case DrawMode.QuadStrip:
                    result = PickingGeometryType.Quad;
                    break;

                case DrawMode.Quads:
                    result = PickingGeometryType.Quad;
                    break;

                case DrawMode.Polygon:
                    result = PickingGeometryType.Polygon;
                    break;

                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}