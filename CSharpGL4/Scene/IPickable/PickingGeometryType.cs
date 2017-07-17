using System;
namespace CSharpGL
{
    /// <summary>
    /// Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking or none(nothing to pick).
    /// </summary>
    public enum PickingGeometryType : byte
    {
        /// <summary>
        /// Picking a point.
        /// </summary>
        Point,

        /// <summary>
        /// Picking a line.
        /// </summary>
        Line,

        /// <summary>
        /// Picking a triangle.
        /// </summary>
        Triangle,

        /// <summary>
        /// Picking a quad.
        /// </summary>
        Quad,

        /// <summary>
        /// Picking a polygon.
        /// </summary>
        Polygon,
    }

    [Flags]
    public enum PickingGeometryTypes : byte
    {
        /// <summary>
        /// Picking a point.
        /// </summary>
        Point = 1,

        /// <summary>
        /// Picking a line.
        /// </summary>
        Line = 2,

        /// <summary>
        /// Picking a triangle.
        /// </summary>
        Triangle = 4,

        /// <summary>
        /// Picking a quad.
        /// </summary>
        Quad = 8,

        /// <summary>
        /// Picking a polygon.
        /// </summary>
        Polygon = 16,
    }

    static class Helper
    {
        private const PickingGeometryTypes noType = 0;
        private const PickingGeometryTypes faceType = PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad | PickingGeometryTypes.Polygon;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pickingType"></param>
        /// <param name="typeOfMode"></param>
        /// <returns></returns>
        public static bool Contains(this PickingGeometryTypes pickingType, PickingGeometryType typeOfMode)
        {
            bool result = false;

            switch (typeOfMode)
            {
                case PickingGeometryType.Point:
                    result = (pickingType & PickingGeometryTypes.Point) == PickingGeometryTypes.Point;
                    break;
                case PickingGeometryType.Line:
                    result = (pickingType & PickingGeometryTypes.Line) == PickingGeometryTypes.Line;
                    break;
                case PickingGeometryType.Triangle:
                    result = (pickingType & faceType) != noType;
                    break;
                case PickingGeometryType.Quad:
                    result = (pickingType & faceType) != noType;
                    break;
                case PickingGeometryType.Polygon:
                    result = (pickingType & faceType) != noType;
                    break;
                default:
                    throw new Exception("not expected PickingGeometryType!");
            }

            return result;
        }

        public static PickingGeometryTypes ToFlags(this PickingGeometryType type)
        {
            PickingGeometryTypes result = 0;

            switch (type)
            {
                case PickingGeometryType.Point:
                    result = PickingGeometryTypes.Point;
                    break;
                case PickingGeometryType.Line:
                    result = PickingGeometryTypes.Line;
                    break;
                case PickingGeometryType.Triangle:
                    result = PickingGeometryTypes.Triangle;
                    break;
                case PickingGeometryType.Quad:
                    result = PickingGeometryTypes.Quad;
                    break;
                case PickingGeometryType.Polygon:
                    result = PickingGeometryTypes.Polygon;
                    break;
                default:
                    throw new Exception("not expected PickingGeometryType!");
            }

            return result;
        }
    }
}
