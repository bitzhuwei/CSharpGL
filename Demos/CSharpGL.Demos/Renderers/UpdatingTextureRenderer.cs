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
        private sampler2D texture;
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
            var sampler = new sampler2D();
            sampler.Initialize(bitmap);
            bitmap.Dispose();
            this.texture = sampler;
            this.SetUniform("tex", new samplerValue(BindTextureTarget.Texture2D,
                sampler.Id, OpenGL.GL_TEXTURE0));
        }
    }
}
