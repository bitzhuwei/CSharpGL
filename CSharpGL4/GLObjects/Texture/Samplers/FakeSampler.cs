namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public class FakeSampler : SamplerBase
    {
        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        public FakeSampler(SamplerParameters parameters, MipmapFilter mipmapFiltering)
            : base(parameters, mipmapFiltering)
        {
        }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="unit">GL.GL_TEXTURE0 etc.</param>
        /// <param name="target"></param>
        public override void Bind(uint unit, TextureTarget target)
        {
            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.Instance.TexParameteri((uint)target, GL.GL_TEXTURE_WRAP_R, (int)this.parameters.wrapR);
            GL.Instance.TexParameteri((uint)target, GL.GL_TEXTURE_WRAP_S, (int)this.parameters.wrapS);
            GL.Instance.TexParameteri((uint)target, GL.GL_TEXTURE_WRAP_T, (int)this.parameters.wrapT);
            /* Linear filtering usually looks best for text */
            GL.Instance.TexParameteri((uint)target, GL.GL_TEXTURE_MIN_FILTER, (int)this.parameters.minFilter);
            GL.Instance.TexParameteri((uint)target, GL.GL_TEXTURE_MAG_FILTER, (int)this.parameters.magFilter);
            // TODO: mipmap filter not working yet.
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="unit"></param>
        ///// <param name="target"></param>
        //public override void Unbind(uint unit, BindTextureTarget target)
        //{
        //    // nothing to do.
        //}
    }
}