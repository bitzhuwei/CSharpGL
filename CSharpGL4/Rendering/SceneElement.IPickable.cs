using System;
using System.ComponentModel;

namespace CSharpGL
{
    public abstract partial class SceneElement
    {

        #region IPickable 成员

        public uint PickingBaseId { get; set; }

        public void RenderForPicking(PickEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public uint GetVertexCount()
        {
            throw new NotImplementedException();
        }

        public PickedGeometry GetPickedGeometry(RenderEventArgs arg, uint stageVertexId, int x, int y)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}