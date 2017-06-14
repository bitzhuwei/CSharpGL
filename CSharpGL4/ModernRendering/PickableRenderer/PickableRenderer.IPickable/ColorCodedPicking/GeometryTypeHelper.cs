using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class GeometryTypesHelper
    {
        /// <summary>
        /// Get vertex count of specified geometry's type.
        /// <para>returns -1 if type is <see cref="PickingGeometryType.Polygon"/>.</para>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetVertexCount(this PickingGeometryType type)
        {
            int result = -1;

            switch (type)
            {
                case PickingGeometryType.Point:
                    result = 1;
                    break;

                case PickingGeometryType.Line:
                    result = 2;
                    break;

                case PickingGeometryType.Triangle:
                    result = 3;
                    break;

                case PickingGeometryType.Quad:
                    result = 4;
                    break;

                case PickingGeometryType.Polygon:
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
        public static DrawMode ToDrawMode(this PickingGeometryType type)
        {
            DrawMode mode = DrawMode.Points;
            switch (type)
            {
                case PickingGeometryType.Point:
                    mode = DrawMode.Points;
                    break;

                case PickingGeometryType.Line:
                    mode = DrawMode.Lines;
                    break;

                case PickingGeometryType.Triangle:
                    mode = DrawMode.Triangles;
                    break;

                case PickingGeometryType.Quad:
                    mode = DrawMode.Quads;
                    break;

                case PickingGeometryType.Polygon:
                    mode = DrawMode.Polygon;
                    break;

                default:
                    throw new NotImplementedException();
            }

            return mode;
        }
    }
}