using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c01d00_Cube {
    /// <summary>
    ///        Y
    ///        |
    ///        5___________1
    ///       /|          /|
    ///      / |         / |
    ///     4--+--------0  |
    ///     |  7_ _ _ _ |_ 3____ X
    ///     |  /        |  /
    ///     | /         | /
    ///     |/__________|/
    ///     6           2
    ///    /
    ///   Z
    /// </summary>
    class CubeModel : IBufferSource {
        private const float halfLength = 0.5f;
        public static readonly vec4[] positions = new vec4[]
        {
            new vec4(+halfLength, +halfLength, +halfLength, 0), // 0
            new vec4(+halfLength, +halfLength, -halfLength, 0), // 1
            new vec4(+halfLength, -halfLength, +halfLength, 0), // 2
            new vec4(+halfLength, -halfLength, -halfLength, 0), // 3 
            new vec4(-halfLength, +halfLength, +halfLength, 0), // 4 
            new vec4(-halfLength, +halfLength, -halfLength, 0), // 5
            new vec4(-halfLength, -halfLength, +halfLength, 0), // 6
            new vec4(-halfLength, -halfLength, -halfLength, 0), // 7
        };
        public static readonly vec4[] colors = new vec4[]
              {
            new vec4(+halfLength, +halfLength, +halfLength, 0) + new vec4(halfLength), // 0
            new vec4(+halfLength, +halfLength, -halfLength, 0) + new vec4(halfLength), // 1
            new vec4(+halfLength, -halfLength, +halfLength, 0) + new vec4(halfLength), // 2
            new vec4(+halfLength, -halfLength, -halfLength, 0) + new vec4(halfLength), // 3 
            new vec4(-halfLength, +halfLength, +halfLength, 0) + new vec4(halfLength), // 4 
            new vec4(-halfLength, +halfLength, -halfLength, 0) + new vec4(halfLength), // 5
            new vec4(-halfLength, -halfLength, +halfLength, 0) + new vec4(halfLength), // 6
            new vec4(-halfLength, -halfLength, -halfLength, 0) + new vec4(halfLength), // 7
              };
        public static readonly uint[] indexes = new uint[]
        {
            0, 2, 1,  1, 2, 3, // +X faces.
            0, 1, 5,  0, 5, 4, // +Y faces.
            0, 4, 2,  2, 4, 6, // +Z faces.
            7, 6, 4,  7, 4, 5, // -X faces.
            7, 5, 3,  3, 5, 1, // -Z faces.
            7, 3, 2,  7, 2, 6, // -Y faces.
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer; // array in GPU side.

        private IDrawCommand drawCommand;


        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) // requiring position buffer.
            {
                if (this.positionBuffer == null) {
                    // transform managed array to vertex buffer.
                    this.positionBuffer = positions.GenVertexBuffer(
                        VBOConfig.Vec4, // mapping to 'in vec3 someVar;' in vertex shader.
                        GLBuffer.Usage.StaticDraw); // GL_STATIC_DRAW.
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                // indexes in GPU side.
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(IndexBuffer.ElementType.UInt, GLBuffer.Usage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, CSharpGL.DrawMode.Triangles); // GL_TRIANGLES.
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
