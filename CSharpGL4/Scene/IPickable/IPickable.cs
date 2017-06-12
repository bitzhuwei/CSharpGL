using System.Drawing;
namespace CSharpGL
{
    /// <summary>
    /// Scene element that implemented this interface will take part in color-coded picking.
    /// </summary>
    public interface IPickable
    {
        /// <summary>
        /// Gets how many primitived have been rendered till now during color coded rendering.
        /// </summary>
        uint PickingBaseId { get; set; }

        /// <summary>
        /// Render for color-coded picking.
        /// </summary>
        /// <param name="arg"></param>
        void RenderForPicking(PickEventArgs arg);

        /// <summary>
        /// Gets vertices' count in this element's VBO representing positions.
        /// </summary>
        /// <returns></returns>
        uint GetVertexCount();

        /// <summary>
        /// Get the geometry according to vertex's id.
        /// <para>Note: the <paramref name="stageVertexId"/> refers to the last vertex that constructs the geometry. And it's unique among all elements in a scene.</para>
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId">Refers to the last vertex that constructs the primitive. And it's unique in scene's all elements.</param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        PickedGeometry GetPickedGeometry(PickEventArgs arg, uint stageVertexId, int x, int y);
    }

    public class PickEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="position"></param>
        /// <param name="geometryType">Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking or none(nothing to pick).</param>
        public PickEventArgs(Scene scene, Point position, PickingGeometryType geometryType)
        {
            this.Scene = scene;
            this.Position = position;
            this.GeometryType = geometryType;
        }

        public Scene Scene { get; set; }

        public Point Position { get; set; }

        /// <summary>
        /// Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking or none(nothing to pick).
        /// </summary>
        public PickingGeometryType GeometryType { get; set; }
    }
}