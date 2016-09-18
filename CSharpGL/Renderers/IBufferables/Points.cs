namespace CSharpGL
{
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

        private CSharpGL.VertexAttributeBufferPtr positionBufferPtr;

        private CSharpGL.IndexBufferPtr indexBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public CSharpGL.VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if ((bufferName == strposition))
            {
                if ((positionBufferPtr == null))
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {// begin of using
                        buffer.Create(this.pointPositions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.pointPositions.Length; i++)
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

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public CSharpGL.IndexBufferPtr GetIndex()
        {
            if ((indexBufferPtr == null))
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, this.pointPositions.Length))
                {// begin of using
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }// end of using
            }
            return indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}