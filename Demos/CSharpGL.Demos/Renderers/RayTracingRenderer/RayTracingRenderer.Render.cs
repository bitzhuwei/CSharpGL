namespace CSharpGL.Demos
{
    partial class RayTracingRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 mvp = arg.Camera.GetProjectionMatrix() * arg.Camera.GetViewMatrix();
        }
    }
}