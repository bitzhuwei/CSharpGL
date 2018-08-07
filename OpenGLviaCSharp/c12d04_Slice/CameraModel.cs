using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d04_Slice
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
    class CameraModel : IBufferSource
    {
        private const float halfWidth = 0.8f;
        private const float halfHeight = halfWidth * 0.68f;
        private const float halfDepth = halfHeight * 0.68f;
        private static readonly vec3[] cubePostions = new vec3[]
        {
            new vec3(+halfWidth, +halfHeight, +halfDepth), // 0 0
            new vec3(+halfWidth, +halfHeight, +halfDepth), // 0 1
            new vec3(+halfWidth, +halfHeight, +halfDepth), // 0 2
            new vec3(+halfWidth, +halfHeight, -halfDepth), // 1 3
            new vec3(+halfWidth, +halfHeight, -halfDepth), // 1 4
            new vec3(+halfWidth, +halfHeight, -halfDepth), // 1 5
            new vec3(+halfWidth, -halfHeight, +halfDepth), // 2 6
            new vec3(+halfWidth, -halfHeight, +halfDepth), // 2 7
            new vec3(+halfWidth, -halfHeight, +halfDepth), // 2 8
            new vec3(+halfWidth, -halfHeight, -halfDepth), // 3 9
            new vec3(+halfWidth, -halfHeight, -halfDepth), // 3 10
            new vec3(+halfWidth, -halfHeight, -halfDepth), // 3 11
            new vec3(-halfWidth, +halfHeight, +halfDepth), // 4 12
            new vec3(-halfWidth, +halfHeight, +halfDepth), // 4 13
            new vec3(-halfWidth, +halfHeight, +halfDepth), // 4 14
            new vec3(-halfWidth, +halfHeight, -halfDepth), // 5 15
            new vec3(-halfWidth, +halfHeight, -halfDepth), // 5 16
            new vec3(-halfWidth, +halfHeight, -halfDepth), // 5 17
            new vec3(-halfWidth, -halfHeight, +halfDepth), // 6 18
            new vec3(-halfWidth, -halfHeight, +halfDepth), // 6 19
            new vec3(-halfWidth, -halfHeight, +halfDepth), // 6 20
            new vec3(-halfWidth, -halfHeight, -halfDepth), // 7 21
            new vec3(-halfWidth, -halfHeight, -halfDepth), // 7 22
            new vec3(-halfWidth, -halfHeight, -halfDepth), // 7 23
        };
        static readonly vec3[] positions;

        private static readonly uint[] cubeIndexes = new uint[]
        {
			0, 6, 9, 3,
            1, 4, 16, 13,
            2, 14, 20, 8,
            21, 15, 12, 18,
            22, 19, 7, 10,
            23, 11, 5, 17,
        };
        static readonly uint[] indexes;

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;

        static CameraModel()
        {
            const int segments = 30;
            const float radius = 0.45f;
            {
                float shotLength = 1;
                var circle = new List<vec3>();
                for (int i = 0; i < segments + 1; i++)
                {
                    circle.Add(new vec3(
                        (float)Math.Cos(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        (float)Math.Sin(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        -halfDepth));
                }
                var circle2 = new List<vec3>();
                for (int i = 0; i < segments + 1; i++)
                {
                    circle2.Add(new vec3(
                        (float)Math.Cos(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        (float)Math.Sin(2.0 * Math.PI * (double)i / (double)segments) * radius,
                        -shotLength));
                }
                var list = new List<vec3>();
                foreach (var item in cubePostions) { list.Add(item); }
                list.AddRange(circle); list.AddRange(circle2);

                list.Add(new vec3(0, 0, -shotLength));

                CameraModel.positions = list.ToArray();
            }
            {
                uint firstCircleIndex = (uint)cubePostions.Length;
                var indexes = new List<uint>();
                foreach (var item in cubeIndexes) { indexes.Add(item); }
                for (uint i = 0; i < segments; i++)
                {
                    indexes.Add(i + firstCircleIndex);
                    indexes.Add(segments + 1 + i + firstCircleIndex);
                    indexes.Add(segments + 1 + i + 1 + firstCircleIndex);
                    indexes.Add(i + 1 + firstCircleIndex);
                }
                for (uint i = 0; i < segments; i++)
                {
                    indexes.Add(segments + 1 + i + firstCircleIndex);
                    indexes.Add(segments + 1 + i + 1 + firstCircleIndex);
                    indexes.Add(segments + 1 + segments + 1 + firstCircleIndex);
                    indexes.Add(segments + 1 + segments + 1 + firstCircleIndex);
                }
                CameraModel.indexes = indexes.ToArray();
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
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Quads);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
