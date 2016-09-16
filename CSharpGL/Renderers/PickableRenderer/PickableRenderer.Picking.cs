namespace CSharpGL
{
    public partial class PickableRenderer : IColorCodedPicking
    {
        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        public mat4 MVP
        {
            get
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { return this.innerPickableRenderer.MVP; }
                else
                { return mat4.identity(); }
            }
            set
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { this.innerPickableRenderer.MVP = value; }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public uint PickingBaseId
        {
            get
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { return this.innerPickableRenderer.PickingBaseId; }
                else
                { return 0; }
            }
            set
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { this.innerPickableRenderer.PickingBaseId = value; }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public uint GetVertexCount()
        {
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            if (renderer != null)
            { return this.innerPickableRenderer.GetVertexCount(); }
            else
            { return 0; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PickedGeometry GetPickedGeometry(
            RenderEventArgs arg,
            uint stageVertexId,
            int x, int y)
        {
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            if (renderer != null)
            { return this.innerPickableRenderer.GetPickedGeometry(arg, stageVertexId, x, y); }
            else
            { return null; }
        }
    }
}