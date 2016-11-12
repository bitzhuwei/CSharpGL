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
        private VertexBuffer positionBuffer;

        /// <summary>
        /// 正方形的水面
        /// <para>suqred water plane.</para>
        /// </summary>
        /// <param name="sideLength"></param>
        public WaterPlaneModel(int sideLength)
        {
            this.SideLength = sideLength;
        }

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = this.SideLength * this.SideLength;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(vec4), length, VBOConfig.Vec4, BufferUsage.DynamicDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
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
                        buffer.UnmapBuffer();
                    }

                    this.positionBuffer = buffer;
                }
                return this.positionBuffer;
            }
            else
            {
                throw new System.ArgumentException();
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int length = this.SideLength * (this.SideLength - 1) * 2;
                OneIndexBuffer buffer = Buffer.Create(IndexElementType.UInt, length, DrawMode.TriangleStrip, BufferUsage.StaticDraw);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
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
                    buffer.UnmapBuffer();
                }
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }

        private IndexBuffer indexBuffer = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }

        public int SideLength { get; set; }
    }
}