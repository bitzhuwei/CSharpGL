﻿using System;

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
    }
}