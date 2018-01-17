using System;
namespace CSharpGL
{
    /// <summary>
    /// Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking.
    /// </summary>
    public enum GeometryType : byte
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

    /// <summary>
    /// 
    /// </summary>
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
        private const PickingGeometryTypes faceTypes = PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad | PickingGeometryTypes.Polygon;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pickingType"></param>
        /// <param name="typeOfMode"></param>
        /// <returns></returns>
        public static bool Contains(this PickingGeometryTypes pickingType, GeometryType typeOfMode)
        {
            bool result = false;

            switch (typeOfMode)
            {
                case GeometryType.Point:
                    result = (pickingType & PickingGeometryTypes.Point) == PickingGeometryTypes.Point;
                    break;
                case GeometryType.Line:
                    result = (pickingType & PickingGeometryTypes.Line) == PickingGeometryTypes.Line;
                    break;
                case GeometryType.Triangle:
                    result = (pickingType & faceTypes) != noType;
                    break;
                case GeometryType.Quad:
                    result = (pickingType & faceTypes) != noType;
                    break;
                case GeometryType.Polygon:
                    result = (pickingType & faceTypes) != noType;
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(GeometryType));
            }

            return result;
        }

        public static PickingGeometryTypes ToFlags(this GeometryType type)
        {
            PickingGeometryTypes result = 0;

            switch (type)
            {
                case GeometryType.Point:
                    result = PickingGeometryTypes.Point;
                    break;
                case GeometryType.Line:
                    result = PickingGeometryTypes.Line;
                    break;
                case GeometryType.Triangle:
                    result = PickingGeometryTypes.Triangle;
                    break;
                case GeometryType.Quad:
                    result = PickingGeometryTypes.Quad;
                    break;
                case GeometryType.Polygon:
                    result = PickingGeometryTypes.Polygon;
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(GeometryType));
            }

            return result;
        }
    }
}
