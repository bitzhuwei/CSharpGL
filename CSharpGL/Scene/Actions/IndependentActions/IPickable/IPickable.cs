using System.Collections.Generic;
using System.Drawing;
namespace CSharpGL
{
    /// <summary>
    /// Scene element that implemented this interface will take part in color-coded picking.
    /// </summary>
    public interface IPickable
    {
        /// <summary>
        /// 
        /// </summary>
        TwoFlags EnablePicking { get; set; }

        /// <summary>
        /// Gets how many primitived have been rendered till now during color coded rendering.
        /// </summary>
        uint PickingBaseId { get; set; }

        /// <summary>
        /// Render for color-coded picking.
        /// </summary>
        /// <param name="arg"></param>
        void RenderForPicking(PickingEventArgs arg);

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
        /// <returns></returns>
        PickedGeometry GetPickedGeometry(PickingEventArgs arg, uint stageVertexId);
    }

    /// <summary>
    /// 
    /// </summary>
    public class PickingEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="geometryType">Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking or none(nothing to pick).</param>
        internal PickingEventArgs(Scene scene, int x, int y, PickingGeometryTypes geometryType)
        {
            this.Scene = scene;
            this.X = x;
            this.Y = y;
            this.GeometryType = geometryType;

            this.ModelMatrixStack = new Stack<mat4>();
            this.ModelMatrixStack.Push(mat4.identity());
        }

        /// <summary>
        /// 
        /// </summary>
        public Scene Scene { get; set; }

        /// <summary>
        /// picking at position(Left Down is (0, 0)).
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// picking at position(Left Down is (0, 0)).
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal uint RenderedVertexCount { get; set; }

        /// <summary>
        /// Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking or none(nothing to pick).
        /// </summary>
        internal PickingGeometryTypes GeometryType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal Stack<mat4> ModelMatrixStack { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} @ [{1}, {2}]", this.GeometryType, this.X, this.Y);
        }
    }
}