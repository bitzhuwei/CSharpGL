using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace CSharpGL
{
    public class GLFont
    {
        public float LineSpacing { get { return (float)Math.Ceiling(fontData.maxGlyphHeight * Options.LineSpacing); } }
        public bool IsMonospacingActive { get { return fontData.IsMonospacingActive(Options); } }
        public float MonoSpaceWidth { get { return fontData.GetMonoSpaceWidth(Options); } }
        public GLFontRenderOptions Options { get { if (options == null) options = new GLFontRenderOptions(); return options; } private set { options = value; } }
        private GLFontRenderOptions options;

        private GLFontData fontData;
        private float lineSpacingCache;
        private bool isMonospacingActiveCache;
        private float monoSpaceWidthCache;

        public GLFont(Font font, GLFontBuilderConfiguration config = null)
        {
            options = new GLFontRenderOptions();

            if (config == null)
                config = new GLFontBuilderConfiguration();

            fontData = new GLFontBuilder(font, config).BuildFontData();
        }

        public GLFont(string fileName, float size, FontStyle style = FontStyle.Regular) : this(fileName, size, null, style) { }
        public GLFont(string fileName, float size, GLFontBuilderConfiguration config, FontStyle style = FontStyle.Regular)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(fileName);
            var fontFamily = pfc.Families[0];

            if (!fontFamily.IsStyleAvailable(style))
                throw new ArgumentException("Font file: " + fileName + " does not support style: " + style);

            if (config == null)
                config = new GLFontBuilderConfiguration();

            using (var font = new Font(fontFamily, size * config.SuperSampleLevels, style))
            {
                fontData = new GLFontBuilder(font, config).BuildFontData();
            }
            pfc.Dispose();
        }

        private vec2 LockToPixel(vec2 input)
        {
            if (Options.LockToPixel)
            {
                float r = Options.LockToPixelRatio;
                return new vec2((1 - r) * input.x + r * ((int)Math.Round(input.x)), (1 - r) * input.y + r * ((int)Math.Round(input.y)));
            }
            return input;
        }

        public SizeF ProcessText(GLFontText processedText, string text, GLFontAlignment alignment = GLFontAlignment.Left)
        {
            return ProcessText(processedText, text, new SizeF(float.MaxValue, float.MaxValue), alignment);
        }
        public SizeF ProcessText(GLFontText processedText, string text, SizeF maxSize, GLFontAlignment alignment = GLFontAlignment.Left)
        {
            if (processedText == null)
                throw new ArgumentNullException("processedText");

            var nodeList = new GLFontTextNodeList(text);
            nodeList.MeasureNodes(fontData, Options);

            if (!Options.WordWrap)
            {
                //we "crumble" words that are two long so that that can be split up
                var nodesToCrumble = new List<GLFontTextNode>();
                foreach (GLFontTextNode node in nodeList)
                    if (node.Length >= maxSize.Width && node.Type == GLFontTextNodeType.Word)
                        nodesToCrumble.Add(node);

                if (nodesToCrumble.Count > 0)
                {
                    foreach (var node in nodesToCrumble)
                        nodeList.Crumble(node, 1);

                    //need to measure crumbled words
                    nodeList.MeasureNodes(fontData, Options);
                }
            }

            if (processedText.VertexBuffers == null)
            {
                processedText.VertexBuffers = new GLFontVertexBuffer[fontData.Pages.Length];
                for (int i = 0; i < processedText.VertexBuffers.Length; i++)
                    processedText.VertexBuffers[i] = new GLFontVertexBuffer(fontData.Pages[i].TextureID);
            }
            if (processedText.VertexBuffers[0].TextureID != fontData.Pages[0].TextureID)
            {
                for (int i = 0; i < processedText.VertexBuffers.Length; i++)
                    processedText.VertexBuffers[i].TextureID = fontData.Pages[i].TextureID;
            }
            processedText.textNodeList = nodeList;
            processedText.maxSize = maxSize;
            processedText.alignment = alignment;

            foreach (var buffer in processedText.VertexBuffers)
                buffer.Reset();
            SizeF size = PrintOrMeasure(processedText.VertexBuffers, processedText, false);
            foreach (var buffer in processedText.VertexBuffers)
                buffer.Load();
            return size;
        }

        public GLFontTextPosition GetTextPosition(GLFontText processedText, GLFontTextPosition position)
        {
            float maxMeasuredWidth = 0f;

            float xOffset = 0f;
            float yOffset = 0f;

            int character = 0;

            lineSpacingCache = LineSpacing;
            isMonospacingActiveCache = IsMonospacingActive;
            monoSpaceWidthCache = MonoSpaceWidth;
            float maxWidth = processedText.maxSize.Width;
            var alignment = processedText.alignment;
            var nodeList = processedText.textNodeList;
            for (GLFontTextNode node = nodeList.Head; node != null; node = node.Next)
                node.LengthTweak = 0f;  //reset tweaks

            if (alignment == GLFontAlignment.Right)
                xOffset -= (float)Math.Ceiling(TextNodeLineLength(nodeList.Head, maxWidth) - maxWidth);
            else if (alignment == GLFontAlignment.Centre)
                xOffset -= (float)Math.Ceiling(0.5f * TextNodeLineLength(nodeList.Head, maxWidth));
            else if (alignment == GLFontAlignment.Justify)
                JustifyLine(nodeList.Head, maxWidth);

            bool atLeastOneNodeCosumedOnLine = false;
            float length = 0f;
            for (GLFontTextNode node = nodeList.Head; node != null; node = node.Next)
            {
                bool newLine = false;

                if (node.Type == GLFontTextNodeType.LineBreak)
                {
                    newLine = true;
                    if (character == position.Index)
                        return new GLFontTextPosition() { Index = character, Position = new vec2(xOffset + length, yOffset) };
                    character++;
                }
                else
                {
                    if (Options.WordWrap && SkipTrailingSpace(node, length, maxWidth) && atLeastOneNodeCosumedOnLine)
                    {
                        newLine = true;
                        if (character == position.Index)
                            return new GLFontTextPosition() { Index = character, Position = new vec2(xOffset + length, yOffset) };
                        character++;
                    }
                    else if (length + node.ModifiedLength <= maxWidth || !atLeastOneNodeCosumedOnLine)
                    {
                        atLeastOneNodeCosumedOnLine = true;

                        vec2 p;
                        if (GetWordPosition(xOffset + length, yOffset, node, position, ref character, out p))
                            return new GLFontTextPosition() { Index = character, Position = p };

                        length += node.ModifiedLength;

                        maxMeasuredWidth = Math.Max(length, maxMeasuredWidth);
                    }
                    else if (Options.WordWrap)
                    {
                        newLine = true;
                        if (node.Previous != null)
                            node = node.Previous;
                    }
                    else
                        continue; // continue so we still read line breaks even if reached max width
                }

                if (newLine)
                {
                    if (yOffset + lineSpacingCache >= processedText.maxSize.Height)
                        break;

                    if ((long)(yOffset / lineSpacingCache) == (long)(position.Position.y / lineSpacingCache))
                        return new GLFontTextPosition() { Index = character - 1, Position = new vec2(xOffset + length, yOffset) };

                    yOffset += lineSpacingCache;
                    xOffset = 0f;
                    length = 0f;
                    atLeastOneNodeCosumedOnLine = false;

                    if (node.Next != null)
                    {
                        if (alignment == GLFontAlignment.Right)
                            xOffset -= (float)Math.Ceiling(TextNodeLineLength(node.Next, maxWidth) - maxWidth);
                        else if (alignment == GLFontAlignment.Centre)
                            xOffset -= (float)Math.Ceiling(0.5f * TextNodeLineLength(node.Next, maxWidth));
                        else if (alignment == GLFontAlignment.Justify)
                            JustifyLine(node.Next, maxWidth);
                    }
                }
            }

            return new GLFontTextPosition() { Index = character, Position = new vec2(xOffset + length, yOffset) };
        }

        private bool GetWordPosition(float x, float y, GLFontTextNode node, GLFontTextPosition position, ref int character, out vec2 p)
        {
            bool sameLine = (long)(y / lineSpacingCache) == (long)(position.Position.y / lineSpacingCache);

            if (node.Type == GLFontTextNodeType.Space || node.Type == GLFontTextNodeType.Tab)
            {
                p = new vec2(x, y);
                if (position.Index == character || (sameLine && x + node.ModifiedLength * 0.5f > position.Position.x))
                    return true;
                character++;
                return false;
            }

            int charGaps = node.Text.Length - 1;
            bool isCrumbleWord = CrumbledWord(node);
            if (isCrumbleWord)
                charGaps++;

            int pixelsPerGap = 0;
            int leftOverPixels = 0;

            if (charGaps != 0)
            {
                pixelsPerGap = (int)node.LengthTweak / charGaps;
                leftOverPixels = (int)node.LengthTweak - pixelsPerGap * charGaps;
            }

            for (int i = 0; i < node.Text.Length; i++)
            {
                char c = node.Text[i];
                if (fontData.CharSetMapping.ContainsKey(c))
                {
                    var glyph = fontData.CharSetMapping[c];

                    float oldX = x;

                    if (isMonospacingActiveCache)
                        x += monoSpaceWidthCache;
                    else
                        x += (int)Math.Ceiling(glyph.Rect.Width + fontData.meanGlyphWidth * Options.CharacterSpacing + fontData.GetKerningPairCorrection(i, node.Text, node));

                    x += pixelsPerGap;
                    if (leftOverPixels > 0)
                    {
                        x += 1.0f;
                        leftOverPixels--;
                    }
                    else if (leftOverPixels < 0)
                    {
                        x -= 1.0f;
                        leftOverPixels++;
                    }

                    if (position.Index == character || (sameLine && (oldX + x) * 0.5f > position.Position.x))
                    {
                        p = new vec2(oldX, y);
                        return true;
                    }
                }
                character++;
            }
            p = new vec2();
            return false;
        }

        private SizeF PrintOrMeasure(GLFontVertexBuffer[] vbos, GLFontText processedText, bool measureOnly)
        {
            // init values we'll return
            float maxMeasuredWidth = 0f;

            float xOffset = 0f;
            float yOffset = 0f;

            lineSpacingCache = LineSpacing;
            isMonospacingActiveCache = IsMonospacingActive;
            monoSpaceWidthCache = MonoSpaceWidth;
            float maxWidth = processedText.maxSize.Width;
            var alignment = processedText.alignment;
            var nodeList = processedText.textNodeList;
            for (GLFontTextNode node = nodeList.Head; node != null; node = node.Next)
                node.LengthTweak = 0f;  //reset tweaks

            if (alignment == GLFontAlignment.Right)
                xOffset -= (float)Math.Ceiling(TextNodeLineLength(nodeList.Head, maxWidth) - maxWidth);
            else if (alignment == GLFontAlignment.Centre)
                xOffset -= (float)Math.Ceiling(0.5f * TextNodeLineLength(nodeList.Head, maxWidth));
            else if (alignment == GLFontAlignment.Justify)
                JustifyLine(nodeList.Head, maxWidth);

            bool atLeastOneNodeCosumedOnLine = false;
            float length = 0f;
            for (GLFontTextNode node = nodeList.Head; node != null; node = node.Next)
            {
                bool newLine = false;

                if (node.Type == GLFontTextNodeType.LineBreak)
                {
                    newLine = true;
                }
                else
                {
                    if (Options.WordWrap && SkipTrailingSpace(node, length, maxWidth) && atLeastOneNodeCosumedOnLine)
                    {
                        newLine = true;
                    }
                    else if (length + node.ModifiedLength <= maxWidth || !atLeastOneNodeCosumedOnLine)
                    {
                        atLeastOneNodeCosumedOnLine = true;

                        if (!measureOnly)
                            RenderWord(vbos, xOffset + length, yOffset, node);
                        length += node.ModifiedLength;

                        maxMeasuredWidth = Math.Max(length, maxMeasuredWidth);
                    }
                    else if (Options.WordWrap)
                    {
                        newLine = true;
                        if (node.Previous != null)
                            node = node.Previous;
                    }
                    else
                        continue; // continue so we still read line breaks even if reached max width
                }

                if (newLine)
                {
                    if (yOffset + lineSpacingCache >= processedText.maxSize.Height)
                        break;

                    yOffset += lineSpacingCache;
                    xOffset = 0f;
                    length = 0f;
                    atLeastOneNodeCosumedOnLine = false;

                    if (node.Next != null)
                    {
                        if (alignment == GLFontAlignment.Right)
                            xOffset -= (float)Math.Ceiling(TextNodeLineLength(node.Next, maxWidth) - maxWidth);
                        else if (alignment == GLFontAlignment.Centre)
                            xOffset -= (float)Math.Ceiling(0.5f * TextNodeLineLength(node.Next, maxWidth));
                        else if (alignment == GLFontAlignment.Justify)
                            JustifyLine(node.Next, maxWidth);
                    }
                }
            }

            return new SizeF(maxMeasuredWidth, yOffset + (nodeList.Head == null ? 0 : lineSpacingCache));
        }

        private void RenderWord(GLFontVertexBuffer[] vbos, float x, float y, GLFontTextNode node)
        {
            if (node.Type != GLFontTextNodeType.Word)
                return;

            int charGaps = node.Text.Length - 1;
            bool isCrumbleWord = CrumbledWord(node);
            if (isCrumbleWord)
                charGaps++;

            int pixelsPerGap = 0;
            int leftOverPixels = 0;

            if (charGaps != 0)
            {
                pixelsPerGap = (int)node.LengthTweak / charGaps;
                leftOverPixels = (int)node.LengthTweak - pixelsPerGap * charGaps;
            }

            for (int i = 0; i < node.Text.Length; i++)
            {
                char c = node.Text[i];
                GLFontGlyph glyph;
                if (fontData.CharSetMapping.TryGetValue(c, out glyph))
                {
                    vbos[glyph.Page].AddQuad(x, y + glyph.YOffset, x + glyph.Rect.Width, y + glyph.YOffset + glyph.Rect.Height,
                        glyph.TextureMin.X, glyph.TextureMin.Y, glyph.TextureMax.X, glyph.TextureMax.Y);

                    if (isMonospacingActiveCache)
                        x += monoSpaceWidthCache;
                    else
                        x += (int)Math.Ceiling(glyph.Rect.Width + fontData.meanGlyphWidth * Options.CharacterSpacing + fontData.GetKerningPairCorrection(i, node.Text, node));

                    x += pixelsPerGap;
                    if (leftOverPixels > 0)
                    {
                        x += 1.0f;
                        leftOverPixels--;
                    }
                    else if (leftOverPixels < 0)
                    {
                        x -= 1.0f;
                        leftOverPixels++;
                    }
                }
            }
        }

        private float TextNodeLineLength(GLFontTextNode node, float maxLength)
        {
            if (node == null)
                return 0;

            bool atLeastOneNodeCosumedOnLine = false;
            float length = 0;
            for (; node != null; node = node.Next)
            {
                if (node.Type == GLFontTextNodeType.LineBreak)
                    break;
                if (SkipTrailingSpace(node, length, maxLength) && atLeastOneNodeCosumedOnLine)
                    break;
                if (length + node.Length <= maxLength || !atLeastOneNodeCosumedOnLine)
                {
                    atLeastOneNodeCosumedOnLine = true;
                    length += node.Length;
                }
                else
                    break;
            }
            return length;
        }

        private bool CrumbledWord(GLFontTextNode node)
        {
            return (node.Type == GLFontTextNodeType.Word && node.Next != null && node.Next.Type == GLFontTextNodeType.Word);
        }

        private void JustifyLine(GLFontTextNode node, float targetLength)
        {
            bool justifiable = false;

            if (node == null)
                return;

            var headNode = node; //keep track of the head node

            //start by finding the length of the block of text that we know will actually fit:

            int charGaps = 0;
            int spaceGaps = 0;

            bool atLeastOneNodeCosumedOnLine = false;
            float length = 0;
            var expandEndNode = node; //the node at the end of the smaller list (before adding additional word)
            for (; node != null; node = node.Next)
            {
                if (node.Type == GLFontTextNodeType.LineBreak)
                    break;

                if (SkipTrailingSpace(node, length, targetLength) && atLeastOneNodeCosumedOnLine)
                {
                    justifiable = true;
                    break;
                }

                if (length + node.Length < targetLength || !atLeastOneNodeCosumedOnLine)
                {
                    expandEndNode = node;

                    if (node.Type == GLFontTextNodeType.Space)
                        spaceGaps++;
                    if (node.Type == GLFontTextNodeType.Tab)
                        spaceGaps += 4;

                    if (node.Type == GLFontTextNodeType.Word)
                    {
                        charGaps += (node.Text.Length - 1);

                        //word was part of a crumbled word, so there's an extra char cap between the two words
                        if (CrumbledWord(node))
                            charGaps++;
                    }

                    atLeastOneNodeCosumedOnLine = true;
                    length += node.Length;
                }
                else
                {
                    justifiable = true;
                    break;
                }
            }

            //now we check how much additional length is added by adding an additional word to the line
            float extraLength = 0f;
            int extraSpaceGaps = 0;
            int extraCharGaps = 0;
            bool contractPossible = false;
            GLFontTextNode contractEndNode = null;
            for (node = expandEndNode.Next; node != null; node = node.Next)
            {
                if (node.Type == GLFontTextNodeType.LineBreak)
                    break;

                if (node.Type == GLFontTextNodeType.Space)
                {
                    extraLength += node.Length;
                    extraSpaceGaps++;
                }
                else if (node.Type == GLFontTextNodeType.Tab)
                {
                    extraLength += node.Length;
                    extraSpaceGaps += 4;
                }
                else if (node.Type == GLFontTextNodeType.Word)
                {
                    contractEndNode = node;
                    contractPossible = true;
                    extraLength += node.Length;
                    extraCharGaps += (node.Text.Length - 1);
                    break;
                }
            }

            if (justifiable)
            {
                //last part of this condition is to ensure that the full contraction is possible (it is all or nothing with contractions, since it looks really bad if we don't manage the full)
                bool contract = contractPossible && (extraLength + length - targetLength) * Options.JustifyContractionPenalty < (targetLength - length) &&
                    ((targetLength - (length + extraLength + 1)) / targetLength > -Options.JustifyCapContract);

                if ((!contract && length < targetLength) || (contract && length + extraLength > targetLength))  //calculate padding pixels per word and char
                {
                    if (contract)
                    {
                        length += extraLength + 1;
                        charGaps += extraCharGaps;
                        spaceGaps += extraSpaceGaps;
                    }

                    int totalPixels = (int)(targetLength - length); //the total number of pixels that need to be added to line to justify it
                    int spacePixels = 0; //number of pixels to spread out amongst spaces
                    int charPixels = 0; //number of pixels to spread out amongst char gaps

                    if (contract)
                    {
                        if (totalPixels / targetLength < -Options.JustifyCapContract)
                            totalPixels = (int)(-Options.JustifyCapContract * targetLength);
                    }
                    else
                    {
                        if (totalPixels / targetLength > Options.JustifyCapExpand)
                            totalPixels = (int)(Options.JustifyCapExpand * targetLength);
                    }

                    //work out how to spread pixles between character gaps and word spaces
                    if (charGaps == 0)
                    {
                        spacePixels = totalPixels;
                    }
                    else if (spaceGaps == 0)
                    {
                        charPixels = totalPixels;
                    }
                    else
                    {
                        if (contract)
                            charPixels = (int)(totalPixels * Options.JustifyCharacterWeightForContract * charGaps / spaceGaps);
                        else
                            charPixels = (int)(totalPixels * Options.JustifyCharacterWeightForExpand * charGaps / spaceGaps);

                        if ((!contract && charPixels > totalPixels) ||
                            (contract && charPixels < totalPixels))
                            charPixels = totalPixels;

                        spacePixels = totalPixels - charPixels;
                    }

                    int pixelsPerChar = 0;  //minimum number of pixels to add per char
                    int leftOverCharPixels = 0; //number of pixels remaining to only add for some chars

                    if (charGaps != 0)
                    {
                        pixelsPerChar = charPixels / charGaps;
                        leftOverCharPixels = charPixels - pixelsPerChar * charGaps;
                    }

                    int pixelsPerSpace = 0; //minimum number of pixels to add per space
                    int leftOverSpacePixels = 0; //number of pixels remaining to only add for some spaces

                    if (spaceGaps != 0)
                    {
                        pixelsPerSpace = spacePixels / spaceGaps;
                        leftOverSpacePixels = spacePixels - pixelsPerSpace * spaceGaps;
                    }

                    //now actually iterate over all nodes and set tweaked length
                    for (node = headNode; node != null; node = node.Next)
                    {
                        if (node.Type == GLFontTextNodeType.Space)
                        {
                            node.LengthTweak = pixelsPerSpace;
                            if (leftOverSpacePixels > 0)
                            {
                                node.LengthTweak += 1;
                                leftOverSpacePixels--;
                            }
                            else if (leftOverSpacePixels < 0)
                            {
                                node.LengthTweak -= 1;
                                leftOverSpacePixels++;
                            }
                        }
                        else if (node.Type == GLFontTextNodeType.Tab)
                        {
                            node.LengthTweak = 4 * pixelsPerSpace;
                            if (leftOverSpacePixels > 0)
                            {
                                node.LengthTweak += 1;
                                leftOverSpacePixels--;
                            }
                            else if (leftOverSpacePixels < 0)
                            {
                                node.LengthTweak -= 1;
                                leftOverSpacePixels++;
                            }
                        }
                        else if (node.Type == GLFontTextNodeType.Word)
                        {
                            int cGaps = (node.Text.Length - 1);
                            if (CrumbledWord(node))
                                cGaps++;

                            node.LengthTweak = cGaps * pixelsPerChar;

                            if (leftOverCharPixels >= cGaps)
                            {
                                node.LengthTweak += cGaps;
                                leftOverCharPixels -= cGaps;
                            }
                            else if (leftOverCharPixels <= -cGaps)
                            {
                                node.LengthTweak -= cGaps;
                                leftOverCharPixels += cGaps;
                            }
                            else
                            {
                                node.LengthTweak += leftOverCharPixels;
                                leftOverCharPixels = 0;
                            }
                        }

                        if ((!contract && node == expandEndNode) || (contract && node == contractEndNode))
                            break;
                    }
                }
            }
        }

        private bool SkipTrailingSpace(GLFontTextNode node, float lengthSoFar, float boundWidth)
        {
            if ((node.Type == GLFontTextNodeType.Space || node.Type == GLFontTextNodeType.Tab) &&
                node.Next != null &&
                node.Next.Type == GLFontTextNodeType.Word &&
                node.ModifiedLength + node.Next.ModifiedLength + lengthSoFar > boundWidth)
                return true;
            return false;
        }
    }
}
