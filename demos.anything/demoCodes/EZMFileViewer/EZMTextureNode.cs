using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EZMFileViewer {
    partial class EZMTextureNode : ModernNode, IRenderable {
        public static EZMTextureNode Create(EZMTextureModel model) {
            int boneCount = model.BoneCount;
            string completeVertexCode = vertexCode.Replace("UNDEFINED_BONE_COUNT", string.Format("{0}", boneCount));
            var program = GLProgram.Create(completeVertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", EZMTextureModel.strPosition);
            //map.Add("inNormal", EZMTextureModel.strNormal);
            map.Add("inUV", EZMTextureModel.strUV);
            map.Add("inBlendWeights", EZMTextureModel.strBlendWeights);
            map.Add("inBlendIndices", EZMTextureModel.strBlendIndices);
            var builder = new RenderMethodBuilder(program, map);//, new PolygonModeSwitch(PolygonMode.Line));
            var node = new EZMTextureNode(model, builder);
            node.Initialize();

            return node;
        }

        private EZMTextureModel textureModel;

        private EZMTextureNode(EZMTextureModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.textureModel = model; }

    }
}
