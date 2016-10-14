using CSharpGL;
using System;

namespace GridViewer
{
    /// <summary>
    ///  /|\ y
    ///   |
    ///   |
    ///   |
    ///   ---------------&gt; x
    /// (0, 0)
    /// 0    2    4    6    8    10
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// 1    3    5    7    9    11
    /// side length is 1.
    /// </summary>
    internal class LinesModel : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        public const string position = "position";

        private VertexAttributeBufferPtr positionBufferPtr;

        public LinesModel(int markerCount)
        {
            this.markerCount = markerCount;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(this.markerCount * 2);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.markerCount; i++)
                            {
                                array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(this.markerCount - 1), 0.5f, 0);
                                array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(this.markerCount - 1), -0.5f, 0);
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return positionBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
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
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.Lines, 0, this.markerCount * 2))
                {
                    indexBufferPtr = buffer.GetBufferPtr();
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }

        internal int markerCount;
    }
}