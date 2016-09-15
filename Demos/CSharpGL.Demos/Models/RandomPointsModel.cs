namespace CSharpGL
{
    using System;
    using System.Collections.Generic;

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

        public CSharpGL.VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if ((bufferName == position))
            {
                if ((positionBufferPtr == null))
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {// begin of using
                        buffer.Create(this.pointCount);
                        unsafe
                        {
                            var random = new Random();
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.pointCount; i++)
                            {
                                array[i] = (new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()) - new vec3(0.5f, 0.5f, 0.5f)) * this.Lengths;
                            }
                        }
                        positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }// end of using
                }
                return positionBufferPtr;
            }
            throw new System.ArgumentException("bufferName");
        }

        public CSharpGL.IndexBufferPtr GetIndex()
        {
            if ((indexBufferPtr == null))
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, this.pointCount))
                {// begin of using
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }// end of using
            }
            return indexBufferPtr;
        }
        /// <summary>
        /// UsesUses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }

    }
}