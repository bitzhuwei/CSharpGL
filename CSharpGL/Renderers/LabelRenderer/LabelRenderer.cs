namespace CSharpGL
{
    /// <summary>
    /// Renders a label(a single line of text) that always faces camera in 3D space.
    /// </summary>
    public partial class LabelRenderer : Renderer
    {
        /// <summary>
        /// Create a label renderer.
        /// </summary>
        /// <param name="maxCharCount">Max char count to display for this label. Careful to set this value because greater <paramref name="maxCharCount"/> means more space ocupied in GPU nemory.</param>
        /// <param name="labelHeight">Label height(in pixels)</param>
        /// <param name="fontTexture">Use which font to render text?</param>
        /// <returns></returns>
        public static LabelRenderer Create(int maxCharCount = 64, int labelHeight = 32, IFontTexture fontTexture = null)
        {
            if (fontTexture == null) { fontTexture = FontTexture.Default; }

            var model = new TextModel(maxCharCount);

            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.frag"), ShaderType.FragmentShader);

            var map = new AttributeNameMap();
            map.Add("in_Position", TextModel.strPosition);
            map.Add("in_UV", TextModel.strUV);

            var blendSwitch = new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.One);

            var renderer = new LabelRenderer(model, shaderCodes, map, blendSwitch);
            renderer.blendSwitch = blendSwitch;
            renderer.fontTexture = fontTexture;
            renderer.LabelHeight = labelHeight;

            return renderer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="attributeNameMap"></param>
        /// <param name="switches"></param>
        private LabelRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, switches)
        {
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