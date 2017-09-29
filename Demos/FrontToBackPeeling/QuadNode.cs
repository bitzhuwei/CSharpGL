using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    class QuadNode : ModernNode
    {
        public enum RenderMode { Blend = 0, Final = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }


        private Texture tempTexture;
        /// <summary>
        /// 
        /// </summary>
        public Texture TempTexture
        {
            get { return this.tempTexture; }
            set
            {
                this.tempTexture = value;

                RenderUnit unit = this.RenderUnits[(int)RenderMode.Blend];
                ShaderProgram program = unit.Program;
                program.SetUniform("tempTexture", value);
            }
        }

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
            //ICamera camera = arg.CameraStack.Peek();
            //mat4 projection = camera.GetProjectionMatrix();
            //mat4 view = camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();

            RenderUnit unit = this.RenderUnits[(int)this.Mode];
            //ShaderProgram program = unit.Program;

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
