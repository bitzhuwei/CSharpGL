namespace CSharpGL.Demos
{
    internal partial class WaterTextureRenderer
    {
        private Texture mirrorTexture;

        public Texture MirrorTexture
        {
            get { return mirrorTexture; }
        }

        private const int TEXTURE_SIZE = 1024;
        private Framebuffer framebuffer;
        private ViewportSwitch viewportSwitch;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                var texture = new Texture(TextureTarget.Texture2D,
                    new NullImageFiller(TEXTURE_SIZE, TEXTURE_SIZE, OpenGL.GL_RGB, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE),
                    new SamplerParameters(
                        TextureWrapping.Repeat,
                        TextureWrapping.Repeat,
                        TextureWrapping.Repeat,
                        TextureFilter.Linear,
                        TextureFilter.Linear));
                texture.ActiveTexture = OpenGL.GL_TEXTURE1;
                texture.Initialize();
                this.mirrorTexture = texture;
            }
            {
                Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(TEXTURE_SIZE, TEXTURE_SIZE, DepthComponentType.DepthComponent);
                var framebuffer = new Framebuffer();
                framebuffer.Bind();
                framebuffer.Attach(this.mirrorTexture);
                framebuffer.Attach(depthBuffer);
                framebuffer.CheckCompleteness();
                this.framebuffer = framebuffer;
            }

            {
                mat4 view = glm.lookAt(new vec3(0.0f, 0.0f, 5.0f), new vec3(0.0f, 0.0f, 0.0f), new vec3(0.0f, 1.0f, 0.0f));
                this.SetUniform("u_modelViewMatrix", view);
                mat4 projection = glm.ortho(-(float)TEXTURE_SIZE / 2, (float)TEXTURE_SIZE / 2, -(float)TEXTURE_SIZE / 2, (float)TEXTURE_SIZE / 2, 1.0f, 100.0f);
                this.SetUniform("u_projectionMatrix", projection);
                this.SetUniform("u_waterPlaneLength", (float)this.waterPlaneLength);
            }

            this.viewportSwitch = new ViewportSwitch(0, 0, TEXTURE_SIZE, TEXTURE_SIZE);
        }
    }
}