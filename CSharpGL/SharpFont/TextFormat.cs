using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    public sealed class TextFormat
    {
        public FontFace Font { get; set; }
        public float Size { get; set; }
        public float TabStop { get; set; }
        public TextStyle Style { get; set; }
        public TextAlignment LineAlignment { get; set; }
        public TextAlignment ParagraphAlignment { get; set; }
        public BreakDelimiter WordWrap { get; set; }
        public BreakDelimiter Trimming { get; set; }
        public char TrimmingRelacement { get; set; }
    }

    [Flags]
    public enum TextStyle
    {
        None,
        Strikeout = 0x1,
        Underline = 0x2
    }

    public enum TextAlignment
    {
        Near,
        Far,
        Center
    }

    public enum BreakDelimiter
    {
        None,
        Character,
        Word
    }
}
