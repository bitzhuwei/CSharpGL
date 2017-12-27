using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class ManyCubesNode : ModernNode
    {

        public static ManyCubesNode Create(int lengthX, int lengthY, int lengthZ)
        {
            var model = new ManyCubesModel(lengthX, lengthY, lengthZ);

        }

        private ManyCubesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) { }

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
