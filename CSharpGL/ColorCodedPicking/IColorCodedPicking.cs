namespace CSharpGL
{
    /// <summary>
    /// Scene element that implemented this interface will take part in color-coded picking.
    /// </summary>
    public interface IColorCodedPicking : IRenderable
    {
        /// <summary>
        ///
        /// </summary>
        mat4 MVP { get; set; }

        /// <summary>
        /// Gets how many primitived have been rendered till now during color coded rendering.
        /// </summary>
        uint PickingBaseId { get; }

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
        /// <param name="x">mouse position</param>
        /// <param name="y">mouse position</param>
        /// <returns></returns>
        PickedGeometry GetPickedGeometry(RenderEventArgs arg, uint stageVertexId, int x, int y);
    }
}