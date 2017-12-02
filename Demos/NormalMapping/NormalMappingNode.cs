using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace NormalMapping
{
    partial class NormalMappingNode:ModernNode
    {
        public static NormalMappingNode Create()
        {
            throw new NotImplementedException();
        }

        private NormalMappingNode(IBufferSource model, params RenderMethodBuilder[] builders) 
            : base(model,builders)
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
