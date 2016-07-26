namespace CSharpGL
{
    public class GLFontRenderOptions
    {
        /// <summary>
        /// Spacing between characters in units of average glyph width
        /// </summary>
        public float CharacterSpacing = 0.05f;

        /// <summary>
        /// Spacing between words in units of average glyph width
        /// </summary>
        public float WordSpacing = 0.6f;

        /// <summary>
        /// Line spacing in units of max glyph width
        /// </summary>
        public float LineSpacing = 1.0f;

        /// <summary>
        /// Whether to render the font in monospaced mode. If set to "Natural", then 
        /// monospacing will be used if the font loaded font was detected to be monospaced.
        /// </summary>
        public GLFontMonospacing Monospacing = GLFontMonospacing.Natural;

        /// <summary>
        /// Locks the position to a particular pixel, allowing the text to be rendered pixel-perfectly.
        /// You need to turn this off if you wish to move text around the screen smoothly by fractions 
        /// of a pixel.
        /// </summary>
        public bool LockToPixel;

        /// <summary>
        /// Only applies when LockToPixel is true:
        /// This is used to transition smoothly between being locked to pixels and not
        /// </summary>
        public float LockToPixelRatio = 1.0f;

        /// <summary>
        /// Wrap word to next line if max width hit
        /// </summary>
        public bool WordWrap = true;


        #region Justify Options

        /// <summary>
        /// When a line of text is justified, space may be inserted between
        /// characters, and between words. 
        /// 
        /// This parameter determines how this choice is weighted:
        /// 
        /// 0.0f => word spacing only
        /// 1.0f => "fairly" distributed between both
        /// > 1.0 => in favour of character spacing
        /// 
        /// This applies to expansions only.
        /// 
        /// </summary>
        public float JustifyCharacterWeightForExpand
        {
            get { return justifyCharWeightForExpand; }
            set
            {
                justifyCharWeightForExpand = value;
                if (justifyCharWeightForExpand < 0f)
                    justifyCharWeightForExpand = 0f;
                else if (justifyCharWeightForExpand > 1.0f)
                    justifyCharWeightForExpand = 1.0f;
            }
        }

        private float justifyCharWeightForExpand = 0.5f;

        /// <summary>
        /// When a line of text is justified, space may be removed between
        /// characters, and between words. 
        /// 
        /// This parameter determines how this choice is weighted:
        /// 
        /// 0.0f => word spacing only
        /// 1.0f => "fairly" distributed between both
        /// > 1.0 => in favour of character spacing
        /// 
        /// This applies to contractions only.
        /// 
        /// </summary>
        public float JustifyCharacterWeightForContract
        {
            get { return justifyCharWeightForContract; }
            set
            {
                justifyCharWeightForContract = value;
                if (justifyCharWeightForContract < 0f)
                    justifyCharWeightForContract = 0f;
                else if (justifyCharWeightForContract > 1.0f)
                    justifyCharWeightForContract = 1.0f;
            }
        }

        private float justifyCharWeightForContract = 0.2f;

        /// <summary>
        /// Total justification cap as a fraction of the boundary width.
        /// </summary>
        public float JustifyCapExpand = 0.5f;

        /// <summary>
        /// Total justification cap as a fraction of the boundary width.
        /// </summary>
        public float JustifyCapContract = 0.1f;

        /// <summary>
        /// By what factor justification is penalized for being negative.
        /// 
        /// (e.g. if this is set to 3, then a contraction will only happen
        /// over an expansion if it is 3 of fewer times smaller than the
        /// expansion).
        /// 
        /// 
        /// </summary>
        public float JustifyContractionPenalty = 2;

        #endregion
    }
}
