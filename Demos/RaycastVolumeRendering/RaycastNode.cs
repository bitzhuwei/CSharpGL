using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaycastVolumeRendering
{
    public partial class RaycastNode : PickableNode
    {

        public static RaycastNode Create()
        {
            throw new NotImplementedException();
        }

        private RaycastNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
