namespace CSharpGL
{
    public partial class UIText
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("fontTexture", this.fontTexture.TextureObj.ToSamplerValue());
        }
    }
}