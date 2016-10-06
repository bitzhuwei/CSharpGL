namespace CSharpGL
{
    /// <summary>
    /// Renders a label(a single line of text).
    /// </summary>
    public partial class TextRenderer : Renderer
    {
        /// <summary>
        /// Create a text renderer.
        /// </summary>
        /// <param name="maxCharCount">Max char count to display for this label. Careful to set this value because greater <paramref name="maxCharCount"/> means more space ocupied in GPU nemory.</param>
        /// <param name="labelHeight">Label height(in pixels)</param>
        /// <param name="fontTexture">Use which font to render text?</param>
        /// <returns></returns>
        public static TextRenderer Create(int maxCharCount = 64, int labelHeight = 32, IFontTexture fontTexture = null)
        {
            if (fontTexture == null) { fontTexture = FontTexture.Default; }// FontResource.Default; }

            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.TextModel.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.TextModel.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("position", TextModel.strPosition);
            map.Add("uv", TextModel.strUV);
            var model = new TextModel(maxCharCount);
            var renderer = new TextRenderer(model, shaderCodes, map);
            renderer.fontTexture = fontTexture;

            return renderer;
        }

        /// <summary>
        /// Renders a label(a single line of text).
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="attributeMap"></param>
        /// <param name="switches"></param>
        private TextRenderer(TextModel model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            this.textModel = model;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: [{1}]", base.ToString(), this.text);
        }
    }
}