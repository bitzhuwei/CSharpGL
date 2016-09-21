using System;

namespace CSharpGL
{
    //
    //        2-------------------3
    //      / .                  /|
    //     /  .                 / |
    //    /   .                /  |
    //   /    .               /   |
    //  /     .              /    |
    // 6--------------------7     |
    // |      .             |     |
    // |      0 . . . . . . |. . .1
    // |     .              |    /
    // |    .               |   /
    // |   .                |  /
    // |  .                 | /
    // | .                  |/
    // 4 -------------------5
    //
    /// <summary>
    /// bounding box's model.
    /// </summary>
    public partial class BoundingBoxModel : IBufferable
    {
        /// <summary>
        /// eight vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(-1, -1, -1),// 0
            new vec3(-1, -1, +1),// 1
            new vec3(-1, +1, -1),// 2
            new vec3(-1, +1, +1),// 3
            new vec3(+1, -1, -1),// 4
            new vec3(+1, -1, +1),// 5
            new vec3(+1, +1, -1),// 6
            new vec3(+1, +1, +1),// 7
        };

        /// <summary>
        /// render in GL_QUADS.
        /// </summary>
        private static readonly byte[] indexes = new byte[24]
        {
            1, 3, 7, 5, 0, 4, 6, 2,
            2, 6, 7, 3, 0, 1, 5, 4,
            4, 5, 7, 6, 0, 2, 3, 1,
        };

        /// <summary>
        /// position
        /// </summary>
        public const string strPosition = "position";

        private VertexAttributeBufferPtr positionBufferPtr = null;
        private IndexBufferPtr indexBufferPtr = null;
        private vec3 lengths;

        /// <summary>
        /// bounding box.
        /// </summary>
        /// <param name="lengths">bounding box's length at x, y, z axis.</param>
        public BoundingBoxModel(vec3 lengths)
        {
            this.lengths = lengths;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i] / 2 * this.lengths;
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return positionBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UByte, DrawMode.Quads, BufferUsage.StaticDraw))
                {
                    buffer.Create(indexes.Length);
                    unsafe
                    {
                        var array = (byte*)buffer.Header.ToPointer();
                        for (int i = 0; i < indexes.Length; i++)
                        {
                            array[i] = indexes[i];
                        }
                    }
                    indexBufferPtr = buffer.GetBufferPtr();
                }
            }

            return indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }
    }
}