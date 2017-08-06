using System;

namespace CSharpGL
{
    public partial class TransformFeedbackBuffer
    {
        /// <summary>
        /// Use this <see cref="UniformBuffer"/> as a <see cref="VertexBuffer"/>.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public VertexBuffer AsVertexBuffer(VBOConfig config)
        {
            var buffer = new VertexBuffer(this.BufferId, config, this.Length, this.ByteLength);

            return buffer;
        }
    }
}
