using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// </summary>
    class DummyTextBoxRenderer : Renderer, IDummyUILayout
    {

        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        private TextBoxModel model;
        static DummyTextBoxRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"Form09DummyTextBoxRenderer\TexBox.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"Form09DummyTextBoxRenderer\TexBox.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
            map.Add("uv", "uv");
        }

        public DummyTextBoxRenderer(
            System.Windows.Forms.AnchorStyles Anchor,
            System.Windows.Forms.Padding Margin,
            System.Drawing.Size Size,
            int zNear = -1000,
            int zFar = 1000,
            int macCharCount = 100)
            : base(new TextBoxModel(macCharCount), staticShaderCodes, map)
        {
            this.Anchor = Anchor;
            this.Margin = Margin;
            this.Size = Size;
            this.zNear = zNear;
            this.zFar = zFar;

            this.model = this.bufferable as TextBoxModel;
        }


        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("fontTexture",
                new samplerValue(
                    BindTextureTarget.Texture2D, 
                    FontResource.Default.FontTextureId, 
                    OpenGL.GL_TEXTURE0));
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            //mat4 projection, view, model;
            //this.GetMatrix(out projection, out view, out model);
            //this.SetUniformValue("mvp", projection * view * model);

            base.DoRender(arg);
        }

        public unsafe void SetText(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                this.model.indexBufferPtr.VertexCount = 0;
                return;
            }

            int count = content.Length;
            if (count > this.model.maxCharCount)
            { count = this.model.maxCharCount; }

            FontResource fontResource = FontResource.Default;
            SetupGlyphPositions(content, fontResource);
            SetupGlyphTexCoord(content, fontResource);
            this.model.indexBufferPtr.VertexCount = count * 4;
        }


        unsafe private void SetupGlyphTexCoord(string content, FontResource fontResource)
        {
            FullDictionary<char, CharacterInfo> charInfoDict = fontResource.CharInfoDict;
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.model.uvBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.WriteOnly);
            var array = (GlyphTexCoord*)pointer.ToPointer();
            int currentWidth = 0; int currentHeight = 0;
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
                const int shrimp = 2;
                array[i] = new GlyphTexCoord(
                    //new vec2(0, 0),
                    //new vec2(0, 1),
                    //new vec2(1, 1),
                    //new vec2(1, 0)
                    new vec2((float)(info.xoffset + shrimp) / (float)width, (float)(currentHeight) / (float)height),
                    new vec2((float)(info.xoffset + shrimp) / (float)width, (float)(currentHeight + fontResource.FontHeight) / (float)height),
                    new vec2((float)(info.xoffset - shrimp + info.width) / (float)width, (float)(currentHeight + fontResource.FontHeight) / (float)height),
                    new vec2((float)(info.xoffset - shrimp + info.width) / (float)width, (float)(currentHeight) / (float)height)
                    );
                currentWidth += info.width + 10;
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        unsafe private void SetupGlyphPositions(string content, FontResource fontResource)
        {
            FullDictionary<char, CharacterInfo> charInfoDict = fontResource.CharInfoDict;
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.model.positionBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            var array = (GlyphPosition*)pointer.ToPointer();
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
                CharacterInfo info = charInfoDict[ch];
                array[i] = new GlyphPosition(
                    new vec2(currentWidth, currentHeight + fontResource.FontHeight),
                    new vec2(currentWidth, currentHeight),
                    new vec2(currentWidth + info.width, currentHeight),
                    new vec2(currentWidth + info.width, currentHeight + fontResource.FontHeight));
                currentWidth += info.width + 10;
            }
            // move to center
            for (int i = 0; i < content.Length; i++)
            {
                GlyphPosition position = array[i];

                const int factor = 1;
                position.leftUp.x -= currentWidth / 2;
                //position.leftUp.x /= currentWidth / factor;
                position.leftDown.x -= currentWidth / 2;
                //position.leftDown.x /= currentWidth / factor;
                position.rightUp.x -= currentWidth / 2;
                //position.rightUp.x /= currentWidth / factor;
                position.rightDown.x -= currentWidth / 2;
                //position.rightDown.x /= currentWidth / factor;
                position.leftUp.y -= (currentHeight + fontResource.FontHeight) / 2;
                position.leftDown.y -= (currentHeight + fontResource.FontHeight) / 2;
                position.rightUp.y -= (currentHeight + fontResource.FontHeight) / 2;
                position.rightDown.y -= (currentHeight + fontResource.FontHeight) / 2;

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

        class TextBoxModel : IBufferable
        {

            public TextBoxModel(int maxCharCount)
            {
                this.maxCharCount = maxCharCount;
            }
            public const string strPosition = "position";
            public const string strUV = "uv";
            public PropertyBufferPtr positionBufferPtr;
            public PropertyBufferPtr uvBufferPtr;
            public ZeroIndexBufferPtr indexBufferPtr;
            public int maxCharCount;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PositionBuffer(varNameInShader))
                        {
                            buffer.Alloc(maxCharCount);

                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return positionBufferPtr;
                }
                else if (bufferName == strUV)
                {
                    if (uvBufferPtr == null)
                    {
                        using (var buffer = new UVBuffer(varNameInShader))
                        {
                            buffer.Alloc(maxCharCount);

                            uvBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return uvBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(
                      DrawMode.Quads, 0, maxCharCount * 4))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as ZeroIndexBufferPtr;
                    }
                }

                return indexBufferPtr;
            }
        }


        public struct GlyphPosition
        {
            public vec2 leftUp;
            public vec2 leftDown;
            public vec2 rightUp;
            public vec2 rightDown;

            public GlyphPosition(
                vec2 leftUp,
                vec2 leftDown,
                vec2 rightUp,
                vec2 rightDown)
            {
                this.leftUp = leftUp;
                this.leftDown = leftDown;
                this.rightUp = rightUp;
                this.rightDown = rightDown;
            }
        }

        public struct GlyphTexCoord
        {
            public vec2 leftUp;
            public vec2 leftDown;
            public vec2 rightUp;
            public vec2 rightDown;

            public GlyphTexCoord(
                vec2 leftUp,
                vec2 leftDown,
                vec2 rightUp,
                vec2 rightDown)
            {
                this.leftUp = leftUp;
                this.leftDown = leftDown;
                this.rightUp = rightUp;
                this.rightDown = rightDown;
            }
        }

        class PositionBuffer : PropertyBuffer<GlyphPosition>
        {
            public PositionBuffer(string varNameInShader)
                : base(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw)
            { }
        }

        class UVBuffer : PropertyBuffer<GlyphTexCoord>
        {
            public UVBuffer(string varNameInShader)
                : base(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw)
            { }
        }

        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }
    }
}