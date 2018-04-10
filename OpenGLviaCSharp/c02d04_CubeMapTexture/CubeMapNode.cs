using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture
{
    class CubeMapNode : ModernNode, IRenderable
    {

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }

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

        private float alpha = 0.21f;
        public float Alpha
        {
            get { return this.alpha; }
            set
            {
                this.alpha = value;
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Init];
                    ShaderProgram program = method.Program;
                    program.SetUniform("alpha", value);
                }
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Peel];
                    ShaderProgram program = method.Program;
                    program.SetUniform("alpha", value);
                }
            }
        }
        public static CubeMapNode Create(IBufferSource model, string positionNameInIBufferSource, Texture cubemapTexture)
        {
            RenderMethodBuilder initBuilder, peelBuilder;
            {
                var vs = new VertexShader(Shaders.initVert);
                var fs = new FragmentShader(Shaders.initFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new PropertyMap();
                map.Add("vVertex", positionNameInIBufferSource);
                initBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(Shaders.peelVert);// reuse blend vertex shader.
                var fs = new FragmentShader(Shaders.peelFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new PropertyMap();
                map.Add("vVertex", positionNameInIBufferSource);
                peelBuilder = new RenderMethodBuilder(provider, map);
            }

            var node = new CubeMapNode(model, initBuilder, peelBuilder);
            node.SetTexture(cubemapTexture);
            node.Initialize();

            return node;
        }

        private Texture cubemapTexture;
        private void SetTexture(Texture cubemapTexture)
        {
            this.cubemapTexture = cubemapTexture;
        }

        private CubeMapNode(IBufferSource model, params RenderMethodBuilder[] builders)
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
            program.SetUniform("tex", this.cubemapTexture);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
