namespace CSharpGL
{
    /// <summary>
    /// Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking or none(nothing to pick).
    /// </summary>
    public enum PickingGeometryType
    {
        /// <summary>
        /// Not picking.
        /// </summary>
        None,

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
}