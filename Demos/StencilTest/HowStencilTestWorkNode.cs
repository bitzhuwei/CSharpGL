using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilTest
{
    class HowStencilTestWorkNode : ModernNode
    {
        private StencilTestState stencilTest = new StencilTestState(true);

        public HowStencilTestWorkNode()
            : base(null)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.stencilTest.On();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            this.stencilTest.Off();
        }
    }
}
