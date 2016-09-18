namespace CSharpGL
{
    public partial class Bezier1DRenderer
    {
        /// <summary>
        ///
        /// </summary>
        public mat4 MVP
        {
            get { return this.ControlPointsRenderer.MVP; }
            set { this.ControlPointsRenderer.MVP = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public uint PickingBaseId
        {
            get { return this.ControlPointsRenderer.PickingBaseId; }
            set { this.ControlPointsRenderer.PickingBaseId = value; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public uint GetVertexCount()
        {
            return (uint)this.ControlPointsRenderer.GetVertexCount();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PickedGeometry GetPickedGeometry(RenderEventArgs arg, uint stageVertexId, int x, int y)
        {
            return this.ControlPointsRenderer.GetPickedGeometry(arg, stageVertexId, x, y);
        }
    }
}