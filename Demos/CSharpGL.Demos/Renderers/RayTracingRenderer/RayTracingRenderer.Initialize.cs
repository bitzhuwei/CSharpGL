using System;
using System.IO;

namespace CSharpGL.Demos
{
    partial class RayTracingRenderer
    {
        private Texture texture;
        private ShaderProgram computeProgram;
        private ShaderStorageBufferPtr g_directionSSBO;
        private ShaderStorageBufferPtr g_positionSSBO;
        private ShaderStorageBufferPtr g_stackSSBO;
        private ShaderStorageBufferPtr g_sphereSSBO;
        private ShaderStorageBufferPtr g_pointLightSSBO;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var texture = new Texture(TextureTarget.Texture2D,
                new NullImageFiller(WIDTH, HEIGHT, OpenGL.GL_RGBA8, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE),
                new SamplerParameters(
                    TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat,
                    TextureFilter.Linear, TextureFilter.Linear));
            texture.Initialize();
            this.texture = texture;
            this.SetUniform("u_texture", texture);

            {
                var shaderCodes = new ShaderCode[] { new ShaderCode(File.ReadAllText(@"shaders\RayTracingRenderer\raytrace.comp.glsl"), ShaderType.ComputeShader), };
                this.computeProgram = shaderCodes.CreateProgram();
                this.computeProgram.Bind();
                g_directionBuffer.glusRaytracePerspectivef(
                    DIRECTION_BUFFER_PADDING, 30.0f, WIDTH, HEIGHT);
                using (var buffer = new ShaderStorageBuffer<float>(BufferUsage.StaticDraw))
                {
                    buffer.DoAlloc(g_directionBuffer.Length);
                    unsafe
                    {
                        var array = (float*)buffer.Header.ToPointer();
                        for (int i = 0; i < g_directionBuffer.Length; i++)
                        {
                            array[i] = g_directionBuffer[i];
                        }
                    }
                    this.g_directionSSBO = buffer.GetBufferPtr() as ShaderStorageBufferPtr;
                }
                using (var buffer = new ShaderStorageBuffer<float>(BufferUsage.StaticDraw))
                {
                    buffer.DoAlloc(g_positionBuffer.Length);
                    unsafe
                    {
                        var array = (float*)buffer.Header.ToPointer();
                        for (int i = 0; i < g_positionBuffer.Length; i++)
                        {
                            array[i] = g_positionBuffer[i];
                        }
                    }
                    this.g_positionSSBO = buffer.GetBufferPtr() as ShaderStorageBufferPtr;
                }
                using (var buffer = new ShaderStorageBuffer<float>(BufferUsage.StaticDraw))
                {
                    buffer.DoAlloc(g_stackBuffer.Length);
                    unsafe
                    {
                        var array = (float*)buffer.Header.ToPointer();
                        for (int i = 0; i < g_stackBuffer.Length; i++)
                        {
                            array[i] = g_stackBuffer[i];
                        }
                    }
                    this.g_stackSSBO = buffer.GetBufferPtr() as ShaderStorageBufferPtr;
                }
                using (var buffer = new ShaderStorageBuffer<Sphere>(BufferUsage.StaticDraw))
                {
                    buffer.DoAlloc(g_sphereBuffer.Length);
                    unsafe
                    {
                        var array = (Sphere*)buffer.Header.ToPointer();
                        for (int i = 0; i < g_sphereBuffer.Length; i++)
                        {
                            array[i] = g_sphereBuffer[i];
                        }
                    }
                    this.g_sphereSSBO = buffer.GetBufferPtr() as ShaderStorageBufferPtr;
                }
                using (var buffer = new ShaderStorageBuffer<PointLight>(BufferUsage.StaticDraw))
                {
                    buffer.DoAlloc(g_lightBuffer.Length);
                    unsafe
                    {
                        var array = (PointLight*)buffer.Header.ToPointer();
                        for (int i = 0; i < g_lightBuffer.Length; i++)
                        {
                            array[i] = g_lightBuffer[i];
                        }
                    }
                    this.g_pointLightSSBO = buffer.GetBufferPtr() as ShaderStorageBufferPtr;
                }
            }
        }

    }
}