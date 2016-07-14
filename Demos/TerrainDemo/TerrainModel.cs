using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainDemo
{
    class TerrainModel : IBufferable
    {
        private IList<vec3> positions;
        public TerrainModel(IList<vec3> positions)
        {
            this.positions = positions;
        }

        public const string strPosition = "position";
        private PropertyBufferPtr positionBufferPtr;
        private IndexBufferPtr indexBufferPtr;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr != null) { return this.positionBufferPtr; }

                using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                {
                    buffer.Create(this.positions.Count);
                    unsafe
                    {
                        var array = (vec3*)buffer.Header.ToPointer();
                        for (int i = 0; i < this.positions.Count; i++)
                        {
                            array[i] = this.positions[i];
                        }
                    }
                    this.positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
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
            if (this.indexBufferPtr != null) { return this.indexBufferPtr; }

            using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, this.positions.Count))
            {
                this.indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
            }

            return this.indexBufferPtr;
        }
    }
}
