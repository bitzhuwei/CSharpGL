namespace CSharpGL
{
    using System;
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

        private CSharpGL.VertexAttributeBuffer positionBuffer;

        private CSharpGL.IndexBuffer indexBuffer;

        public CSharpGL.VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if ((bufferName == position))
            {
                if ((this.positionBuffer == null))
                {
                    int length = this.pointPositions.Count;
                    VertexAttributeBuffer buffer = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < this.pointPositions.Count; i++)
                        {
                            array[i] = this.pointPositions[i];
                        }
                        buffer.UnmapBuffer();
                    }
                    this.positionBuffer = buffer;
                }
                return this.positionBuffer;
            }
            throw new System.ArgumentException("bufferName");
        }

        public CSharpGL.IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = this.pointPositions.Count;
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