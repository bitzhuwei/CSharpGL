using System;

namespace CSharpGL
{
    public partial class PickableRenderer : IColorCodedPicking
    {
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
                { throw new Exception("InnerPickableRenderer is null!"); }
            }
            set
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { this.innerPickableRenderer.PickingBaseId = value; }
                else
                { throw new Exception("InnerPickableRenderer is null!"); }
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
            { throw new Exception("InnerPickableRenderer is null!"); }
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
            { throw new Exception("InnerPickableRenderer is null!"); }
        }
    }
}