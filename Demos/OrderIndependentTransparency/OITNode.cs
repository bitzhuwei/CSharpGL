using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace OrderIndependentTransparency
{
    public partial class OITNode : PickableNode
    {

        public static OITNode Create()
        {
            throw new NotImplementedException();
        }

        private OITNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
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
