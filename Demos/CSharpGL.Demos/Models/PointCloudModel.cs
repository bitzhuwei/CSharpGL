namespace CSharpGL
{
    using System.Collections.Generic;

    /// <summary>
    /// Model of PointCloud
    /// </summary>
    public partial class PointCloudModel : CSharpGL.IBufferable
    {
        private List<vec3> pointPositions;

        public vec3 WorldPosition { get; private set; }
        public vec3 Lengths { get; private set; }

        public PointCloudModel(List<vec3> pointPositions)
        {
            var box = pointPositions.Move2Center();
            this.Lengths = box.MaxPosition - box.MinPosition;
            //this.WorldPosition = box.MaxPosition / 2 + box.MinPosition / 2;
            this.pointPositions = pointPositions;
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
                        buffer.Create(this.pointPositions.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.pointPositions.Count; i++)
                            {
                                array[i] = this.pointPositions[i];
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
                using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, this.pointPositions.Count))
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