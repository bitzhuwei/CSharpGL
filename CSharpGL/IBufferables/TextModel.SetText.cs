using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class TextModel
    {

        private string content = string.Empty;

        public string Text { get { return content; } }

        public unsafe void SetText(string content, FontResource fontResource)
        {
            if (string.IsNullOrEmpty(content))
            {
                if (this.indexBufferPtr != null)
                { this.indexBufferPtr.VertexCount = 0; }
                this.content = string.Empty;
                return;
            }

            this.content = content;

            int count = content.Length;
            if (count > this.maxCharCount)
            { throw new ArgumentException(); }
            //{ count = this.maxCharCount; }

            SetupGlyphPositions(content, fontResource);
            SetupGlyphTexCoord(content, fontResource);
            this.indexBufferPtr.VertexCount = count * 4;
        }

        unsafe private void SetupGlyphTexCoord(string content, FontResource fontResource)
        {
            FullDictionary<char, GlyphInfo> charInfoDict = fontResource.CharInfoDict;
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.uvBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.WriteOnly);
            var array = (TextModel.GlyphTexCoord*)pointer.ToPointer();
            int width = fontResource.TextureSize.Width;
            int height = fontResource.TextureSize.Height;
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
                GlyphInfo info = fontResource.CharInfoDict[ch];
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
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        unsafe private void SetupGlyphPositions(string content, FontResource fontResource)
        {
            FullDictionary<char, GlyphInfo> charInfoDict = fontResource.CharInfoDict;
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            var array = (TextModel.GlyphPosition*)pointer.ToPointer();
            int currentWidth = 0; int currentHeight = 0;
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
                    new vec2(currentWidth, currentHeight + fontResource.FontHeight),
                    new vec2(currentWidth, currentHeight),
                    new vec2(currentWidth + info.width, currentHeight),
                    new vec2(currentWidth + info.width, currentHeight + fontResource.FontHeight));
                currentWidth += info.width + fontResource.FontHeight / 10;
            }
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
                position.leftUp.y -= (currentHeight + fontResource.FontHeight) / 2.0f;
                position.leftDown.y -= (currentHeight + fontResource.FontHeight) / 2.0f;
                position.rightUp.y -= (currentHeight + fontResource.FontHeight) / 2.0f;
                position.rightDown.y -= (currentHeight + fontResource.FontHeight) / 2.0f;

                position.leftUp.x /= (currentHeight + fontResource.FontHeight);
                position.leftDown.x /= (currentHeight + fontResource.FontHeight);
                position.rightUp.x /= (currentHeight + fontResource.FontHeight);
                position.rightDown.x /= (currentHeight + fontResource.FontHeight);
                position.leftUp.y /= (currentHeight + fontResource.FontHeight);
                position.leftDown.y /= (currentHeight + fontResource.FontHeight);
                position.rightUp.y /= (currentHeight + fontResource.FontHeight);
                position.rightDown.y /= (currentHeight + fontResource.FontHeight);
                array[i] = position;
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

    }
}
