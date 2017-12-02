using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace NormalMapping
{
    partial class NormalMappingNode : ModernNode
    {
        public static NormalMappingNode Create()
        {
            var model = new NormalMappingModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("Position", NormalMappingModel.strPosition);
            map.Add("TexCoord", NormalMappingModel.strTexCoord);
            map.Add("Normal", NormalMappingModel.strNormal);
            map.Add("Tangent", NormalMappingModel.strTangent);
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

        private DirectionalLight__ m_dirLight;
        private Texture m_pTexture;
        private Texture m_pNormalMap;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            {
                var dirLight = new DirectionalLight__();
                dirLight.AmbientIntensity = 0.2f;
                dirLight.DiffuseIntensity = 0.8f;
                dirLight.Color = new vec3(1.0f, 1.0f, 1.0f);
                dirLight.Direction = new vec3(1.0f, 0.0f, 0.0f);
                program.SetUniform("gDirectionalLight.Base.Color", dirLight.Color);
                program.SetUniform("gDirectionalLight.Base.AmbientIntensity", dirLight.AmbientIntensity);
                program.SetUniform("gDirectionalLight.Base.DiffuseIntensity", dirLight.DiffuseIntensity);
                program.SetUniform("gDirectionalLight.Direction", dirLight.Direction.normalize());

                this.m_dirLight = dirLight;
            }
            {
                var bmp = new Bitmap(@"bricks.jpg");
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
                var bmp = new Bitmap(@"normal_map.jpg");
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
        }
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("gMVP", projection * view * model);
            program.SetUniform("gWorld", model);

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            // nothing to do.
        }
    }
}
