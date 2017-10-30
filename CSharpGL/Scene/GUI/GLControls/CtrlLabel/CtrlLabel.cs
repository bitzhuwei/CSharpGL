using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a label(string) as GUI.
    /// </summary>
    public partial class CtrlLabel : GLControl
    {
        private string text = string.Empty;
        private CtrlLabelModel labelModel;
        private VertexBuffer positionBuffer;
        private VertexBuffer uvBuffer;
        private VertexBuffer textureIndexBuffer;
        private ZeroIndexBuffer indexBuffer;

        /// <summary>
        /// 
        /// </summary>
        public unsafe string Text
        {
            get { return text; }
            set
            {
                string v = value == null ? string.Empty : value;
                if (v != text)
                {
                    text = v;
                    ArrangeCharaters(v, GlyphServer.defaultServer);
                }
            }
        }

        unsafe private void ArrangeCharaters(string text, GlyphServer server)
        {
            var positionArray = (QuadStruct*)this.positionBuffer.MapBuffer(MapBufferAccess.ReadWrite);
            var uvArray = (QuadStruct*)this.uvBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            var textureIndexArray = (float*)this.textureIndexBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            float totalWidth, totalHeight;
            FirstPass(text, server, positionArray, uvArray, textureIndexArray, this.indexBuffer, out totalWidth, out totalHeight);
            SecondPass(positionArray, totalWidth, totalHeight, indexBuffer.RenderingVertexCount / 4);
            this.textureIndexBuffer.UnmapBuffer();
            this.uvBuffer.UnmapBuffer();
            this.positionBuffer.UnmapBuffer();

            this.Size = new GUISize(
                (int)(totalWidth * this.Size.Height / totalHeight), // auto size means auto width.
                this.Size.Height);
        }

        /// <summary>
        /// move characters to center position.
        /// </summary>
        /// <param name="positionArray"></param>
        /// <param name="totalWidth"></param>
        /// <param name="totalHeight"></param>
        /// <param name="quadCount"></param>
        private unsafe void SecondPass(QuadStruct* positionArray, float totalWidth, float totalHeight, int quadCount)
        {
            float halfWidth = totalWidth / 2;
            for (int i = 0; i < quadCount; i++)
            {
                QuadStruct position = positionArray[i];
                var newPos = new QuadStruct(
                    // y are already in [-1, 1], so just shrink x to [-1, 1]
                    new vec2((position.leftTop.x - halfWidth) / totalWidth, position.leftTop.y),
                    new vec2((position.leftBottom.x - halfWidth) / totalWidth, position.leftBottom.y),
                    new vec2((position.rightBottom.x - halfWidth) / totalWidth, position.rightBottom.y),
                    new vec2((position.rightTop.x - halfWidth) / totalWidth, position.rightTop.y)
                    );

                positionArray[i] = newPos;
            }
        }

        /// <summary>
        /// start from (0, 0) to the right.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="server"></param>
        /// <param name="positionArray"></param>
        /// <param name="uvArray"></param>
        /// <param name="textureIndexArray"></param>
        /// <param name="indexBuffer"></param>
        /// <param name="totalWidth"></param>
        /// <param name="totalHeight"></param>
        unsafe private static void FirstPass(string text, GlyphServer server,
            QuadStruct* positionArray, QuadStruct* uvArray, float* textureIndexArray,
            ZeroIndexBuffer indexBuffer,
            out float totalWidth, out float totalHeight)
        {
            const float height = 1.0f; // let's say height is 1.0f.
            totalWidth = 0;
            totalHeight = height;
            int index = 0;
            foreach (var c in text)
            {
                GlyphInfo glyphInfo;
                float wByH = 0;
                if (server.GetGlyphInfo(c, out glyphInfo))
                {
                    float w = glyphInfo.rightBottom.x - glyphInfo.leftBottom.x;
                    float h = glyphInfo.rightBottom.y - glyphInfo.rightTop.y;
                    wByH = height * w / h;
                }
                else
                {
                    // put an empty glyph(square) here.
                    wByH = height * 1.0f / 1.0f;
                }

                var leftTop = new vec2(totalWidth, 0.5f);
                var leftBottom = new vec2(totalWidth, -0.5f);
                var rightBottom = new vec2(totalWidth + wByH, -0.5f);
                var rightTop = new vec2(totalWidth + wByH, 0.5f);
                positionArray[index] = new QuadStruct(leftTop, leftBottom, rightBottom, rightTop);
                uvArray[index] = new QuadStruct(glyphInfo.leftTop, glyphInfo.leftBottom, glyphInfo.rightBottom, glyphInfo.rightTop);
                textureIndexArray[index] = glyphInfo.textureIndex;
                totalWidth += wByH;
                index++;
            }

            indexBuffer.RenderingVertexCount = index * 4;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public CtrlLabel(int capacity)
            : this(capacity, GUIAnchorStyles.Left | GUIAnchorStyles.Top, new GUIPadding(3, 3, 3, 3))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        public CtrlLabel(int capacity, GUIAnchorStyles anchor, GUIPadding margin)
            : base(anchor, margin)
        {
            if (capacity < 0) { throw new ArgumentException("capacity"); }

            this.Size = new GUISize(20, 20);

            var model = new CtrlLabelModel(capacity);
            this.labelModel = model;
            var vs = new VertexShader(vert, inPosition, inUV, inTextureIndex);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlLabelModel.position);
            map.Add(inUV, CtrlLabelModel.uv);
            map.Add(inTextureIndex, CtrlLabelModel.textureIndex);
            var methodBuilder = new RenderMethodBuilder(codes, map);
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);

            this.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public ModernRenderUnit RenderUnit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            this.RenderUnit.Initialize();

            this.positionBuffer = this.labelModel.GetVertexAttributeBuffer(CtrlLabelModel.position);
            this.uvBuffer = this.labelModel.GetVertexAttributeBuffer(CtrlLabelModel.uv);
            this.textureIndexBuffer = this.labelModel.GetVertexAttributeBuffer(CtrlLabelModel.textureIndex);
            this.indexBuffer = this.labelModel.GetIndexBuffer() as ZeroIndexBuffer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIBeforeChildren(GUIRenderEventArgs arg)
        {
            this.UpdateScissorViewport();

            viewportState.On();
            scissorState.On();

            GL.Instance.ClearColor(1, 0, 0, 0.5f);
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);

            this.RenderUnit.Methods[0].Render(IndexBuffer.ControlMode.Random);

            viewportState.Off();
            scissorState.Off();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIAfterChildren(GUIRenderEventArgs arg)
        {
        }
    }
}
