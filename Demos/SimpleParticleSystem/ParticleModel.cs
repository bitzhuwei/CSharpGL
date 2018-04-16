using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace SimpleParticleSystem
{
    class ParticleModel : IBufferSource
    {
        public const int TERRAIN_WIDTH = 64;
        public const int TERRAIN_DEPTH = 64;

        private uint[] indices = new uint[(2 * TERRAIN_WIDTH + 1) * (TERRAIN_DEPTH - 1)];

        private IDrawCommand drawCmd;

        public ParticleModel()
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

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            // no vertex attribute buffer needed.
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                IndexBuffer buffer = this.indices.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.TriangleStrip, uint.MaxValue);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
