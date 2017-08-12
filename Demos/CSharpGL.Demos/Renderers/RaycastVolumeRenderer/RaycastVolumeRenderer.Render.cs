namespace CSharpGL.Demos
{
    partial class RaycastVolumeRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            int[] viewport = OpenGL.GetViewport();
            if (this.width != viewport[2] || this.height != viewport[3])
            {
                Resize(viewport[2], viewport[3]);
            }

            mat4 mvp = arg.Camera.GetProjectionMatrix() * arg.Camera.GetViewMatrix();
            this.backfaceRenderer.SetUniform("MVP", mvp);
            this.raycastRenderer.SetUniform("MVP", mvp);

            // render to texture
            this.framebuffer.Bind(FramebufferTarget.Framebuffer);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            this.backfaceRenderer.Render(arg);
            this.framebuffer.Unbind(FramebufferTarget.Framebuffer);

            this.raycastRenderer.Render(arg);
        }
    }
}