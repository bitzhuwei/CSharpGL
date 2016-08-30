using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class UpdatingTextureRenderer : Renderer
    {
        private Texture texture;
        public static UpdatingTextureRenderer Create(TexturedRectangleModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\UpdatingTexture.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\UpdatingTexture.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", TexturedRectangleModel.strPosition);
            map.Add("in_TexCoord", TexturedRectangleModel.strTexCoord);
            var renderer = new UpdatingTextureRenderer(model, shaderCodes, map);
            return renderer;
        }

        private UpdatingTextureRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bitmap = new Bitmap(64, 64);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Red);
            }
            var texture = new Texture(BindTextureTarget.Texture2D, bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            this.texture = texture;
            this.SetUniform("tex", texture.ToSamplerValue());
            this.SetUniform("original", true);
        }

        public void UpdateTextureContent(Bitmap bitmap)
        {
            this.texture.UpdateContent(bitmap);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("mvp", projection * view);

            base.DoRender(arg);
        }
    }
}
