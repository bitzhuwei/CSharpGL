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
                //glBindBufferBase(GL_SHADER_STORAGE_BUFFER, 1, g_directionSSBO);
                OpenGL.BindBufferBase(BindBufferBaseTarget.ShaderStorageBuffer, 1, this.g_directionSSBO.BufferId);
                //glBindBufferBase(GL_SHADER_STORAGE_BUFFER, 2, g_positionSSBO);
                OpenGL.BindBufferBase(BindBufferBaseTarget.ShaderStorageBuffer, 2, this.g_positionSSBO.BufferId);
                //glBindBufferBase(GL_SHADER_STORAGE_BUFFER, 3, g_stackSSBO);
                OpenGL.BindBufferBase(BindBufferBaseTarget.ShaderStorageBuffer, 3, this.g_stackSSBO.BufferId);
                //glBindBufferBase(GL_SHADER_STORAGE_BUFFER, 4, g_sphereSSBO);
                OpenGL.BindBufferBase(BindBufferBaseTarget.ShaderStorageBuffer, 4, this.g_sphereSSBO.BufferId);
                //glBindBufferBase(GL_SHADER_STORAGE_BUFFER, 5, g_pointLightSSBO);
                OpenGL.BindBufferBase(BindBufferBaseTarget.ShaderStorageBuffer, 3, this.g_pointLightSSBO.BufferId);
            }
            {
                //mat4 mvp = arg.Camera.GetProjectionMatrix() * arg.Camera.GetViewMatrix();
                this.computeProgram.Bind();
                OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(WIDTH / g_localSize, HEIGHT / g_localSize, 1);
                this.computeProgram.Unbind();

                this.Program.Bind();
                this.texture.Bind();
                // ... and bind this texture as an image, as we will write to it. see binding = 0 in shader.
                //glBindImageTexture(0, g_texture, 0, GL_FALSE, 0, GL_WRITE_ONLY, GL_RGBA8);
                OpenGL.BindImageTexture(0, this.texture.Id, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA8);

                mat4 mvp = arg.Camera.GetProjectionMatrix() * arg.Camera.GetViewMatrix();
                this.SetUniform("mvp", mvp);
                base.DoRender(arg);
            }
        }
    }
}