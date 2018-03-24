using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d02_ViewSpace
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
        private const float halfWidth = 1f;
        private const float halfHeight = 0.68f;
        private const float halfDepth = 0.68f * 0.68f;
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
			0, 6, 9,  0, 9, 3,
			1, 4, 16,  1, 16, 13,
			2, 14, 20,  2, 20, 8,
			23, 11, 5,  23, 5, 17,
			21, 15, 12,  21, 12, 18,
			22, 19, 7,  22, 7, 10,
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;

        static CameraModel()
        {
            {
                float shotLength = 1;
                var circle = new List<vec3>();
                for (int i = 0; i < 360; i++)
                {
                    circle.Add(new vec3(
                        (float)Math.Cos(Math.PI * (double)i / 180.0),
                        (float)Math.Sin(Math.PI * (double)i / 180.0),
                        0));
                }
                var circle2 = new List<vec3>();
                for (int i = 0; i < 360; i++)
                {
                    circle2.Add(new vec3(
                        (float)Math.Cos(Math.PI * (double)i / 180.0),
                        (float)Math.Sin(Math.PI * (double)i / 180.0),
                        shotLength));
                }
                var list = new List<vec3>();
                foreach (var item in cubePostions) { list.Add(item); }
                list.AddRange(circle); list.AddRange(circle2);
                list.Add(new vec3(0, 0, shotLength));
                CameraModel.positions = list.ToArray();
            }
            {

            }
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (strPosition == bufferName) // requiring position buffer.
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = cubePostions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
                IndexBuffer indexBuffer = cubeIndexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
