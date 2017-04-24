namespace CSharpGL
{
    public partial class LabelRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            //int[] viewport = OpenGL.GetViewport();
            //this.glUniform("pixelScale", (float)viewport[2]);
            //this.glUniform("fontHeight", (float)fontResource.FontHeight);
            //this.glUniform("textColor", new vec3(1, 0, 0));
            this.SetUniform("fontTexture", this.fontTexture.TextureObj);
        }
    }
}