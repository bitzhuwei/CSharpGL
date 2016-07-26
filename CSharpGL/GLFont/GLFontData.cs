using System;
using System.Collections.Generic;

namespace CSharpGL
{
    class GLFontData
    {
        /// <summary>
        /// Mapping from a pair of characters to a pixel offset
        /// </summary>
        public Dictionary<String, int> KerningPairs;

        /// <summary>
        /// List of texture pages
        /// </summary>
        public GLFontTexture[] Pages;

        /// <summary>
        /// Mapping from character to glyph index
        /// </summary>
        public Dictionary<char, GLFontGlyph> CharSetMapping;

        /// <summary>
        /// The average glyph width
        /// </summary>
        public float meanGlyphWidth;

        /// <summary>
        /// The maximum glyph height
        /// </summary>
        public int maxGlyphHeight;

        /// <summary>
        /// Whether the original font (from ttf) was detected to be monospaced
        /// </summary>
        public bool naturallyMonospaced = false;

        public bool IsMonospacingActive(GLFontRenderOptions options)
        {
            return (options.Monospacing == GLFontMonospacing.Natural && naturallyMonospaced) || options.Monospacing == GLFontMonospacing.Yes;
        }

        public float GetMonoSpaceWidth(GLFontRenderOptions options)
        {
            return (float)Math.Ceiling(1 + (1 + options.CharacterSpacing) * meanGlyphWidth);
        }

        public void CalculateMeanWidth()
        {
            meanGlyphWidth = 0f;
            foreach (var glyph in CharSetMapping)
                meanGlyphWidth += glyph.Value.Rect.Width;
            meanGlyphWidth /= CharSetMapping.Count;
        }

        public void CalculateMaxHeight()
        {
            maxGlyphHeight = 0;
            foreach (var glyph in CharSetMapping)
                maxGlyphHeight = Math.Max(glyph.Value.Rect.Height, maxGlyphHeight);
        }

        /// <summary>
        /// Returns the kerning length correction for the character at the given index in the given string.
        /// Also, if the text is part of a textNode list, the nextNode is given so that the following 
        /// node can be checked incase of two adjacent word nodes.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="text"></param>
        /// <param name="textNode"></param>
        /// <returns></returns>
        public int GetKerningPairCorrection(int index, string text, GLFontTextNode textNode)
        {
            if (KerningPairs == null)
                return 0;

            var chars = new char[2];

            if (index + 1 == text.Length)
            {
                if (textNode != null && textNode.Next != null && textNode.Next.Type == GLFontTextNodeType.Word)
                    chars[1] = textNode.Next.Text[0];
                else
                    return 0;
            }
            else
            {
                chars[1] = text[index + 1];
            }

            chars[0] = text[index];

            String str = new String(chars);

            if (KerningPairs.ContainsKey(str))
                return KerningPairs[str];

            return 0;
        }
    }
}
