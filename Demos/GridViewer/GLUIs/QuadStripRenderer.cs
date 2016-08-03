using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class QuadStripRenderer : Renderer
    {

        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Lines);
        private LineWidthSwitch lineWidthSwitch = new LineWidthSwitch(1);

        private PolygonOffsetSwitch offsetSwitch = new PolygonOffsetLineSwitch();
        private PropertyBufferPtr positionBufferPtr;
        private int currentQuadCount;
        private ColorType colorType;
        private PropertyBufferPtr texCoordBufferPtr;

        public static QuadStripRenderer Create(QuadStripModel model, ColorType colorType = ColorType.Texture)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\QuadStrip" + colorType + ".vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\QuadStrip" + colorType + ".frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", QuadStripModel.position);
            if (colorType == ColorType.Texture)
            { map.Add("in_TexCoord", QuadStripModel.texCoord); }
            else if (colorType == ColorType.Color)
            { map.Add("in_Color", QuadStripModel.color); }
            else
            { throw new NotImplementedException(); }

            var renderer = new QuadStripRenderer(model, shaderCodes, map, colorType);
            renderer.currentQuadCount = model.quadCount;
            return renderer;
        }

        private QuadStripRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, ColorType colorType, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.colorType = colorType;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.positionBufferPtr = this.bufferable.GetProperty(QuadStripModel.position, null);
            this.texCoordBufferPtr = this.bufferable.GetProperty(QuadStripModel.texCoord, null);
        }

        protected override void DoRender(RenderEventArg arg)
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

        public enum ColorType
        {
            Color,
            Texture,
        }

        public void SetQuadCount(int quadCount)
        {
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                for (int i = 0; i < (quadCount + 1); i++)
                {
                    array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(quadCount), 0.5f, 0);
                    array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(quadCount), -0.5f, 0);
                }
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            this.currentQuadCount = quadCount;
        }

        public void UpdateCodedColor(CodedColor[] codedColors)
        {
            int quadCount = codedColors.Length - 1;

            {
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
                IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    for (int i = 0; i < (quadCount + 1); i++)
                    {
                        //array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(quadCount), 0.5f, 0);
                        //array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(quadCount), -0.5f, 0);
                        array[i * 2 + 0] = new vec3(-0.5f + codedColors[i].Coord, 0.5f, 0);
                        array[i * 2 + 1] = new vec3(-0.5f + codedColors[i].Coord, -0.5f, 0);
                    }
                }
                OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }

            if (this.colorType == ColorType.Texture)
            {
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.texCoordBufferPtr.BufferId);
                IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
                unsafe
                {
                    var array = (float*)pointer.ToPointer();
                    for (int i = 0; i < (quadCount + 1); i++)
                    {
                        array[i * 2 + 0] = codedColors[i].Coord;
                        array[i * 2 + 1] = codedColors[i].Coord;
                    }
                }
                OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
            else if (this.colorType == ColorType.Color)
            {
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.texCoordBufferPtr.BufferId);
                IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    for (int i = 0; i < (quadCount + 1); i++)
                    {
                        array[i * 2 + 0] = codedColors[i].DisplayColor;
                        array[i * 2 + 1] = codedColors[i].DisplayColor;
                    }
                }
                OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }

            {
                var pointer = this.indexBufferPtr as ZeroIndexBufferPtr;
                pointer.VertexCount = (quadCount + 1) * 2;
            }

            this.currentQuadCount = quadCount;
        }
    }

}
