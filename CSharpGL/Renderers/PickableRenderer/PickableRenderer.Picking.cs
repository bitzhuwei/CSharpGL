using System;

namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        public uint PickingBaseId
        {
            get
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer == null) { throw new Exception("InnerPickableRenderer is null!"); }

                return renderer.PickingBaseId;
            }
            set
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer == null) { throw new Exception("InnerPickableRenderer is null!"); }

                renderer.PickingBaseId = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public uint GetVertexCount()
        {
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            if (renderer == null) { throw new Exception("InnerPickableRenderer is null!"); }

            return renderer.GetVertexCount();
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
            if (renderer == null) { throw new Exception("InnerPickableRenderer is null!"); }

            PickedGeometry result = this.innerPickableRenderer.GetPickedGeometry(arg, stageVertexId, x, y);
            if (result != null)
            {
                result.From = this;
            }

            return result;
        }
    }
}