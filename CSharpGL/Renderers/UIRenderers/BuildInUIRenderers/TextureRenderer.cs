using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a bitmap in a squre.
    /// </summary>
    class TextureRenderer : PickableRenderer
    {
        private string bitmapFilename;

        public static TextureRenderer Create(string bitmapFilename = "")
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.SquareRenderer.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.SquareRenderer.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Square.strPosition);
            map.Add("in_TexCoord", Square.strTexCoord);
            var model = new Square();
            var renderer = new TextureRenderer(model, shaderCodes, map, Square.strPosition);
            renderer.bitmapFilename = bitmapFilename;
            return renderer;
        }

        private TextureRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            Bitmap bitmap;
            if (string.IsNullOrEmpty(this.bitmapFilename))// display a cursor as default.
            { bitmap = ManifestResourceLoader.LoadBitmap(@"Resources\cursor_gold.png"); }
            else
            { bitmap = new Bitmap(this.bitmapFilename); }
            var sampler = new Texture(bitmap);
            sampler.Initialize();
            bitmap.Dispose();
            this.SetUniform("tex", new samplerValue(BindTextureTarget.Texture2D,
                sampler.Id, OpenGL.GL_TEXTURE0));
        }
    }
}
