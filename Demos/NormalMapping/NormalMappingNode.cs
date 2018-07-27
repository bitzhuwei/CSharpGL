using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace NormalMapping
{
    partial class NormalMappingNode : ModernNode, IRenderable
    {
        public static NormalMappingNode Create()
        {
            var model = new NormalMappingModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", NormalMappingModel.strPosition);
            map.Add("inTexCoord", NormalMappingModel.strTexCoord);
            map.Add("inNormal", NormalMappingModel.strNormal);
            map.Add("inTangent", NormalMappingModel.strTangent);
            var builder = new RenderMethodBuilder(array, map);
            var node = new NormalMappingNode(model, builder);
            node.ModelSize = new vec3(2, 2, 0.1f);
            node.Initialize();

            return node;
        }

        private NormalMappingNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        private DirectionalLight m_dirLight;
        private Texture m_pTexture;
        private Texture m_pNormalMap;
        private Texture m_pNotNormalMap;

        private bool normalMapping = true;
        public bool NormalMapping
        {
            get { return this.normalMapping; }
            set
            {
                this.normalMapping = value;

                RenderMethod method = this.RenderUnit.Methods[0];
                ShaderProgram program = method.Program;
                program.SetUniform("gNormalMap", value ? this.m_pNormalMap : this.m_pNotNormalMap);
            }
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            {
                var dirLight = new DirectionalLight(new vec3(1.0f, 0.0f, 0.0f));
                dirLight.Diffuse = new vec3(0.8f);
                dirLight.Specular = new vec3(0.8f);
                program.SetUniform("light.color", dirLight.Diffuse);
                program.SetUniform("light.ambient", 0.2f);
                program.SetUniform("light.diffuse", 0.8f);
                program.SetUniform("light.Direction", dirLight.Direction.normalize());

                this.m_dirLight = dirLight;
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bmp = new Bitmap(System.IO.Path.Combine(folder, @"bricks.jpg"));
                var storage = new TexImageBitmap(bmp);
                var texture = new Texture(storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.TextureUnitIndex = 0;
                texture.Initialize();
                bmp.Dispose();
                program.SetUniform("gColorMap", texture);
                this.m_pTexture = texture;
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bmp = new Bitmap(System.IO.Path.Combine(folder, @"normal_map.jpg"));
                var storage = new TexImageBitmap(bmp);
                var texture = new Texture(storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.TextureUnitIndex = 2;
                texture.Initialize();
                bmp.Dispose();
                program.SetUniform("gNormalMap", texture);
                this.m_pNormalMap = texture;
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bmp = new Bitmap(System.IO.Path.Combine(folder, @"normal_up.jpg"));
                var storage = new TexImageBitmap(bmp);
                var texture = new Texture(storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.TextureUnitIndex = 2;
                texture.Initialize();
                bmp.Dispose();
                //program.SetUniform("gNormalMap", texture);
                this.m_pNotNormalMap = texture;
            }
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
            mat4 normal = glm.transpose(glm.inverse(view * model));

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("modelMat", model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            // nothing to do.
        }
    }
}
