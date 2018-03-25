using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d03_Perspective
{
    /// <summary>
    ///           Y
    ///           |
    ///        5__|________1
    ///       /|  |       /|
    ///      / |  |      / |
    ///     4--+--+-----0  |
    ///     |  7__| _ _ |_ 3
    ///     |  /  |_____|__/_______ X
    ///     | /   /     | /
    ///     |/___/______|/
    ///     6   /       2
    ///        /
    ///       Z
    /// </summary>
    class PerspectiveModel : IBufferSource
    {
        private const float nearHalfLength = 0.5f;
        private const float farHalfLength = 1.5f;
        private const float depth = -2;
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+nearHalfLength, +nearHalfLength, 0),     // 0
            new vec3(+farHalfLength, +farHalfLength, depth), // 1
            new vec3(+nearHalfLength, -nearHalfLength, 0),     // 2
            new vec3(+farHalfLength, -farHalfLength, depth), // 3
            new vec3(-nearHalfLength, +nearHalfLength, 0),     // 4
            new vec3(-farHalfLength, +farHalfLength, depth), // 5
            new vec3(-nearHalfLength, -nearHalfLength, 0),     // 6
            new vec3(-farHalfLength, -farHalfLength, depth), // 7
        };

        private static readonly uint[] indexes = new uint[] { 0, 1, 2, 3, 6, 7, 4, 5, 0, 1, };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (strPosition == bufferName) // requiring position buffer.
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.QuadStrip);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
