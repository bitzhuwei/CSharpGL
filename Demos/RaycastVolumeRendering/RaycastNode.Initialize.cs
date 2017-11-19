﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RaycastVolumeRendering
{
    public partial class RaycastNode
    {
        private Texture transferFunc1DTexture;
        private Texture backface2DTexture;
        private int width;
        private int height;
        private Texture volume3DTexture;
        private Framebuffer framebuffer;
        private float g_stepSize = 0.001f;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            this.width = viewport[2];
            this.height = viewport[3];

            this.transferFunc1DTexture = InitTFF1DTexture(@"tff.dat");

            byte[] volumeData = GetVolumeData(@"head256.raw", 256, 256, 225);
            this.volume3DTexture = initVol3DTex(volumeData, 256, 256, 225);

            this.Resize(width, height);
        }

        private void RaycastingSetupUniforms(int width, int height)
        {
            // setting uniforms such as
            // ScreenSize
            // StepSize
            // TransferFunc
            // ExitPoints i.e. the backface, the backface hold the ExitPoints of ray casting
            // VolumeTex the texture that hold the volume data i.e. head256.raw
            RenderMethod method = this.RenderUnit.Methods[1];
            ShaderProgram program = method.Program;
            program.SetUniform("ScreenSize", new vec2(width, height));
            program.SetUniform("StepSize", g_stepSize);
            program.SetUniform("TransferFunc", this.transferFunc1DTexture);
            program.SetUniform("ExitPoints", this.backface2DTexture);
            program.SetUniform("VolumeTex", this.volume3DTexture);
            //var clearColor = new float[4];
            //OpenGL.GetFloat(GetTarget.ColorClearValue, clearColor);
            //this.raycastRenderer.glUniform("backgroundColor", clearColor.ToVec4());
            program.SetUniform("backgroundColor", new vec4(0.4f, 0.8f, 1.0f, 1.0f));
        }

        private void Resize(int width, int height)
        {
            if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }
            if (this.framebuffer != null) { this.framebuffer.Dispose(); }

            this.width = width; this.height = height;
            this.backface2DTexture = InitFace2DTexture(width, height);
            this.framebuffer = InitFramebuffer(width, height);

            this.RaycastingSetupUniforms(width, height);
        }

        private Framebuffer InitFramebuffer(int width, int height)
        {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            Texture texture = this.backface2DTexture;
            framebuffer.Attach(FramebufferTarget.Framebuffer, texture, AttachmentLocation.Color);
            //Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(texWidth, texHeight, DepthComponentType.DepthComponent);
            framebuffer.Attach(RenderbufferType.DepthBuffer);
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }
        private byte[] GetVolumeData(string filename, int width, int height, int depth)
        {
            var data = new byte[width * height * depth];
            int index = 0;
            int readCount = 0;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                int unReadCount = (int)fs.Length;
                const int cacheSize = 1024 * 1024;
                do
                {
                    int min = Math.Min(cacheSize, unReadCount);
                    var cache = new byte[min];
                    readCount = br.Read(cache, 0, min);
                    if (readCount != min)
                    { throw new Exception(); }

                    for (int i = 0; i < readCount; i++)
                    {
                        data[index++] = cache[i];
                    }
                    unReadCount -= readCount;
                } while (readCount > 0);
            }

            return data;
        }

        private Texture initVol3DTex(byte[] data, int width, int height, int depth)
        {
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_INTENSITY, width, height, depth, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, new ArrayDataProvider<byte>(data));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();

            return texture;
        }

        private Texture InitFace2DTexture(int width, int height)
        {
            //if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }

            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RGBA16F, width, height, GL.GL_RGBA, GL.GL_FLOAT);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();

            return texture;
        }

        private Texture InitTFF1DTexture(string filename)
        {
            byte[] tff;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                tff = br.ReadBytes((int)fs.Length);
            }

            const int width = 256;
            var storage = new TexImage1D(GL.GL_RGBA8, width, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, new ArrayDataProvider<byte>(tff));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();
            return texture;
        }
    }
}
