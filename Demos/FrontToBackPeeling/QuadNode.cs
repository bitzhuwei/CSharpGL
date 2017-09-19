using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    class QuadNode : ModernNode
    {
        public enum RenderMode { Blend = 0, FInal = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }

        public static QuadNode Create()
        {
            RenderUnitBuilder blendBuilder, finalBuilder;
            {
                var vs = new VertexShader(Shaders.blendVert, "vVertex");
                var fs = new FragmentShader(Shaders.blendFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", QuadModel.positions);
                blendBuilder = new RenderUnitBuilder(provider, map);
            }
            {
                var vs = new VertexShader(Shaders.blendVert, "vVertex");// reuse blend vertex shader.
                var fs = new FragmentShader(Shaders.finalFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", QuadModel.positions);
                finalBuilder = new RenderUnitBuilder(provider, map);
            }

            var model = new QuadModel();
            var node = new QuadNode(model, blendBuilder, finalBuilder);
            node.Initialize();

            return node;
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
