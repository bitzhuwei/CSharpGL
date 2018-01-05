using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace TerrainLoading
{
    class TerainModel : IBufferSource
    {
        public const int TERRAIN_WIDTH = 64;
        public const int TERRAIN_DEPTH = 64;

        private uint[] indices = new uint[(2 * TERRAIN_WIDTH + 1) * (TERRAIN_DEPTH - 1)];

        private IndexBuffer indexBuffer;

        public TerainModel()
        {
            uint count = 0;
            for (uint v = 0; v < TERRAIN_DEPTH - 1; v++)
            {
                for (uint u = 0; u < TERRAIN_WIDTH; u++)
                {
                    uint i0 = v * TERRAIN_WIDTH + u;
                    uint i1 = i0 + TERRAIN_WIDTH;
                    indices[count++] = i0; indices[count++] = i1;
                }

                indices[count++] = uint.MaxValue;
            }
        }

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            // no vertex attribute buffer needed.
            {
                throw new ArgumentException();
            }
        }

        public IDrawCommand GetDrawCommand()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = this.indices.GenIndexBuffer(DrawMode.TriangleStrip, BufferUsage.StaticDraw);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
