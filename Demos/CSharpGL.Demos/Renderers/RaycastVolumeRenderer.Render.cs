namespace CSharpGL.Demos
{
    [DemoRenderer]
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
            // need or need not to resume the state of only one active texture unit?
            // glActiveTexture(GL_TEXTURE1);
            // glBindTexture(GL_TEXTURE_2D, 0);
            // glDisable(GL_TEXTURE_2D);
            // glActiveTexture(GL_TEXTURE2);
            // glBindTexture(GL_TEXTURE_3D, 0);
            // glDisable(GL_TEXTURE_3D);
            // glActiveTexture(GL_TEXTURE0);
            // glBindTexture(GL_TEXTURE_1D, 0);
            // glDisable(GL_TEXTURE_1D);
            // glActiveTexture(GL_TEXTURE0);

            // // for test the first pass
            // glBindFramebuffer(GL_READ_FRAMEBUFFER, g_frameBuffer);
            // checkFramebufferStatus();
            // glBindFramebuffer(GL_DRAW_FRAMEBUFFER, 0);
            // glViewport(0, 0, g_winWidth, g_winHeight);
            // glClearColor(0.0, 0.0, 1.0, 1.0);
            // glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            // GL_ERROR();
            // glBlitFramebuffer(0, 0, g_winWidth, g_winHeight,0, 0,
            // 		      g_winWidth, g_winHeight, GL_COLOR_BUFFER_BIT, GL_NEAREST);
            // glBindFramebuffer(GL_FRAMEBUFFER, 0);
            // GL_ERROR();
            //this.depthTest.Off();
        }
    }
}