namespace CSharpGL.Demos
{
    internal partial class WaterBackgroundRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();
            this.SetUniform("u_projectionMatrix", projection);
            this.SetUniform("u_modelViewMatrix", view);

            //OpenGL.FrontFace(OpenGL.GL_CW);

            base.DoRender(arg);
        }
    }
}