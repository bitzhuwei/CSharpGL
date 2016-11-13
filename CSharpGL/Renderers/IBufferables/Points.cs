namespace CSharpGL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Some Points
    /// </summary>
    public partial class Points : IBufferable
    {
        private vec3[] pointPositions;

        /// <summary>
        ///
        /// </summary>
        public vec3 WorldPosition { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public vec3 Lengths { get; private set; }

        /// <summary>
        /// Some Points
        /// </summary>
        /// <param name="pointPositions"></param>
        public Points(IList<vec3> pointPositions)
        {
            vec3[] positions = pointPositions.ToArray();
            var box = positions.Move2Center();
            this.Lengths = box.MaxPosition - box.MinPosition;
            this.WorldPosition = box.MaxPosition / 2 + box.MinPosition / 2;
            this.pointPositions = positions;
        }

        /// <summary>
        ///
        /// </summary>
        public const string strposition = "position";

        private CSharpGL.VertexBuffer positionBuffer;

        private CSharpGL.IndexBuffer indexBuffer;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public CSharpGL.VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strposition)
            {
                if (this.positionBuffer == null)
                {
                    //int length = this.pointPositions.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (vec3*)pointer;
                    //    for (int i = 0; i < this.pointPositions.Length; i++)
                    //    {
                    //        array[i] = this.pointPositions[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.positionBuffer = buffer;
                    // another way to do this:
                    this.positionBuffer = this.pointPositions.GenVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.positionBuffer;
            }
            else
            {
                throw new System.ArgumentException("bufferName");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public CSharpGL.IndexBuffer GetIndexBuffer()
        {
            if ((indexBuffer == null))
            {
                int vertexCount = this.pointPositions.Length;
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, vertexCount);
                this.indexBuffer = buffer;
            }
            return indexBuffer;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}