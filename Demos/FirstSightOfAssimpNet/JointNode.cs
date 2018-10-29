using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    partial class JointNode : ModernNode, IRenderable
    {
        private JointModel nodePointModel;
        public static JointNode Create(JointModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", JointModel.strPosition);
            map.Add("inBoneIndex", JointModel.strBoneIndex);
            var builder = new RenderMethodBuilder(array, map);
            var node = new JointNode(model, builder);
            node.Initialize();

            return node;
        }

        private JointNode(JointModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.nodePointModel = model; }


    }
}
