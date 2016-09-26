namespace CSharpGL
{
    public partial class TextRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("fontTexture", this.fontTexture.TextureObj.ToSamplerValue());
        }
    }
}