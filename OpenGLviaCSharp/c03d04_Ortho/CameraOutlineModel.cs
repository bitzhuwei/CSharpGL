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
    class CameraOutlineModel : IBufferSource
    {
        private const float halfWidth = 0.8f;
        private const float halfHeight = halfWidth * 0.68f;
        private const float halfDepth = halfHeight * 0.68f;
        private static readonly vec3[] cubePostions = new vec3[]
        {
            new vec3(+halfWidth, +halfHeight, +halfDepth), // 0
            new vec3(+halfWidth, +halfHeight, -halfDepth), // 1
            new vec3(+halfWidth, -halfHeight, +halfDepth), // 2
            new vec3(+halfWidth, -halfHeight, -halfDepth), // 3
            new vec3(-halfWidth, +halfHeight, +halfDepth), // 4
            new vec3(-halfWidth, +halfHeight, -halfDepth), // 5
            new vec3(-halfWidth, -halfHeight, +halfDepth), // 6
            new vec3(-halfWidth, -halfHeight, -halfDepth), // 7
        };
        static readonly vec3[] positions;

        private static readonly uint[] cubeIndexes = new uint[]
        {
            0, 4,  2, 6,  3, 7,  1, 5, 
            0, 2,  1, 3,  5, 7,  4, 6, 
            0, 1,  4, 5,  6, 7,  2, 3,
        };
        static readonly uint[] indexes;

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;

        static CameraOutlineModel()
        {
            const int segments = 30;
            const float radius = 0.45f;
            {
                float shotLength = 2;
                var circle = new List<vec3>();
                for (int i = 0; i < segments; i++)
                {
                    circle.Add(new vec3(
                        (float)Math.Cos(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        (float)Math.Sin(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        -halfDepth));
                }
                var circle2 = new List<vec3>();
                for (int i = 0; i < segments; i++)
                {
                    circle2.Add(new vec3(
                        (float)Math.Cos(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        (float)Math.Sin(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        -shotLength));
                }
                var list = new List<vec3>();
                foreach (var item in cubePostions) { list.Add(item); }
                list.AddRange(circle); list.AddRange(circle2);

                CameraOutlineModel.positions = list.ToArray();
            }
            {
                uint firstCircleIndex = (uint)cubePostions.Length;
                var indexes = new List<uint>();
                foreach (var item in cubeIndexes) { indexes.Add(item); }
                for (uint i = 0; i < segments - 1; i++)
                {
                    indexes.Add(i + firstCircleIndex);
                    indexes.Add(i + 1 + firstCircleIndex);
                }
                {
                    indexes.Add(segments - 1 + firstCircleIndex);
                    indexes.Add(0 + firstCircleIndex);
                }
                for (uint i = 0; i < segments - 1; i++)
                {
                    indexes.Add(segments + i + firstCircleIndex);
                    indexes.Add(segments + i + 1 + firstCircleIndex);
                }
                {
                    indexes.Add(segments + segments - 1 + firstCircleIndex);
                    indexes.Add(segments + 0 + firstCircleIndex);
                }
                CameraOutlineModel.indexes = indexes.ToArray();
            }
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
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
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Lines);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
