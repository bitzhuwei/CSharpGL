using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public class ColorCodedBarRectRendererFactory
    {

        public static Renderer GetCodedColorBarRectRenderer(CodedColor[] codedcolors)
        {
            if (codedcolors == null || codedcolors.Length < 1) { throw new ArgumentException(); }

            throw new NotImplementedException();
        }
    }

    public class CodedColorBarRect : IBufferable
    {

        public CodedColor[] codedColors { get; private set; }

        public const string strPosition = "position";
        public const string strCoord = "coord";

        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr coordBufferPtr;
        private IndexBufferPtr indexBufferPtr;

        public CodedColorBarRect(CodedColor[] codedColors)
        {
            if (codedColors == null || codedColors.Length < 1) { throw new ArgumentException(); }

            this.codedColors = codedColors;
        }

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    var positions = new vec2[codedColors.Length * 2];
                    for (int i = 0; i < codedColors.Length; i++)
                    {
                        positions[i * 2 + 0] = new vec2(codedColors[i].Coord, 0);
                        positions[i * 2 + 1] = new vec2(codedColors[i].Coord, 1);
                    }
                    //positions.Move2Center();
                    float min = positions[0].x, max = positions[0].x;
                    for (int i = 1; i < positions.Length; i++)
                    {
                        vec2 value = positions[i];
                        if (value.x < min) { min = value.x; }
                        if (max < value.x) { max = value.x; }
                    }
                    float mid = max / 2 + min / 2;
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i].x = positions[i].x - mid;
                    }
                    using (var buffer = new PropertyBuffer<vec2>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(positions.Length);
                        unsafe
                        {
                            var array = (vec2*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            { array[i] = positions[i]; }
                        }
                        this.positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strCoord)
            {
                if (this.coordBufferPtr == null)
                {
                    var coords = new float[codedColors.Length * 2];
                    for (int i = 0; i < codedColors.Length; i++)
                    {
                        coords[i * 2 + 0] = codedColors[i].Coord;
                        coords[i * 2 + 1] = codedColors[i].Coord;
                    }
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 1, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(coords.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < coords.Length; i++)
                            { array[i] = coords[i]; }
                        }
                        this.coordBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return this.coordBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (this.indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.QuadStrip, 0, codedColors.Length * 2))
                {
                    this.indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }
            return this.indexBufferPtr;
        }
    }
}
