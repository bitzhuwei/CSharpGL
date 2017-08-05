using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    // TODO: make this node as private class.
    public partial class DataNode : ModernNode
    {
        public static DataNode Create(IBufferSource model, IShaderProgramProvider[] providers, AttributeMap[] maps)
        {


            throw new NotImplementedException();
        }

        private DataNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {

        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
