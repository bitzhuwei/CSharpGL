namespace CSharpGL
{
    public partial class LabelRenderer
    {
        #region Text

        private IFontTexture fontTexture;

        private string text = string.Empty;
        private UpdatingRecord textRecord = new UpdatingRecord();

        /// <summary>
        /// Displayed text whose maximum length is limited by constructor's maxCharCount parameter.
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                if (value != this.text)
                {
                    this.text = value;
                    this.textRecord.Mark();
                }
                //if (this.model != null) { this.model.SetText(value, this.fontTexture); }
            }
        }

        #endregion Text

        #region discard

        private GLSwitch blendSwitch;
        private bool discardTransparency = true;
        private UpdatingRecord discardTransparencyRecord = new UpdatingRecord();

        /// <summary>
        /// If true, transparent part of glyph will be discarded in shader, which avoids wrrong blend effect and reduce looking effect.
        /// </summary>
        public bool DiscardTransparency
        {
            get { return discardTransparency; }
            set
            {
                if (discardTransparency != value)
                {
                    discardTransparency = value;
                    discardTransparencyRecord.Mark();
                }
            }
        }

        #endregion discard

        #region Height

        private UpdatingRecord labelHeightRecord = new UpdatingRecord();
        private int labelHeight;

        /// <summary>
        /// Label's height(in pixels of OpenGL's viewport)
        /// </summary>
        public int LabelHeight
        {
            get { return labelHeight; }
            set
            {
                if (value != this.labelHeight)
                {
                    this.labelHeight = value;
                    this.labelHeightRecord.Mark();
                }
            }
        }

        #endregion Height
    }
}