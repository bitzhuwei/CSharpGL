using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    class CubeNode : ModernNode
    {
        public enum RenderMode { Cube = 0, FrontPeel = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }

        private vec4 vColor;
        /// <summary>
        /// 
        /// </summary>
        public vec4 Color
        {
            get { return vColor; }
            set
            {
                this.vColor = value;

                for (int i = 0; i < this.RenderUnit.Methods.Length; i++)
                {
                    RenderMethod unit = this.RenderUnit.Methods[i];
                    ShaderProgram program = unit.Program;
                    program.SetUniform("vColor", value);
                }
            }
        }

        private Texture depthTexture;
        /// <summary>
        /// 
        /// </summary>
        public Texture DepthTexture
        {
            get { return this.depthTexture; }
            set
            {
                this.depthTexture = value;

                RenderMethod unit = this.RenderUnit.Methods[(int)RenderMode.FrontPeel];
                ShaderProgram program = unit.Program;
                program.SetUniform("depthTexture", value);
            }
        }

        public static CubeNode Create()
        {
            RenderMethodBuilder blendBuilder, finalBuilder;
            {
                var vs = new VertexShader(Shaders.cube_shaderVert, "vVertex");
                var fs = new FragmentShader(Shaders.cube_shaderFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", CubeModel.positions);
                blendBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(Shaders.front_peelVert, "vVertex");// reuse blend vertex shader.
                var fs = new FragmentShader(Shaders.front_peelFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", CubeModel.positions);
                finalBuilder = new RenderMethodBuilder(provider, map);
            }

            var model = new CubeModel();
            var node = new CubeNode(model, blendBuilder, finalBuilder);
            node.Initialize();

            return node;
        }

        private CubeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod unit = this.RenderUnit.Methods[(int)this.Mode];
            ShaderProgram program = unit.Program;
            program.SetUniform("MVP", projection * view * model);

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
