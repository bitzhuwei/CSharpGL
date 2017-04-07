using CSharpGL;
using System;
using System.IO;

namespace GridViewer
{
    /// <summary>
    ///  /|\ y
    ///   |
    ///   |
    ///   |
    ///   ---------------&gt; x
    /// (0, 0)
    /// 0    2    4    6    8    10
    /// --------------------------
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// --------------------------
    /// 1    3    5    7    9    11
    /// side length is 1.
    /// </summary>
    internal class QuadStripColoredRenderer : Renderer
    {
        private PolygonModeState polygonModeState = new PolygonModeState(PolygonMode.Line);
        private LineWidthState lineWidthState = new LineWidthState(1);

        private PolygonOffsetState offsetState = new PolygonOffsetLineState();
        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;
        private int quadCount;

        public static QuadStripColoredRenderer Create(QuadStripColoredModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\QuadStripColor.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\QuadStripColor.frag"), ShaderType.FragmentShader);
            var provider = new ShaderCodeArray(shaderCodes);
            var map = new AttributeMap();
            map.Add("in_Position", QuadStripColoredModel.position);
            map.Add("in_Color", QuadStripColoredModel.color);
            var renderer = new QuadStripColoredRenderer(model, provider, map);
            renderer.quadCount = model.quadCount;
            return renderer;
        }

        private QuadStripColoredRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.positionBuffer = this.DataSource.GetVertexAttributeBuffer(QuadStripColoredModel.position, null);
            this.colorBuffer = this.DataSource.GetVertexAttributeBuffer(QuadStripColoredModel.color, null);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("renderWireframe", false);
            base.DoRender(arg);

            //polygonModeState.On();
            //lineWidthState.On();
            //// offsetState.On();
            //this.glUniform("renderWireframe", true);
            //base.DoRender(arg);
            ////offsetState.Off();
            //lineWidthState.Off();
            //polygonModeState.Off();
        }

        //public enum ColorType
        //{
        //    Color,
        //    Texture,
        //}

        //public void SetQuadCount(int quadCount)
        //{
        //    OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBuffer.BufferId);
        //    IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
        //    unsafe
        //    {
        //        var array = (vec3*)pointer.ToPointer();
        //        for (int i = 0; i < (quadCount + 1); i++)
        //        {
        //            array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(quadCount), 0.5f, 0);
        //            array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(quadCount), -0.5f, 0);
        //        }
        //    }
        //    OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
        //    OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        //    this.currentQuadCount = quadCount;
        //}

        //public void UpdateCodedColor(CodedColor[] codedColors)
        //{
        //    int quadCount = codedColors.Length - 1;

        //    {
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBuffer.BufferId);
        //        IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
        //        unsafe
        //        {
        //            var array = (vec3*)pointer.ToPointer();
        //            for (int i = 0; i < (quadCount + 1); i++)
        //            {
        //                //array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(quadCount), 0.5f, 0);
        //                //array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(quadCount), -0.5f, 0);
        //                array[i * 2 + 0] = new vec3(-0.5f + codedColors[i].Coord, 0.5f, 0);
        //                array[i * 2 + 1] = new vec3(-0.5f + codedColors[i].Coord, -0.5f, 0);
        //            }
        //        }
        //        OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        //    }

        //    if (this.colorType == ColorType.Texture)
        //    {
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.texCoordBuffer.BufferId);
        //        IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
        //        unsafe
        //        {
        //            var array = (float*)pointer.ToPointer();
        //            for (int i = 0; i < (quadCount + 1); i++)
        //            {
        //                array[i * 2 + 0] = codedColors[i].Coord;
        //                array[i * 2 + 1] = codedColors[i].Coord;
        //            }
        //        }
        //        OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        //    }
        //    else if (this.colorType == ColorType.Color)
        //    {
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.colorBuffer.BufferId);
        //        IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
        //        unsafe
        //        {
        //            var array = (vec3*)pointer.ToPointer();
        //            for (int i = 0; i < (quadCount + 1); i++)
        //            {
        //                array[i * 2 + 0] = codedColors[i].DisplayColor;
        //                array[i * 2 + 1] = codedColors[i].DisplayColor;
        //            }
        //        }
        //        OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        //    }

        //    {
        //        var pointer = this.indexBuffer as ZeroIndexBuffer;
        //        pointer.VertexCount = (quadCount + 1) * 2;
        //    }
        //}

        public void UpdateColorBar(System.Drawing.Bitmap bitmap)
        {
            IntPtr pointer = this.colorBuffer.MapBuffer(MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                for (int i = 0; i < (quadCount + 1); i++)
                {
                    int x = bitmap.Width * i / quadCount;
                    if (x >= bitmap.Width) { x = 0; }
                    array[i * 2 + 0] = bitmap.GetPixel(x, 0).ToVec3();
                    array[i * 2 + 1] = array[i * 2 + 0];
                }
            }
            this.colorBuffer.UnmapBuffer();
        }
    }
}