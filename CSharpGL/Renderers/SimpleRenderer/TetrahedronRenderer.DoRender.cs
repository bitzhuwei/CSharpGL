namespace CSharpGL
{
    /// <summary>
    /// Renders a label that always faces camera in 3D space.
    /// </summary>
    public partial class SimpleRenderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.modelMatrixRecord.IsMarked())
            {
                this.SetUniform("modelMatrix", this.WorldPosition);
                this.modelMatrixRecord.CancelMark();
            }
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);

            base.DoRender(arg);
        }
    }
}