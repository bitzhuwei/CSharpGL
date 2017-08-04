using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public partial class PassThroughNode : ModernNode
    {
        public const string vPosition = "position";           //xyz pos, w speed
        public const string prev_position = "prev_position";      //xyz prevPos, w life
        public const string vDirection = "direction";			//xyz direction, w 0

        public static PassThroughNode Create()
        {
            {
                var vs = new VertexShader(passThroughVert, vPosition);
                var fs = new FragmentShader(passThroughFrag);
            }

            throw new NotImplementedException();
        }

        private PassThroughNode(IBufferSource model, params RenderUnitBuilder[] builders)
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
