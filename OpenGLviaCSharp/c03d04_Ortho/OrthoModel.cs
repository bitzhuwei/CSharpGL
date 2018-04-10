using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d04_Ortho
{
    /// <summary>
    ///        Y
    ///        |
    ///        5___________4
    ///       /|          /|
    ///      / |         / |
    ///     1--+--------0  |
    ///     |  6_ _ _ _ |_ 7____ X
    ///     |  /        |  /
    ///     | /         | /
    ///     |/__________|/
    ///     2           3
    ///    /
    ///   Z
    class OrthoModel : IBufferSource
    {

        private readonly vec3[] positions;
        private static readonly uint[] indexes = new uint[] { 0, 4, 1, 5, 2, 6, 3, 7, 0, 4, };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;

        public OrthoModel(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            var positions = new List<vec3>();
            {
                positions.Add(new vec3(right, top, -zNear));
                positions.Add(new vec3(left, top, -zNear));
                positions.Add(new vec3(left, bottom, -zNear));
                positions.Add(new vec3(right, bottom, -zNear));
            }
            {
                positions.Add(new vec3(right, top, -zFar));
                positions.Add(new vec3(left, top, -zFar));
                positions.Add(new vec3(left, bottom, -zFar));
                positions.Add(new vec3(right, bottom, -zFar));
            }
            this.positions = positions.ToArray();
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexProperty(string bufferName)
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
