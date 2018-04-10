using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace SimpleParticleSystem
{
    partial class ParticleNode : ModernNode, IRenderable
    {
        public static ParticleNode Create()
        {
            var blend = new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);
            var depthTest = new DepthTestSwitch(false);
            RenderMethodBuilder defaultBuilder, textureBuilder;
            {
                var vs = new VertexShader(vert);
                var fs = new FragmentShader(frag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                defaultBuilder = new RenderMethodBuilder(provider, map, blend, depthTest);
            }
            {
                var vs = new VertexShader(vert);
                var fs = new FragmentShader(texturedFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                textureBuilder = new RenderMethodBuilder(provider, map, blend, depthTest);
            }

            var model = new ParticleModel();
            var node = new ParticleNode(model, defaultBuilder, textureBuilder);
            node.Initialize();

            return node;
        }

        private ParticleNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            string folder = System.Windows.Forms.Application.StartupPath;
            var image = new Bitmap(System.IO.Path.Combine(folder, "particle.png"));
            this.UpdateTexture(image);

            this.DeltaTime = 0.03f;
        }

        private float time;

        public float DeltaTime { get; set; }

        public enum RenderMode { Default = 0, Textured = 1 };

        public RenderMode Mode { get; set; }

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
            program.SetUniform("time", time); time += this.DeltaTime;
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }


        private Texture currentTexture;

        /// <summary>
        /// Load a user defined heightmap
        /// </summary>
        /// <param name="image"></param>
        public void UpdateTexture(Bitmap image)
        {
            if (this.currentTexture != null)
            {
                this.currentTexture.Dispose();
            }

            var storage = new TexImageBitmap(image);
            var texture = new Texture(storage,
                //new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR)
                );
            texture.TextureUnitIndex = 0;
            texture.Initialize();

            RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Textured];
            ShaderProgram program = method.Program;
            program.SetUniform("textureMap", texture);

            this.currentTexture = texture;
        }
    }
}
