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

        private CSharpGL.VertexAttributeBufferPtr positionBufferPtr;

        private CSharpGL.IndexBufferPtr indexBufferPtr;

        public CSharpGL.VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if ((bufferName == position))
            {
                if ((this.positionBufferPtr == null))
                {
                    int length = this.pointCount;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        var random = new Random();
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < this.pointCount; i++)
                        {
                            array[i] = (new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()) - new vec3(0.5f, 0.5f, 0.5f)) * this.Lengths;
                        }
                        bufferPtr.UnmapBuffer();
                    }

                    this.positionBufferPtr = bufferPtr;
                }
                return positionBufferPtr;
            }
            else
            {
                throw new System.ArgumentException("bufferName");
            }
        }

        public CSharpGL.IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = this.pointCount;
                ZeroIndexBufferPtr bufferPtr = ZeroIndexBufferPtr.Create(DrawMode.Points, 0, vertexCount);
                this.indexBufferPtr = bufferPtr;

            }
            return this.indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}