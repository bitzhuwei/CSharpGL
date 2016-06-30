using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public class CodedColorBarLine : IBufferable
    {

        public CodedColor[] codedColors { get; private set; }

        public const string strPosition = "position";

        private PropertyBufferPtr positionBufferPtr;

        private IndexBufferPtr indexBufferPtr;

        public CodedColorBarLine(CodedColor[] codedColors)
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
                    const float lower = 0.3f;
                    var positions = new vec2[codedColors.Length * 2 + 4];
                    for (int i = 0; i < codedColors.Length; i++)
                    {
                        positions[i * 2 + 0] = new vec2(codedColors[i].Coord * 2, lower);
                        positions[i * 2 + 1] = new vec2(codedColors[i].Coord * 2, 1);
                    }
                    int index = codedColors.Length * 2 + 0;
                    positions[index++] = new vec2(codedColors[0].Coord * 2, 0.5f);
                    positions[index++] = new vec2(codedColors[codedColors.Length - 1].Coord * 2, 0.5f);
                    positions[index++] = new vec2(codedColors[0].Coord * 2, 1);
                    positions[index++] = new vec2(codedColors[codedColors.Length - 1].Coord * 2, 1);
                    // Move2Cente
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
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (this.indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.Lines, 0, codedColors.Length * 2 + 4))
                {
                    this.indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }
            return this.indexBufferPtr;
        }
    }
}
