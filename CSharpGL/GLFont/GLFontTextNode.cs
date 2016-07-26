namespace CSharpGL
{
    class GLFontTextNode
    {
        public GLFontTextNodeType Type { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// pixel length (without tweaks)
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// length tweak for justification
        /// </summary>
        public float LengthTweak { get; set; }

        public float ModifiedLength
        {
            get { return Length + LengthTweak; }
        }

        public GLFontTextNode(GLFontTextNodeType type, string text)
        {
            this.Type = type;
            this.Text = text;
        }

        public GLFontTextNode Next { get; set; }
        public GLFontTextNode Previous { get; set; }
    }

}
