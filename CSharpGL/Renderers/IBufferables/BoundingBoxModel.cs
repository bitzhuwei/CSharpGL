using System;

namespace CSharpGL
{
    /// <summary>
    /// bounding box's model.
    /// </summary>
    public partial class BoundingBoxModel : IBufferable
    {
        private vec3[] positions = new vec3[]
        {
            new vec3(1, 1, 1),   new vec3(-1, 1, 1),
            new vec3(1, 1, -1),  new vec3(-1, 1, -1),
            new vec3(1, -1, -1), new vec3(-1, -1, -1),
            new vec3(1, -1, 1),  new vec3(-1, -1, 1),
            new vec3(1, 1, 1),   new vec3(-1, 1, 1),
        };

        /// <summary>
        /// position
        /// </summary>
        public const string strPosition = "position";

        private VertexAttributeBufferPtr positionBufferPtr = null;
        private IndexBufferPtr indexBufferPtr = null;
        private vec3 lengths;

        ///// <summary>
        ///// bounding box's model.
        ///// </summary>
        //public BoundingBoxModel() { }
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
        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
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

                        positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
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
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.QuadStrip, 0, positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBufferPtr"/> or <see cref="OneIndexBufferPtr"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBufferPtr() { return true; }
    }
}