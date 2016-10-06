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
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// 1    3    5    7    9    11
    /// side length is 1.
    /// </summary>
    internal class LinesRenderer : Renderer
    {
        private VertexAttributeBufferPtr positionBufferPtr;
        private int markerCount;

        public static LinesRenderer Create(LinesModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Lines.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Lines.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", LinesModel.position);
            var renderer = new LinesRenderer(model, shaderCodes, map);
            renderer.markerCount = model.markerCount;

            return renderer;
        }

        private LinesRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.positionBufferPtr = this.Model.GetVertexAttributeBufferPtr(LinesModel.position, null);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            base.DoRender(arg);
        }

        public void UpdateCodedColors(double axisMin, double axisMax, double step)
        {
            int lineCount = (int)((axisMax - axisMin) / step) + 1;
            IntPtr pointer = this.positionBufferPtr.MapBuffer(MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                // valid lines.
                for (int i = 0; i < lineCount - 1; i++)
                {
                    array[i * 2 + 0] = new vec3(-0.5f
                        + (float)(step * i / (axisMax - axisMin)),
                        0.5f, 0);
                    array[i * 2 + 1] = new vec3(-0.5f
                        + (float)(step * i / (axisMax - axisMin)),
                        -0.5f, 0);
                }
                // last valid line.
                {
                    int i = lineCount - 1;
                    array[i * 2 + 0] = new vec3(0.5f, 0.5f, 0);
                    array[i * 2 + 1] = new vec3(0.5f, -0.5f, 0);
                }
                // invalid lines.
                for (int i = lineCount; i < this.markerCount; i++)
                {
                    array[i * 2 + 0] = new vec3(0.5f, 0.5f, 0);
                    array[i * 2 + 1] = new vec3(0.5f, -0.5f, 0);
                }
            }
            this.positionBufferPtr.UnmapBuffer();
        }

        //public void UpdateCodedColors(CodedColor[] codedColors)
        //{
        //    int lineCount = codedColors.Length;

        //    {
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
        //        IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
        //        unsafe
        //        {
        //            var array = (vec3*)pointer.ToPointer();
        //            for (int i = 0; i < lineCount; i++)
        //            {
        //                //array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(lineCount - 1), 0.5f, 0);
        //                //array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(lineCount - 1), -0.5f, 0);
        //                array[i * 2 + 0] = new vec3(-0.5f + codedColors[i].Coord, 0.5f, 0);
        //                array[i * 2 + 1] = new vec3(-0.5f + codedColors[i].Coord, -0.5f, 0);
        //            }
        //            for (int i = lineCount; i < this.markerCount; i++)
        //            {
        //                array[i * 2 + 0] = new vec3(0.5f, 0.5f, 0);
        //                array[i * 2 + 1] = new vec3(0.5f, -0.5f, 0);
        //            }
        //        }
        //        OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
        //        OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        //    }
        //}
    }
}