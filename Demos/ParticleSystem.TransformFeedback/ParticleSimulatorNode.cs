using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public partial class ParticleSimulatorNode : ModernNode
    {
        private const string vPosition = "position";           //xyz pos, w speed
        private const string prev_position = "prev_position";      //xyz prevPos, w life
        private const string vDirection = "direction";			//xyz direction, w 0

        public static ParticleSimulatorNode Create()
        {
            {
                var vs = new VertexShader(particleVert, vPosition, prev_position, vDirection);
            }
            {
                var vs = new VertexShader(renderVert, vPosition);
                var fs = new FragmentShader(renderFrag);
            }
            {
                var vs = new VertexShader(passThroughVert, vPosition);
                var fs = new FragmentShader(passThroughFrag);
            }

            throw new NotImplementedException();
        }

        private ParticleSimulatorNode(IBufferSource model, params RenderUnitBuilder[] builders)
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
