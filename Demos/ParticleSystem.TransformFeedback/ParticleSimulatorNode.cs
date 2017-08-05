using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public partial class ParticleSimulatorNode : ModernNode
    {
        public const string vPosition = "position";           //xyz pos, w speed
        public const string prev_position = "prev_position";      //xyz prevPos, w life
        public const string vDirection = "direction";			//xyz direction, w 0
        private DataNode[] dataNodes;

        public static ParticleSimulatorNode Create(int particleCount)
        {
            var providers = new IShaderProgramProvider[2];
            {
                var vs = new VertexShader(udpateVert, vPosition, prev_position, vDirection);
                providers[0] = new ShaderArray(vs);
            }
            {
                var vs = new VertexShader(renderVert, vPosition);
                var fs = new FragmentShader(renderFrag);
                providers[1] = new ShaderArray(vs, fs);
            }
            var maps = new AttributeMap[0];
            {
                maps[0] = new AttributeMap();
                maps[0].Add(vPosition, ParticleModel.position);
                maps[0].Add(prev_position, ParticleModel.pre_position);
                maps[0].Add(vDirection, ParticleModel.direction);
                maps[1] = new AttributeMap();
                maps[1].Add(vPosition, ParticleModel.position);
            }
            var nodes = new DataNode[2];
            for (int i = 0; i < 2; i++)
            {
                var model = new ParticleModel(particleCount);
                var node = DataNode.Create(model, providers, maps);
                node.Initialize();
                nodes[i] = node;
            }

            var result = new ParticleSimulatorNode(null);
            result.dataNodes = nodes;
            result.Initialize();

            return result;
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
