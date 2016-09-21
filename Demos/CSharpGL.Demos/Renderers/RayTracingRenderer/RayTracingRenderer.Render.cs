namespace CSharpGL.Demos
{
    partial class RayTracingRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            {
                this.computeProgram.Bind();
                // Also bind created texture ...
                this.texture.Bind();
                // ... and bind this texture as an image, as we will write to it. see binding = 0 in shader.
                //glBindImageTexture(0, g_texture, 0, GL_FALSE, 0, GL_WRITE_ONLY, GL_RGBA8);
                OpenGL.BindImageTexture(0, this.texture.Id, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA8);
            }
            {
                mat4 mvp = arg.Camera.GetProjectionMatrix() * arg.Camera.GetViewMatrix();
            }
        }
    }
}