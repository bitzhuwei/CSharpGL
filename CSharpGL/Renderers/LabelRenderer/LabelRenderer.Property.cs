using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class LabelRenderer
    {
        #region Text

        private IFontTexture fontTexture;
        private TextModel model;

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
                    this.Name = string.Format("{0}: {1}", this.GetType().Name, value);
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

        #region World Position

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldPosition"></param>
        public void SetPosition(vec3 worldPosition)
        {
            this.ModelMatrix = glm.translate(mat4.identity(), worldPosition);
        }

        //private UpdatingRecord worldPositionRecord = new UpdatingRecord();
        //private vec3 worldPosition;
        ///// <summary>
        ///// 
        ///// </summary>
        //public vec3 WorldPosition
        //{
        //    get { return worldPosition; }
        //    set { worldPositionRecord.Set(ref worldPosition, value); }
        //}

        #endregion World Position

        #region Height

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

        #endregion Height

    }
}
