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

        private CSharpGL.VertexAttributeBufferPtr positionBufferPtr;

        private CSharpGL.IndexBufferPtr indexBufferPtr;

        public CSharpGL.VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if ((bufferName == position))
            {
                if ((this.positionBufferPtr == null))
                {
                    int length = this.pointPositions.Count;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < this.pointPositions.Count; i++)
                        {
                            array[i] = this.pointPositions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            throw new System.ArgumentException("bufferName");
        }

        public CSharpGL.IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = this.pointPositions.Count;
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