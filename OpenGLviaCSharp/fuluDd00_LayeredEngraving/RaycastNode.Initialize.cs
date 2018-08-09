using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace fuluDd00_LayeredEngraving
{
    public partial class RaycastNode
    {
        private Texture transferFunc1DTexture;
        private Texture backface2DTexture;
        private int width;
        private int height;
        private Texture volume3DTexture;
        private Framebuffer framebuffer;
        //private float g_stepSize = 0.001f;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            string folder = System.Windows.Forms.Application.StartupPath;
            {
                string tff = "tff.png";
                this.transferFunc1DTexture = InitTFF1DTexture(tff);
            }

            {
                //string head256 = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "head256.raw");
                //byte[] volumeData = GetVolumeData(head256);
                //this.volume3DTexture = InitVolume3DTexture(volumeData, 256,256,225);
            }
            {
                //string head256 = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "heart125-154-145.raw");
                //byte[] volumeData = GetVolumeData(head256);
                //this.volume3DTexture = InitVolume3DTexture(volumeData, 125,154,145);
            }
            //{
            //    string head256 = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "harmonic16-16-16.raw");
            //    byte[] volumeData = GetVolumeData(head256);
            //    this.volume3DTexture = InitVolume3DTexture(volumeData, 16, 16, 16);
            //}
            {
                int width = 128, height = 128, depth = 128;
                Voxel[] volumeData = VolumeData.GetData(width, height, depth);
                this.volume3DTexture = InitVolume3DTexture(volumeData, width, height, depth);
            }
            {
                // setting uniforms such as
                // ScreenSize
                // StepSize
                // TransferFunc
                // ExitPoints i.e. the backface, the backface hold the ExitPoints of ray casting
                // VolumeTex the texture that hold the volume data i.e. head256.raw
                RenderMethod method = this.RenderUnit.Methods[1];
                ShaderProgram program = method.Program;
                //program.SetUniform("StepSize", this.g_stepSize);
                program.SetUniform("TransferFunc", this.transferFunc1DTexture);
                program.SetUniform("VolumeTex", this.volume3DTexture);
                var clearColor = new float[4];
                //GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);
                //program.SetUniform("backgroundColor", new vec4(clearColor[0], clearColor[1], clearColor[2], clearColor[3]));
                program.SetUniform("backgroundColor", System.Drawing.Color.SkyBlue.ToVec4());
            }
        }

        private void Resize(int width, int height)
        {
            if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }
            if (this.framebuffer != null) { this.framebuffer.Dispose(); }

            this.backface2DTexture = InitFace2DTexture(width, height);
            this.framebuffer = InitFramebuffer(width, height, this.backface2DTexture);

            {
                RenderMethod method = this.RenderUnit.Methods[1];
                ShaderProgram program = method.Program;
                program.SetUniform("ScreenSize", new vec2(width, height));
                program.SetUniform("ExitPoints", this.backface2DTexture);
            }
        }

        private Framebuffer InitFramebuffer(int width, int height, Texture texture)
        {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            framebuffer.Attach(FramebufferTarget.Framebuffer, texture, 0u);
            {
                var depthBuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24);
                framebuffer.Attach(FramebufferTarget.Framebuffer, depthBuffer, AttachmentLocation.Depth);
            }
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }

        private byte[] GetVolumeData(string filename)
        {
            byte[] data;
            //int index = 0;
            //int readCount = 0;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
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

        private Texture InitVolume3DTexture(Voxel[] data, int width, int height, int depth)
        {
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_RGB, width, height, depth, GL.GL_RGB, GL.GL_UNSIGNED_BYTE, new ArrayDataProvider<Voxel>(data));
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
            texture.TextureUnitIndex = 2;

            return texture;
        }

        private Texture InitFace2DTexture(int width, int height)
        {
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RGBA16F, width, height, GL.GL_RGBA, GL.GL_FLOAT);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();
            texture.TextureUnitIndex = 1;

            return texture;
        }

        private Texture InitTFF1DTexture(string filename)
        {
            var bitmap = new System.Drawing.Bitmap(filename);
            const int width = 256;
            var storage = new TexImage1D(GL.GL_RGBA8, width, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();
            texture.TextureUnitIndex = 0;
            bitmap.Dispose();

            return texture;
        }
    }
}
