using System.ComponentModel;
using System.Drawing;

namespace CSharpGL
{
    public partial class UIText
    {
        private TextModel model;

        private IFontTexture fontTexture;

        private string text = string.Empty;

        /// <summary>
        ///
        /// </summary>
        [Category(strUIRenderer)]
        [Description("Displaying text.")]
        public string Text
        {
            get { return text; }
            set
            {
                if (this.model != null) { this.model.SetText(value, this.fontTexture); }
                this.text = value;
            }
        }

        private BlendSwitch blendSwitch = new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);

        /// <summary>
        ///
        /// </summary>
        [Category(strUIRenderer)]
        [Description("Blend mode.")]
        public BlendSwitch BlendSwitch
        {
            get { return blendSwitch; }
        }

        private UpdatingRecord textColorRecord = new UpdatingRecord();
        private vec3 textColor = new vec3(1, 1, 1);

        /// <summary>
        /// Text's color.
        /// </summary>
        [Category(strUIRenderer)]
        [Description("Text color.")]
        public Color TextColor
        {
            get { return textColor.ToColor(); }
            set
            {
                vec3 color = value.ToVec3();
                textColorRecord.Set(ref this.textColor, color);
            }
        }
    }
}