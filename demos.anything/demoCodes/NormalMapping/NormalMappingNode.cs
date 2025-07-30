using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;
using demos.anything;

namespace NormalMapping {
    partial class NormalMappingNode : ModernNode, IRenderable {
        public static NormalMappingNode Create(IBufferSource model, vec3 size, string position, string texCoord, string normal, string tangent) {
            //var model = new NormalMappingModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            //map.Add("inPosition", NormalMappingModel.strPosition);
            //map.Add("inTexCoord", NormalMappingModel.strTexCoord);
            //map.Add("inNormal", NormalMappingModel.strNormal);
            //map.Add("inTangent", NormalMappingModel.strTangent);
            map.Add("inPosition", position);
            map.Add("inTexCoord", texCoord);
            map.Add("inNormal", normal);
            map.Add("inTangent", tangent);
            var builder = new RenderMethodBuilder(program, map);
            var node = new NormalMappingNode(model, builder);
            node.ModelSize = size;
            node.Initialize();

            return node;
        }

        private NormalMappingNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        private CSharpGL.DirectionalLight directionalLight;
        private Texture texColor;
        private Texture texNormal;
        private Texture texNoNormal;

        private bool normalMapping = true;
        public bool NormalMapping {
            get { return this.normalMapping; }
            set {
                this.normalMapping = value;

                RenderMethod method = this.RenderUnit.Methods[0];
                GLProgram program = method.Program;
                program.SetUniform("texNormal", value ? this.texNormal : this.texNoNormal);
            }
        }

        public vec3 LightDirection {
            get { return this.directionalLight.Direction; }
            set {
                var dirLight = this.directionalLight;
                dirLight.Direction = value;
                RenderMethod method = this.RenderUnit.Methods[0];
                GLProgram program = method.Program;
                program.SetUniform("light.direction", value.normalize());
            }
        }
        protected override void DoInitialize() {
            base.DoInitialize();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            {
                var light = new CSharpGL.DirectionalLight(new vec3(5, 5, -0.5f));
                light.Diffuse = new vec3(0.8f);
                light.Specular = new vec3(0.8f);
                program.SetUniform("light.color", light.Diffuse);
                program.SetUniform("light.ambient", 0.2f);
                program.SetUniform("light.diffuse", 0.8f);
                program.SetUniform("light.direction", light.Direction.normalize());

                this.directionalLight = light;
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bmp = new Bitmap("media/textures/earth.png");
                var winGLBitmap = new WinGLBitmap(bmp);
                var storage = new TexImageBitmap(winGLBitmap);
                var texture = new Texture(storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.textureUnitIndex = 0;
                texture.Initialize();
                bmp.Dispose();
                program.SetUniform("texColor", texture);
                this.texColor = texture;
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bmp = new Bitmap("media/textures/earth-bump.png");
                var winGLBitmap = new WinGLBitmap(bmp);
                var storage = new TexImageBitmap(winGLBitmap);
                var texture = new Texture(storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.textureUnitIndex = 2;
                texture.Initialize();
                bmp.Dispose();
                program.SetUniform("texNormal", texture);
                this.texNormal = texture;
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bmp = new Bitmap("media/textures/earth-nobump.png");
                var winGLBitmap = new WinGLBitmap(bmp);
                var storage = new TexImageBitmap(winGLBitmap);
                var texture = new Texture(storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.textureUnitIndex = 2;
                texture.Initialize();
                bmp.Dispose();
                //program.SetUniform("texNormal", texture);
                this.texNoNormal = texture;
            }
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("modelMat", model);
            program.SetUniform("eyeWorldPos", camera.Position);
            program.SetUniform("light.direction", -(camera.Position - camera.Target).normalize());

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            // nothing to do.
        }
    }
}
