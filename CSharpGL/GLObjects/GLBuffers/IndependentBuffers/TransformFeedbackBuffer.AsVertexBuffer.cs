using System;

namespace CSharpGL {
    public unsafe partial class TransformFeedbackBuffer {
        /// <summary>
        /// Use this <see cref="UniformBuffer"/> as a <see cref="VertexBuffer"/>.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public VertexBuffer AsVertexBuffer(VBOConfig config) {
            var buffer = new VertexBuffer(this.bufferId, config, this.count, this.byteLength, this.usage);

            return buffer;
        }
    }
}
