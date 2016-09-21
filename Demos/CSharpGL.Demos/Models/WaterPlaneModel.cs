namespace CSharpGL.Demos
{
    /// <summary>
    /// 正方形的水面
    /// <para>suqred water plane.</para>
    /// </summary>
    internal class WaterPlaneModel : IBufferable
    {
        public const string strPosition = "position";
        private VertexAttributeBufferPtr positionBuffer;

        /// <summary>
        /// 正方形的水面
        /// <para>suqred water plane.</para>
        /// </summary>
        /// <param name="sideLength"></param>
        public WaterPlaneModel(int sideLength)
        {
            this.SideLength = sideLength;
        }

        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec4>(varNameInShader, VertexAttributeConfig.Vec4, BufferUsage.DynamicDraw))
                    {
                        buffer.Create(this.SideLength * this.SideLength);
                        unsafe
                        {
                            var pointer = (vec4*)buffer.Header.ToPointer();
                            for (int z = 0; z < this.SideLength; z++)
                            {
                                for (int x = 0; x < this.SideLength; x++)
                                {
                                    pointer[x + z * this.SideLength] = new vec4(
                                        -(float)this.SideLength / 2.0f + 0.5f + (float)x,
                                        0.0f,
                                        (float)this.SideLength / 2.0f - 0.5f - (float)z,
                                        1.0f
                                        );
                                }
                            }
                        }
                        positionBuffer = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return positionBuffer;
            }
            else
            {
                throw new System.ArgumentException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                {
                    buffer.Create(this.SideLength * (this.SideLength - 1) * 2);
                    unsafe
                    {
                        var pointer = (uint*)buffer.Header.ToPointer();
                        for (int k = 0; k < this.SideLength - 1; k++)
                        {
                            for (int i = 0; i < this.SideLength; i++)
                            {
                                if (k % 2 == 0)
                                {
                                    pointer[(i + k * this.SideLength) * 2 + 0] = (uint)(i + (k + 1) * this.SideLength);
                                    pointer[(i + k * this.SideLength) * 2 + 1] = (uint)(i + (k + 0) * this.SideLength);
                                }
                                else
                                {
                                    pointer[(i + k * this.SideLength) * 2 + 0] = (uint)(this.SideLength - 1 - i + (k + 0) * this.SideLength);
                                    pointer[(i + k * this.SideLength) * 2 + 1] = (uint)(this.SideLength - 1 - i + (k + 1) * this.SideLength);
                                }
                            }
                        }
                    }
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
        public bool UsesZeroIndexBuffer() { return false; }

        public int SideLength { get; set; }
    }
}