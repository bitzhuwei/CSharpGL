using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// Renders a bitmap in a square.
    /// </summary>
    internal class TextureRenderer : PickableRenderer
    {
        private string bitmapFilename;

        /// <summary>
        /// Gets a renderer that renders a bitmap in a square.
        /// </summary>
        /// <param name="bitmapFilename"></param>
        /// <returns></returns>
        public static TextureRenderer Create(string bitmapFilename = "")
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.SquareRenderer.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.SquareRenderer.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", Square.strPosition);
            map.Add("in_TexCoord", Square.strTexCoord);
            var model = new Square();
            var renderer = new TextureRenderer(model, shaderCodes, map, Square.strPosition);
            renderer.bitmapFilename = bitmapFilename;
            return renderer;
        }

        private TextureRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            Bitmap bitmap;
            if (string.IsNullOrEmpty(this.bitmapFilename))// display a cursor as default.
            { bitmap = ManifestResourceLoader.LoadBitmap(@"Resources\cursor_gold.png"); }
            else
            { bitmap = new Bitmap(this.bitmapFilename); }
            var texture = new Texture(TextureTarget.Texture2D, bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            this.SetUniform("tex", texture);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} for rendering Cursor.", base.ToString());
        }
    }
}