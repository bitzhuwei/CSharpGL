using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMTextureNode : ModernNode, IRenderable
    {
        public static EZMTextureNode Create(EZMTextureModel model)
        {
            int boneCount = model.BoneCount;
            string completeVertexCode = vertexCode.Replace("UNDEFINED_BONE_COUNT", string.Format("{0}", boneCount));
            var vs = new VertexShader(completeVertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", EZMTextureModel.strPosition);
            map.Add("inNormal", EZMTextureModel.strNormal);
            map.Add("inUV", EZMTextureModel.strUV);
            var builder = new RenderMethodBuilder(array, map, new PolygonModeSwitch(PolygonMode.Line));
            var node = new EZMTextureNode(model, builder);
            node.Initialize();

            return node;
        }

        private EZMTextureModel textureModel;
        
        private EZMTextureNode(EZMTextureModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.textureModel = model; }

    }
}
