﻿using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VolumeRendering.Raycast {
    public partial class RaycastNode {
        private Texture texTransfer;
        private Texture texBackface;
        private int width;
        private int height;
        private Texture texVolume;
        private Framebuffer framebuffer;

        protected override void DoInitialize() {
            base.DoInitialize();

            string folder = System.Windows.Forms.Application.StartupPath;
            {
                string tff = "media/textures/tff.png";
                this.texTransfer = InitTFF1DTexture(tff);
            }

            //{
            //    string filename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "filename.raw");
            //    byte[] volumeData = GetVolumeData(filename);
            //    this.volume3DTexture = InitVolume3DTexture(volumeData, 16, 16, 16);
            //}
            {
                int width = 128, height = 128, depth = 128;
                byte[] volumeData = VolumeDataGenerator.GetData(width, height, depth);
                // write volume data to raw file.
                //using (var fs = new FileStream("self.raw", FileMode.Create, FileAccess.Write))
                //using (var bw = new BinaryWriter(fs))
                //{
                //    bw.Write(volumeData);
                //}
                this.texVolume = InitVolume3DTexture(volumeData, width, height, depth);
            }
            {
                RenderMethod method = this.RenderUnit.Methods[1];
                GLProgram program = method.Program;
                program.SetUniform("texTansfer", this.texTransfer);
                program.SetUniform("texVolume", this.texVolume);
                program.SetUniform("backgroundColor", System.Drawing.Color.SkyBlue.ToVec4());
            }
        }

        private void Resize(int width, int height) {
            if (this.texBackface != null) { this.texBackface.Dispose(); }
            if (this.framebuffer != null) { this.framebuffer.Dispose(); }

            this.texBackface = InitFace2DTexture(width, height);
            this.framebuffer = InitFramebuffer(width, height, this.texBackface);

            {
                RenderMethod method = this.RenderUnit.Methods[1];
                GLProgram program = method.Program;
                program.SetUniform("canvasSize", new vec2(width, height));
                program.SetUniform("texExitPoint", this.texBackface);
            }
        }

        private Framebuffer InitFramebuffer(int width, int height, Texture texture) {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            framebuffer.Attach(Framebuffer.Target.Framebuffer, texture, 0u);
            {
                var depthBuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, depthBuffer, AttachmentLocation.Depth);
            }
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }

        private byte[] GetVolumeData(string filename) {
            byte[] data;
            //int index = 0;
            //int readCount = 0;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs)) {
                int unReadCount = (int)fs.Length;
                data = new byte[unReadCount];
                br.Read(data, 0, unReadCount);
                //const int cacheSize = 1024 * 1024;
                //do
                //{
                //    int min = Math.Min(cacheSize, unReadCount);
                //    var cache = new byte[min];
                //    readCount = br.Read(cache, 0, min);
                //    if (readCount != min)
                //    { throw new Exception(); }

                //    for (int i = 0; i < readCount; i++)
                //    {
                //        data[index++] = cache[i];
                //    }
                //    unReadCount -= readCount;
                //} while (readCount > 0);
            }

            return data;
        }

        private Texture InitVolume3DTexture(byte[] data, int width, int height, int depth) {
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_RED, width, height, depth, GL.GL_RED, GL.GL_UNSIGNED_BYTE, new ArrayDataProvider<byte>(data));
            //var texture = new Texture(storage,
            //    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
            //    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
            //    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
            //    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
            //    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            var texture = new Texture(storage, new MipmapBuilder(),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextrueBaseLevel, 0),
                new TexParameteri(TexParameter.PropertyName.TextureMaxLevel, 4));
            texture.Initialize();
            texture.textureUnitIndex = 2;

            return texture;
        }

        private Texture InitFace2DTexture(int width, int height) {
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RGBA16F, width, height, GL.GL_RGBA, GL.GL_FLOAT);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();
            texture.textureUnitIndex = 1;

            return texture;
        }

        private Texture InitTFF1DTexture(string filename) {
            var bitmap = new System.Drawing.Bitmap(filename);
            const int width = 256;
            var winGLBitmap = new WinGLBitmap(bitmap, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var storage = new TexImage1D(GL.GL_RGBA8, width, GL.GL_RGBA,
                GL.GL_UNSIGNED_BYTE, new ImageDataProvider(winGLBitmap));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();
            texture.textureUnitIndex = 0;
            bitmap.Dispose();

            return texture;
        }
    }
}
