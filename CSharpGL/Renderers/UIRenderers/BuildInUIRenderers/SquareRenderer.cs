using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders an square with texture.
    /// </summary>
    class SquareRenderer : PickableRenderer
    {
        private string cursorBitmap;

        public static SquareRenderer Create(string cursorBitmap = "")
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
            var renderer = new SquareRenderer(model, shaderCodes, map, Square.strPosition);
            renderer.cursorBitmap = cursorBitmap;
            return renderer;
        }

        private SquareRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            Bitmap bitmap;
            if (string.IsNullOrEmpty(this.cursorBitmap))
            { bitmap = ManifestResourceLoader.LoadBitmap(@"Resources\cursor_gold.png"); }
            else
            { bitmap = new Bitmap(this.cursorBitmap); }
            var sampler = new Texture(bitmap);
            sampler.Initialize();
            bitmap.Dispose();
            this.SetUniform("tex", new samplerValue(BindTextureTarget.Texture2D,
                sampler.Id, OpenGL.GL_TEXTURE0));
        }
    }
}
