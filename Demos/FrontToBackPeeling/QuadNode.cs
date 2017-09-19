using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    class QuadNode : ModernNode
    {
        public static QuadNode Create()
        {
            var model = new QuadModel();

            throw new NotImplementedException();
        }

        private QuadNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
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
