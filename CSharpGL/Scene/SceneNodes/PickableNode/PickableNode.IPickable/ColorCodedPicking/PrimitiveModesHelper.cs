using System;

namespace CSharpGL
{
    internal static class PrimitiveModesHelper
    {
        /// <summary>
        /// Convert <see cref="DrawMode"/> to <see cref="GeometryType"/>.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static GeometryType ToGeometryType(this DrawMode mode)
        {
            GeometryType result = 0;
            switch (mode)
            {
                case DrawMode.Points:
                    result = GeometryType.Point;
                    break;

                case DrawMode.LineStrip:
                    result = GeometryType.Line;
                    break;

                case DrawMode.LineLoop:
                    result = GeometryType.Line;
                    break;

                case DrawMode.Lines:
                    result = GeometryType.Line;
                    break;

                case DrawMode.LineStripAdjacency:
                    result = GeometryType.Line;
                    break;

                case DrawMode.LinesAdjacency:
                    result = GeometryType.Line;
                    break;

                case DrawMode.TriangleStrip:
                    result = GeometryType.Triangle;
                    break;

                case DrawMode.TriangleFan:
                    result = GeometryType.Triangle;
                    break;

                case DrawMode.Triangles:
                    result = GeometryType.Triangle;
                    break;

                case DrawMode.TriangleStripAdjacency:
                    result = GeometryType.Triangle;
                    break;

                case DrawMode.TrianglesAdjacency:
                    result = GeometryType.Triangle;
                    break;

                case DrawMode.Patches:// this is about tessellation shader. I've no idea about it now.
                    throw new NotImplementedException();
                //break;

                case DrawMode.QuadStrip:
                    result = GeometryType.Quad;
                    break;

                case DrawMode.Quads:
                    result = GeometryType.Quad;
                    break;

                case DrawMode.Polygon:
                    result = GeometryType.Polygon;
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            return result;
        }

        /// <summary>
        /// We render something, we pick, then we got 2 primitives(maybe). 
        /// We want to render the 2 primitives separately in another index order,
        /// so that we can tell which one we actually picked.
        /// This method tells in which mode should we render the 2 primitives.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static DrawMode ToSinglePrimitiveMode(this DrawMode mode)
        {
            switch (mode)
            {
                case DrawMode.Points:
                    mode = DrawMode.Points;
                    break;
                case DrawMode.Lines:
                    mode = DrawMode.Lines;
                    break;
                case DrawMode.LineLoop:
                    mode = DrawMode.Lines;
                    break;
                case DrawMode.LineStrip:
                    mode = DrawMode.Lines;
                    break;
                case DrawMode.Triangles:
                    mode = DrawMode.Triangles;
                    break;
                case DrawMode.TriangleStrip:
                    mode = DrawMode.Triangles;
                    break;
                case DrawMode.TriangleFan:
                    mode = DrawMode.Triangles;
                    break;
                case DrawMode.Quads:
                    mode = DrawMode.Quads;
                    break;
                case DrawMode.QuadStrip:
                    mode = DrawMode.Quads;
                    break;
                case DrawMode.Polygon:
                    mode = DrawMode.Polygon;
                    break;
                case DrawMode.LinesAdjacency:
                    mode = DrawMode.Lines;
                    break;
                case DrawMode.LineStripAdjacency:
                    mode = DrawMode.Lines;
                    break;
                case DrawMode.TrianglesAdjacency:
                    mode = DrawMode.Triangles;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    mode = DrawMode.Triangles;
                    break;
                case DrawMode.Patches:// this is about tessellation shader. I've no idea about it now.
                    throw new NotImplementedException();
                //break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            return mode;
        }

    }
}