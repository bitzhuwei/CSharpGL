using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Renders a label(a single line of text) that always faces camera in 3D space.
    /// </summary>
    public partial class LabelRenderer : Renderer
    {
        private IFontTexture fontTexture;
        private TextModel model;

        private UpdatingRecord worldPositionRecord = new UpdatingRecord();
        private vec3 worldPosition;
        /// <summary>
        /// 
        /// </summary>
        public vec3 WorldPosition
        {
            get { return worldPosition; }
            set { worldPositionRecord.Set(ref worldPosition, value); }
        }
        private UpdatingRecord labelHeightRecord = new UpdatingRecord();
        private int labelHeight;
        /// <summary>
        /// Label's height(in pixels of OpenGL's viewport)
        /// </summary>
        public int LabelHeight
        {
            get { return labelHeight; }
            set { labelHeightRecord.Set(ref labelHeight, value); }
        }

        private string content = string.Empty;
        /// <summary>
        /// Displayed text whose maximum length is limited by constructor's maxCharCount parameter.
        /// </summary>
        public string Text
        {
            get { return content; }
            set
            {
                if (this.model != null) { this.model.SetText(value, this.fontTexture); }
                this.content = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxCharCount">Max char count to display for this label.
        /// Careful to set this value because greater <paramref name="maxCharCount"/> means more space ocupied in GPU nemory.</param>
        /// <param name="labelHeight">Label height(in pixels)</param>
        /// <param name="fontTexture">Use which font to render text?</param>
        public LabelRenderer(int maxCharCount = 64, int labelHeight = 32, IFontTexture fontTexture = null)
            : base(null, null, null, new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.One))
        {
            if (fontTexture == null)
            { this.fontTexture = FontResource.Default; }// FontResource.Default; }
            else
            { this.fontTexture = fontTexture; }

            this.LabelHeight = labelHeight;

            var model = new TextModel(maxCharCount);
            this.bufferable = model;
            this.model = model;

            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.frag"), ShaderType.FragmentShader);
            this.shaderCodes = shaderCodes;

            var map = new PropertyNameMap();
            map.Add("in_Position", TextModel.strPosition);
            map.Add("in_UV", TextModel.strUV);
            this.propertyNameMap = map;
        }

    }
}
