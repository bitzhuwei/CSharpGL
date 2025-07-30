﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace fuluDD01_LayeredEngraving.PNG {
    public partial class RaycastNode {
        private Texture backface2DTexture;
        private int width;
        private int height;
        private Texture volume3DTexture;
        private Framebuffer framebuffer;
        //private float g_stepSize = 0.001f;

        protected override void DoInitialize() {
            base.DoInitialize();
            {
                RenderMethod method = this.RenderUnit.Methods[1];
                GLProgram program = method.Program;
                program.SetUniform("backgroundColor", System.Drawing.Color.SkyBlue.ToVec4());
            }
        }

        private void Resize(int width, int height) {
            if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }
            if (this.framebuffer != null) { this.framebuffer.Dispose(); }

            this.backface2DTexture = InitFace2DTexture(width, height);
            this.framebuffer = InitFramebuffer(width, height, this.backface2DTexture);

            {
                RenderMethod method = this.RenderUnit.Methods[1];
                GLProgram program = method.Program;
                program.SetUniform("canvasSize", new vec2(width, height));
                program.SetUniform("texExitPoint", this.backface2DTexture);
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
            }

            return data;
        }

        private Texture InitVolume3DTexture(byte[] data, int width, int height, int depth) {
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_RGB, width, height, depth, GL.GL_RGB, GL.GL_UNSIGNED_BYTE, new ArrayDataProvider<byte>(data));
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
    }
}
