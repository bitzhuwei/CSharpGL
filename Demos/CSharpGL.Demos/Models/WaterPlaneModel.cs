using System;
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

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = this.SideLength * this.SideLength;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec4), length, VertexAttributeConfig.Vec4, BufferUsage.DynamicDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec4*)pointer;
                        for (int z = 0; z < this.SideLength; z++)
                        {
                            for (int x = 0; x < this.SideLength; x++)
                            {
                                array[x + z * this.SideLength] = new vec4(
                                    -(float)this.SideLength / 2.0f + 0.5f + (float)x,
                                    0.0f,
                                    (float)this.SideLength / 2.0f - 0.5f - (float)z,
                                    1.0f
                                    );
                            }
                        }
                        bufferPtr.UnmapBuffer();
                    }

                    this.positionBuffer = bufferPtr;
                }
                return this.positionBuffer;
            }
            else
            {
                throw new System.ArgumentException();
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int length = this.SideLength * (this.SideLength - 1) * 2;
                OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.TriangleStrip, IndexElementType.UInt, length);
                unsafe
                {
                    IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer;
                    for (int k = 0; k < this.SideLength - 1; k++)
                    {
                        for (int i = 0; i < this.SideLength; i++)
                        {
                            if (k % 2 == 0)
                            {
                                array[(i + k * this.SideLength) * 2 + 0] = (uint)(i + (k + 1) * this.SideLength);
                                array[(i + k * this.SideLength) * 2 + 1] = (uint)(i + (k + 0) * this.SideLength);
                            }
                            else
                            {
                                array[(i + k * this.SideLength) * 2 + 0] = (uint)(this.SideLength - 1 - i + (k + 0) * this.SideLength);
                                array[(i + k * this.SideLength) * 2 + 1] = (uint)(this.SideLength - 1 - i + (k + 1) * this.SideLength);
                            }
                        }
                    }
                    bufferPtr.UnmapBuffer();
                }
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
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