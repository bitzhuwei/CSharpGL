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
                if (this.positionBufferPtr == null)
                {
                    int length = this.markerCount * 2;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < this.markerCount; i++)
                        {
                            array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(this.markerCount - 1), 0.5f, 0);
                            array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(this.markerCount - 1), -0.5f, 0);
                        }
                        bufferPtr.UnmapBuffer();
                    }

                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
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
            if (this.indexBufferPtr == null)
            {
                ZeroIndexBufferPtr bufferPtr = ZeroIndexBufferPtr.Create(DrawMode.Lines, 0, this.markerCount * 2);
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
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