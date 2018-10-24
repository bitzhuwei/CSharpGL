using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMDualQuatNode : ModernNode, IRenderable
    {
        public static EZMDualQuatNode Create(EZMDualQuatModel model)
        {
            int boneCount = model.BoneCount;
            string completeVertexCode = vertexCode.Replace("UNDEFINED_BONE_COUNT", string.Format("{0}", boneCount * 2));
            var vs = new VertexShader(completeVertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", EZMDualQuatModel.strPosition);
            //map.Add("inNormal", EZMDualQuatModel.strNormal);
            map.Add("inUV", EZMDualQuatModel.strUV);
            map.Add("inBlendWeights", EZMDualQuatModel.strBlendWeights);
            map.Add("inBlendIndices", EZMDualQuatModel.strBlendIndices);
            var builder = new RenderMethodBuilder(array, map);//, new PolygonModeSwitch(PolygonMode.Line));
            var node = new EZMDualQuatNode(model, builder);
            node.Initialize();

            return node;
        }

        private EZMDualQuatModel textureModel;

        private EZMDualQuatNode(EZMDualQuatModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.textureModel = model; }

    }
}
