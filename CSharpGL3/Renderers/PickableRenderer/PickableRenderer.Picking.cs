using System;
using System.ComponentModel;

namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
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
        /// <param name="arg"></param>
        public void Render4Picking(RenderEventArgs arg)
        {
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            if (renderer == null) { throw new Exception("InnerPickableRenderer is null!"); }

            renderer.Render4Picking(arg);
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
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
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
                result.FromRenderer = this;
            }

            return result;
        }
    }
}