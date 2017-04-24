namespace CSharpGL
{
    /// <summary>
    /// do nothing about sampling in building texture.
    /// </summary>
    public class NullSampler : SamplerBase
    {
        /// <summary>
        /// do nothing about sampling in building texture.
        /// </summary>
        public NullSampler() : base(null, MipmapFilter.LinearMipmapLinear) { }

        /// <summary>
        /// do nothing.
        /// </summary>
        /// <param name="unit">OpenGL.GL_TEXTURE0 etc.</param>
        /// <param name="target"></param>
        public override void Bind(uint unit, TextureTarget target)
        {
            // nothing to do.
        }
    }
}