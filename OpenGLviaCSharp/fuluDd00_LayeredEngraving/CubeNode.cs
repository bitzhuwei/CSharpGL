using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDd00_LayeredEngraving
{
    class CubeNode : ModernNode, IRenderable
    {
        public enum RenderMode { Init = 0, Peel = 1 };

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
                    RenderMethod method = this.RenderUnit.Methods[i];
                    ShaderProgram program = method.Program;
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

                RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Peel];
                ShaderProgram program = method.Program;
                program.SetUniform("depthTexture", value);
            }
        }

        public static CubeNode Create(IBufferSource model, string positionNameInIBufferSource)
        {
            RenderMethodBuilder initBuilder, peelBuilder;
            {
                var vs = new VertexShader(Shaders.initVert);
                var fs = new FragmentShader(Shaders.initFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", positionNameInIBufferSource);
                initBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(Shaders.peelVert);// reuse blend vertex shader.
                var fs = new FragmentShader(Shaders.peelFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", positionNameInIBufferSource);
                peelBuilder = new RenderMethodBuilder(provider, map);
            }

            var node = new CubeNode(model, initBuilder, peelBuilder);
            node.Initialize();

            return node;
        }

        private CubeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[(int)this.Mode];
            ShaderProgram program = method.Program;
            program.SetUniform("MVP", projection * view * model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
