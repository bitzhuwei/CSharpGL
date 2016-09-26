namespace CSharpGL
{
    public partial class TextRenderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("mvp", projection * view * model);
            if (this.textColorRecord.IsMarked())
            {
                this.SetUniform("textColor", this.textColor);
                this.textColorRecord.CancelMark();
            }
            if (this.textRecord.IsMarked())
            {
                TextModel textModel = this.textModel;
                if (textModel != null)
                {
                    textModel.SetText(this.text, this.fontTexture);
                    this.textRecord.CancelMark();
                }
            }

            blendSwitch.On();

            base.DoRender(arg);

            blendSwitch.Off();
        }
    }
}