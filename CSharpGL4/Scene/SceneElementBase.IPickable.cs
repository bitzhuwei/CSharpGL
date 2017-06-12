using System;
using System.ComponentModel;

namespace CSharpGL
{
    public abstract partial class SceneElementBase
    {
        #region IPickable 成员

        public abstract uint PickingBaseId { get; set; }

        public abstract void RenderForPicking(PickEventArgs arg);

        public abstract uint GetVertexCount();

        public abstract PickedGeometry GetPickedGeometry(PickEventArgs arg, uint stageVertexId, int x, int y);

        #endregion
    }
}