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
    class DummyTextBoxRenderer : Renderer, IUILayout
    {

        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static DummyTextBoxRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"Form09TextBoxRenderer\TexBox.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"Form09TextBoxRenderer\TexBox.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
        }

        public DummyTextBoxRenderer(
            System.Windows.Forms.AnchorStyles Anchor,
            System.Windows.Forms.Padding Margin,
            System.Drawing.Size Size,
            int zNear = -1000,
            int zFar = 1000,
            int particleCount = 1000)
            : base(new BillboardModel(particleCount), staticShaderCodes, map)
        {
            this.Anchor = Anchor;
            this.Margin = Margin;
            this.Size = Size;
            this.zNear = zNear;
            this.zFar = zFar;
        }


        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniformValue("fontTexture",
                new samplerValue(FontResource.Default.FontTextureId, GL.GL_TEXTURE0));
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection, view, model;
            this.GetMatrix(out projection, out view, out model);
            this.SetUniformValue("mvp", projection * view * model);

            base.DoRender(arg);
        }

        class BillboardModel : IBufferable
        {

            public BillboardModel(int charCount)
            {
                this.charCount = charCount;
            }
            public const string strPosition = "position";
            private PropertyBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int charCount;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec3>(
                            varNameInShader, 2, GL.GL_FLOAT, BufferUsage.DynamicDraw))
                        {
                            buffer.Alloc(charCount * 4);

                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return positionBufferPtr;
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
                      DrawMode.Quads, 0, charCount * 4))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }

                return indexBufferPtr;
            }
        }


        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }
    }
}