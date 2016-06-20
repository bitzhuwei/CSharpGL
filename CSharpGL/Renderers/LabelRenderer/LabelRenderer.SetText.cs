using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class LabelRenderer
    {

        private string content = string.Empty;

        public string Text { get { return content; } set { this.SetText(value); } }
        private unsafe void SetText(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                if (this.model != null && this.model.indexBufferPtr != null)
                { this.model.indexBufferPtr.VertexCount = 0; }
                this.content = string.Empty;
                return;
            }

            this.content = content;

            int count = content.Length;
            if (count > this.model.maxCharCount)
            { throw new ArgumentException(); }
            //{ count = this.model.maxCharCount; }

            FontResource fontResource = this.fontResource;
            SetupGlyphPositions(content, fontResource);
            SetupGlyphTexCoord(content, fontResource);
            this.model.indexBufferPtr.VertexCount = count * 4;
        }


        unsafe private void SetupGlyphTexCoord(string content, FontResource fontResource)
        {
            FullDictionary<char, CharacterInfo> charInfoDict = fontResource.CharInfoDict;
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.model.uvBufferPtr.BufferId);
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
                CharacterInfo info = fontResource.CharInfoDict[ch];
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

        private unsafe void SetupGlyphPositions(string content, FontResource fontResource)
        {
            FullDictionary<char, CharacterInfo> charInfoDict = fontResource.CharInfoDict;
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.model.positionBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            var array = (TextModel.GlyphPosition*)pointer.ToPointer();
            float currentWidth = 0; float currentHeight = 0;
            /*
             * 0     3  4     7 8     11 12   15
             * -------  ------- -------  -------
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * -------  ------- -------  -------
             * 1     2  5     6 9     10 13   14 
             */
            float ratio = (float)this.LabelHeight / (float)fontResource.FontHeight;
            for (int i = 0; i < content.Length; i++)
            {
                char ch = content[i];
                CharacterInfo info = charInfoDict[ch];
                array[i] = new TextModel.GlyphPosition(
                    new vec2(currentWidth, currentHeight + fontResource.FontHeight) * ratio,
                    new vec2(currentWidth, currentHeight) * ratio,
                    new vec2(currentWidth + info.width, currentHeight) * ratio,
                    new vec2(currentWidth + info.width, currentHeight + fontResource.FontHeight) * ratio);
                currentWidth += (info.width + fontResource.FontHeight / 10) * ratio;
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
