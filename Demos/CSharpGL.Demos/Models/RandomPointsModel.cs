namespace CSharpGL
{
    using System;

    /// <summary>
    /// Model of random points.
    /// </summary>
    public partial class RandomPointsModel : CSharpGL.IBufferable
    {
        private int pointCount;

        public vec3 Lengths { get; private set; }

        public RandomPointsModel(vec3 lengths, int pointCount)
        {
            this.Lengths = lengths;
            this.pointCount = pointCount;
        }

        public const string position = "position";

        private CSharpGL.VertexBuffer positionBuffer;

        private CSharpGL.IndexBuffer indexBuffer;

        public CSharpGL.VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if ((bufferName == position))
            {
                if ((this.positionBuffer == null))
                {
                    int length = this.pointCount;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        var random = new Random();
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < this.pointCount; i++)
                        {
                            array[i] = (new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()) - new vec3(0.5f, 0.5f, 0.5f)) * this.Lengths;
                        }
                        buffer.UnmapBuffer();
                    }

                    this.positionBuffer = buffer;
                }
                return positionBuffer;
            }
            else
            {
                throw new System.ArgumentException("bufferName");
            }
        }

        public CSharpGL.IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = this.pointCount;
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, vertexCount);
                this.indexBuffer = buffer;

            }
            return this.indexBuffer;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}