using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture
{
    class QuadModel : IBufferSource
    {

        private static readonly vec2[] quadVerts = new vec2[4] { new vec2(0, 0), new vec2(1, 0), new vec2(1, 1), new vec2(0, 1), };
        private static readonly ushort[] quadIndices = new ushort[] { 0, 1, 2, 0, 2, 3 };

        public const string positions = "positions";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (positions == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = quadVerts.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                IndexBuffer buffer = quadIndices.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.Triangles);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
