using System;
using System.IO;

namespace CSharpGL.Demos
{
    partial class RayTracingRenderer
    {
        private Texture texture;
        private ShaderProgram computeProgram;

        protected override void DoInitialize()
        {
            base.Initialize();

            var texture = new Texture(TextureTarget.Texture2D,
                new NullImageFiller(WIDTH, HEIGHT, OpenGL.GL_RGBA8, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE),
                new SamplerParameters(
                    TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat,
                    TextureFilter.Linear, TextureFilter.Linear));
            texture.Initialize();
            this.texture = texture;
            this.SetUniform("u_texture", texture.ToSamplerValue());

            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\RayTracingRenderer\raytrace.comp.glsl"), ShaderType.ComputeShader);
                this.computeProgram = shaderCodes.CreateProgram();
                g_directionBuffer.glusRaytracePerspectivef(
                    DIRECTION_BUFFER_PADDING, 30.0f, WIDTH, HEIGHT);

            }
        }

    }
}