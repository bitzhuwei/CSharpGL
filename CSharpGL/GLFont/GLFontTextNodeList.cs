using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpGL.NewFontResource
{
    /// <summary>
    /// A doubly linked list of text nodes
    /// </summary>
    class GLFontTextNodeList : IEnumerable<GLFontTextNode>
    {
        public GLFontTextNode Head;
        public GLFontTextNode Tail;

        /// <summary>
        /// Builds a doubly linked list of text nodes from the given input string
        /// </summary>
        /// <param name="text"></param>
        public GLFontTextNodeList(string text)
        {
            bool carriageReturn = false;
            bool wordInProgress = false;
            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\r' || text[i] == '\n' || text[i] == ' ' || text[i] == '\t')
                {
                    if (text[i] == '\n' && carriageReturn) //text = text.Replace("\r\n", "\r");
                        continue;
                    carriageReturn = false;
                    if (text[i] == '\r')
                        carriageReturn = true;

                    if (wordInProgress)
                    {
                        Add(new GLFontTextNode(GLFontTextNodeType.Word, currentWord.ToString()));
                        wordInProgress = false;
                    }

                    if (text[i] == '\r' || text[i] == '\n')
                        Add(new GLFontTextNode(GLFontTextNodeType.LineBreak, null));
                    else if (text[i] == ' ')
                        Add(new GLFontTextNode(GLFontTextNodeType.Space, null));
                    else if (text[i] == '\t')
                        Add(new GLFontTextNode(GLFontTextNodeType.Tab, null));
                }
                else
                {
                    carriageReturn = false;
                    if (!wordInProgress)
                    {
                        wordInProgress = true;
                        currentWord = new StringBuilder();
                    }
                    currentWord.Append(text[i]);
                }
            }

            if (wordInProgress)
                Add(new GLFontTextNode(GLFontTextNodeType.Word, currentWord.ToString()));
        }

        public void MeasureNodes(GLFontData fontData, GLFontRenderOptions options)
        {
            bool monospaced = fontData.IsMonospacingActive(options);
            float monospaceWidth = fontData.GetMonoSpaceWidth(options);
            foreach (GLFontTextNode node in this)
            {
                if (node.Length == 0f)
                {
                    if (node.Type == GLFontTextNodeType.Space)
                    {
                        if (monospaced)
                        {
                            node.Length = monospaceWidth;
                            continue;
                        }
                        node.Length = (float)Math.Ceiling(fontData.meanGlyphWidth * options.WordSpacing);
                        continue;
                    }

                    if (node.Type == GLFontTextNodeType.Tab)
                    {
                        if (monospaced)
                        {
                            node.Length = monospaceWidth * 4;
                            continue;
                        }
                        node.Length = (float)Math.Ceiling(4 * fontData.meanGlyphWidth * options.WordSpacing);
                        continue;
                    }

                    if (node.Type == GLFontTextNodeType.Word)
                    {
                        for (int i = 0; i < node.Text.Length; i++)
                        {
                            char c = node.Text[i];
                            GLFontGlyph glyph;
                            if (fontData.CharSetMapping.TryGetValue(c, out glyph))
                            {
                                if (monospaced)
                                    node.Length += monospaceWidth;
                                else
                                    node.Length += (float)Math.Ceiling(glyph.Rect.Width + fontData.meanGlyphWidth * options.CharacterSpacing + fontData.GetKerningPairCorrection(i, node.Text, node));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Splits a word into sub-words of size less than or equal to baseCaseSize 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="baseCaseSize"></param>
        public void Crumble(GLFontTextNode node, int baseCaseSize)
        {
            if (node.Text.Length <= baseCaseSize)
                return;

            var left = SplitNode(node);
            var right = left.Next;
            Crumble(left, baseCaseSize);
            Crumble(right, baseCaseSize);
        }

        /// <summary>
        /// Splits a word node in two, adding both new nodes to the list in sequence.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>The first new node</returns>
        public GLFontTextNode SplitNode(GLFontTextNode node)
        {
            if (node.Type != GLFontTextNodeType.Word)
                throw new Exception("Cannot split text node of type: " + node.Type);

            int midPoint = node.Text.Length / 2;

            string newFirstHalf = node.Text.Substring(0, midPoint);
            string newSecondHalf = node.Text.Substring(midPoint, node.Text.Length - midPoint);

            GLFontTextNode newFirst = new GLFontTextNode(GLFontTextNodeType.Word, newFirstHalf);
            GLFontTextNode newSecond = new GLFontTextNode(GLFontTextNodeType.Word, newSecondHalf);
            newFirst.Next = newSecond;
            newSecond.Previous = newFirst;

            //node is head
            if (node.Previous == null)
                Head = newFirst;
            else
            {
                node.Previous.Next = newFirst;
                newFirst.Previous = node.Previous;
            }

            //node is tail
            if (node.Next == null)
                Tail = newSecond;
            else
            {
                node.Next.Previous = newSecond;
                newSecond.Next = node.Next;
            }

            return newFirst;
        }

        public void Add(GLFontTextNode node)
        {
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (GLFontTextNode node in this)
            {
                if (node.Type == GLFontTextNodeType.Space)
                    builder.Append(" ");
                else if (node.Type == GLFontTextNodeType.Tab)
                    builder.Append("    ");
                else if (node.Type == GLFontTextNodeType.LineBreak)
                    builder.Append(System.Environment.NewLine);
                else if (node.Type == GLFontTextNodeType.Word)
                    builder.Append("" + node.Text + "");
            }

            return builder.ToString();
        }

        public IEnumerator<GLFontTextNode> GetEnumerator()
        {
            GLFontTextNode currentNode = this.Head;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
