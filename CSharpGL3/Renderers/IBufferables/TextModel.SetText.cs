using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class TextModel
    {
        private string content = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string Text { get { return content; } }

        /// <summary>
        /// Text's alignment.
        /// </summary>
        public TextAlignment Alignment { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fontTextureService"></param>
        public unsafe void SetText(string content, IFontTexture fontTextureService)
        {
            if (string.IsNullOrEmpty(content))
            {
                if (this.indexBuffer != null)
                { this.indexBuffer.RenderingVertexCount = 0; }
                this.content = string.Empty;
                return;
            }

            this.content = content;

            int count = content.Length;
            if (count > this.maxCharCount)
            { throw new ArgumentException(); }
            //{ count = this.maxCharCount; }

            SetupGlyphPositions(content, fontTextureService);
            SetupGlyphTexCoord(content, fontTextureService);
            this.indexBuffer.RenderingVertexCount = count * 4;
        }

        unsafe private void SetupGlyphTexCoord(string content, IFontTexture fontTexture)
        {
            FullDictionary<char, GlyphInfo> charInfoDict = fontTexture.GlyphInfoDictionary;
            IntPtr pointer = this.uvBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            var array = (TextModel.GlyphTexCoord*)pointer.ToPointer();
            int width = fontTexture.TextureSize.Width;
            int height = fontTexture.TextureSize.Height;
            /*
             * 0     3  4     6 8     11 12   15
             * -------  ------- -------  -------
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * -------  ------- -------  -------
             * 1     2  5     6 9     10 13   14
             */
            for (int i = 0; i < content.Length; i++)
            {
                char ch = content[i];
                GlyphInfo info = fontTexture.GlyphInfoDictionary[ch];
                const int shrimp = 0;
                array[i] = new TextModel.GlyphTexCoord(
                    //new vec2(0, 0),
                    //new vec2(0, 1),
                    //new vec2(1, 1),
                    //new vec2(1, 0)
                    new vec2((float)(info.xoffset + shrimp) / (float)width, (float)(info.yoffset) / (float)height),
                    new vec2((float)(info.xoffset + shrimp) / (float)width, (float)(info.yoffset + info.height) / (float)height),
                    new vec2((float)(info.xoffset - shrimp + info.width) / (float)width, (float)(info.yoffset + info.height) / (float)height),
                    new vec2((float)(info.xoffset - shrimp + info.width) / (float)width, (float)(info.yoffset) / (float)height)
                    );
            }
            this.uvBuffer.UnmapBuffer();
        }

        unsafe private void SetupGlyphPositions(string content, IFontTexture fontTexture)
        {
            FullDictionary<char, GlyphInfo> charInfoDict = fontTexture.GlyphInfoDictionary;
            IntPtr pointer = this.positionBuffer.MapBuffer(MapBufferAccess.ReadWrite);
            var array = (TextModel.GlyphPosition*)pointer.ToPointer();
            float currentWidth = 0; int currentHeight = 0;
            /*
             * 0     3  4     7 8     11 12   15
             * -------  ------- -------  -------
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * -------  ------- -------  -------
             * 1     2  5     6 9     10 13   14
             */
            for (int i = 0; i < content.Length; i++)
            {
                char ch = content[i];
                GlyphInfo info = charInfoDict[ch];
                array[i] = new TextModel.GlyphPosition(
                    new vec2(currentWidth, currentHeight + fontTexture.GlyphHeight),
                    new vec2(currentWidth, currentHeight),
                    new vec2(currentWidth + info.width, currentHeight),
                    new vec2(currentWidth + info.width, currentHeight + fontTexture.GlyphHeight));
                currentWidth += info.width + fontTexture.GlyphHeight / 10;
            }

            switch (this.Alignment)
            {
                case TextAlignment.Center:
                    Move2Center(content, array, currentWidth, currentHeight, fontTexture);
                    break;
                case TextAlignment.Left:
                    Move2Left(content, array, currentWidth, currentHeight, fontTexture);
                    break;
                case TextAlignment.Right:
                    Move2Right(content, array, currentWidth, currentHeight, fontTexture);
                    break;
                default:
                    break;
            }

            this.positionBuffer.UnmapBuffer();
        }

        private unsafe void Move2Right(string content, GlyphPosition* array, float currentWidth, int currentHeight, IFontTexture fontTexture)
        {
            // move to right
            for (int i = 0; i < content.Length; i++)
            {
                TextModel.GlyphPosition position = array[i];

                position.leftUp.x -= currentWidth;
                //position.leftUp.x /= currentWidth / factor;
                position.leftDown.x -= currentWidth;
                //position.leftDown.x /= currentWidth / factor;
                position.rightUp.x -= currentWidth;
                //position.rightUp.x /= currentWidth / factor;
                position.rightDown.x -= currentWidth;
                //position.rightDown.x /= currentWidth / factor;
                position.leftUp.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.leftDown.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.rightUp.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.rightDown.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;

                position.leftUp.x /= (currentHeight + fontTexture.GlyphHeight);
                position.leftDown.x /= (currentHeight + fontTexture.GlyphHeight);
                position.rightUp.x /= (currentHeight + fontTexture.GlyphHeight);
                position.rightDown.x /= (currentHeight + fontTexture.GlyphHeight);
                position.leftUp.y /= (currentHeight + fontTexture.GlyphHeight);
                position.leftDown.y /= (currentHeight + fontTexture.GlyphHeight);
                position.rightUp.y /= (currentHeight + fontTexture.GlyphHeight);
                position.rightDown.y /= (currentHeight + fontTexture.GlyphHeight);
                array[i] = position;
            }
        }

        private unsafe void Move2Left(string content, GlyphPosition* array, float currentWidth, int currentHeight, IFontTexture fontTexture)
        {
            // move to left
            for (int i = 0; i < content.Length; i++)
            {
                TextModel.GlyphPosition position = array[i];

                position.leftUp.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.leftDown.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.rightUp.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.rightDown.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;

                position.leftUp.x /= (currentHeight + fontTexture.GlyphHeight);
                position.leftDown.x /= (currentHeight + fontTexture.GlyphHeight);
                position.rightUp.x /= (currentHeight + fontTexture.GlyphHeight);
                position.rightDown.x /= (currentHeight + fontTexture.GlyphHeight);
                position.leftUp.y /= (currentHeight + fontTexture.GlyphHeight);
                position.leftDown.y /= (currentHeight + fontTexture.GlyphHeight);
                position.rightUp.y /= (currentHeight + fontTexture.GlyphHeight);
                position.rightDown.y /= (currentHeight + fontTexture.GlyphHeight);
                array[i] = position;
            }
        }

        private unsafe void Move2Center(string content, GlyphPosition* array, float currentWidth, float currentHeight, IFontTexture fontTexture)
        {
            // move to center
            for (int i = 0; i < content.Length; i++)
            {
                TextModel.GlyphPosition position = array[i];

                position.leftUp.x -= currentWidth / 2.0f;
                //position.leftUp.x /= currentWidth / factor;
                position.leftDown.x -= currentWidth / 2.0f;
                //position.leftDown.x /= currentWidth / factor;
                position.rightUp.x -= currentWidth / 2.0f;
                //position.rightUp.x /= currentWidth / factor;
                position.rightDown.x -= currentWidth / 2.0f;
                //position.rightDown.x /= currentWidth / factor;
                position.leftUp.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.leftDown.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.rightUp.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;
                position.rightDown.y -= (currentHeight + fontTexture.GlyphHeight) / 2.0f;

                position.leftUp.x /= (currentHeight + fontTexture.GlyphHeight);
                position.leftDown.x /= (currentHeight + fontTexture.GlyphHeight);
                position.rightUp.x /= (currentHeight + fontTexture.GlyphHeight);
                position.rightDown.x /= (currentHeight + fontTexture.GlyphHeight);
                position.leftUp.y /= (currentHeight + fontTexture.GlyphHeight);
                position.leftDown.y /= (currentHeight + fontTexture.GlyphHeight);
                position.rightUp.y /= (currentHeight + fontTexture.GlyphHeight);
                position.rightDown.y /= (currentHeight + fontTexture.GlyphHeight);
                array[i] = position;
            }
        }
    }

    /// <summary>
    /// text's alignment.
    /// </summary>
    public enum TextAlignment
    {

        /// <summary>
        /// 
        /// </summary>
        Center,

        /// <summary>
        /// 
        /// </summary>
        Left,

        /// <summary>
        /// 
        /// </summary>
        Right,

    }

}