using CSharpGL;
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
    internal class QuadStripRenderer : Renderer
    {
        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
        private LineWidthSwitch lineWidthSwitch = new LineWidthSwitch(1);

        private PolygonOffsetSwitch offsetSwitch = new PolygonOffsetLineSwitch();
        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr texCoordBufferPtr;

        public static QuadStripRenderer Create(QuadStripModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\QuadStripTexture.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\QuadStripTexture.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("in_Position", QuadStripModel.position);
            map.Add("in_TexCoord", QuadStripModel.texCoord);

            var renderer = new QuadStripRenderer(model, shaderCodes, map);
            return renderer;
        }

        private QuadStripRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            AttributeNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.positionBufferPtr = this.Model.GetVertexAttributeBufferPtr(QuadStripModel.position, null);
            this.texCoordBufferPtr = this.Model.GetVertexAttributeBufferPtr(QuadStripModel.texCoord, null);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("renderWireframe", false);
            base.DoRender(arg);

            polygonModeSwitch.On();
            lineWidthSwitch.On();
            // offsetSwitch.On();
            this.SetUniform("renderWireframe", true);
            base.DoRender(arg);
            //offsetSwitch.Off();
            lineWidthSwitch.Off();
            polygonModeSwitch.Off();
        }

        //public enum ColorType
        //{
        //    Color,
        //    Texture,
        //}

        //public void SetQuadCount(int quadCount)
        //{
        //    OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
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
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
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
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.texCoordBufferPtr.BufferId);
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
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.colorBufferPtr.BufferId);
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
        //        var pointer = this.indexBufferPtr as ZeroIndexBufferPtr;
        //        pointer.VertexCount = (quadCount + 1) * 2;
        //    }
        //}
    }
}