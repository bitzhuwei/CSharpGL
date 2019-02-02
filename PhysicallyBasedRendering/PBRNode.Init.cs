using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.IO;
using FreeImageAPI;
using System.Runtime.InteropServices;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
        private static GLDelegates.void_uint_uint_uint_uint_int glFramebufferTexture2D;

        static PBRNode()
        {
            glFramebufferTexture2D = GL.Instance.GetDelegateFor("glFramebufferTexture2D", GLDelegates.typeof_void_uint_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_uint_int;

        }

        const int irradianceMapLength = 1024; // 32

        protected override void DoInitialize()
        {
            // init textures.
            this.envCubeMap = LoadEnvCubeMap();
            this.irradianceMap = LoadIrradianceMap();
            this.prefliterMap = LoadPrefliterMap();
            this.brdfLUTTexture = LoadBRDFTexture();
            //this.hdrTexture = LoadHdrEnvironmentMap(@"Texture\hdr\newport_loft.hdr");
            {
                Bitmap bitmap = LoadHdrFormFreeImage(@"Texture\hdr\newport_loft.hdr");
                var storage = new TexImageBitmap(bitmap, GL.GL_RGB16F);
                var texture = new Texture(storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.Initialize();
                this.hdrTexture = texture;
            }

            this.albedoMap = LoadTexture(@"Texture\agedplanks1-albedo.png");
            this.albedoMap.TextureUnitIndex = 3;
            this.normalMap = LoadTexture(@"Texture\agedplanks1-normal4-ue.png");
            this.normalMap.TextureUnitIndex = 4;
            this.metallicMap = LoadTexture(@"Texture\agedplanks1-ao.png");
            this.metallicMap.TextureUnitIndex = 5;
            this.roughnessMap = LoadTexture(@"Texture\agedplanks1-roughness.png");
            this.roughnessMap.TextureUnitIndex = 6;
            this.aoMap = LoadTexture(@"Texture\agedplanks1-ao.png");
            this.aoMap.TextureUnitIndex = 7;

            this.pbrProgram.SetUniform("albedoMap", this.albedoMap);
            this.pbrProgram.SetUniform("normalMap", this.normalMap);
            this.pbrProgram.SetUniform("metallicMap", this.metallicMap);
            this.pbrProgram.SetUniform("roughnessMap", this.roughnessMap);
            this.pbrProgram.SetUniform("aoMap", this.aoMap);

            //设置投影矩阵
            mat4 captureProjection = glm.perspective((float)(Math.PI / 2), 1.0f, 0.1f, 20.0f);
            mat4[] captureView =
	        {
				glm.lookAt(new vec3(0, 0, 0), new vec3(1.0f, 0.0f, 0.0f), new vec3(0.0f, -1.0f, 0.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(-1.0f, 0.0f, 0.0f), new vec3(0.0f, -1.0f, 0.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, 1.0f, 0.0f), new vec3(0.0f, 0.0f, 1.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, -1.0f, 0.0f), new vec3(0.0f, 0.0f, -1.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, 0.0f, 1.0f), new vec3(0.0f, -1.0f, 0.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, 0.0f, -1.0f), new vec3(0.0f, -1.0f, 0.0f)),
	        };

            ViewportSwitch viewportSwitch = new ViewportSwitch(0, 0, 512, 512);
            //转换HDR Equirectangular environmentMap 为 HDR cubeMap
            {
                //创建渲染到CubeMap的FBO
                var fbo = new Framebuffer(512, 512);
                fbo.Bind();
                var rbo = new Renderbuffer(512, 512, GL.GL_DEPTH_COMPONENT24);
                fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                fbo.CheckCompleteness();
                fbo.Unbind();

                viewportSwitch.On();
                ShaderProgram program = this.equiRectangular2CubemapProgram;
                program.SetUniform("equirectangularMap", this.hdrTexture);
                program.SetUniform("ProjMatrix", captureProjection);
                for (uint i = 0; i < 6; ++i)
                {
                    fbo.Bind();
                    CubemapFace face = (CubemapFace)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + i);
                    uint location = 0;
                    int level = 0;
                    fbo.Attach(FramebufferTarget.Framebuffer, location, face, envCubeMap, level);
                    fbo.CheckCompleteness();
                    fbo.Unbind();

                    fbo.Bind();
                    program.Bind();
                    program.SetUniform("ViewMatrix", captureView[i]);
                    program.PushUniforms();
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    renderCube();
                    program.Unbind();
                    fbo.Unbind();

                    envCubeMap.GetImage(face, fbo.Width, fbo.Height).Save(
                        string.Format("envCubeMap.{0}.png", face));
                }
                viewportSwitch.Off();
                fbo.Dispose();
            }
            //创建一个irradianceMap
            {
                var fbo = new Framebuffer(irradianceMapLength, irradianceMapLength);
                fbo.Bind();
                var rbo = new Renderbuffer(irradianceMapLength, irradianceMapLength, GL.GL_DEPTH_COMPONENT24);
                fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                fbo.CheckCompleteness();
                fbo.Unbind();

                //pbr:通过卷积来创建一张irradianceMap来解决diffueIntegral
                viewportSwitch.Width = irradianceMapLength; viewportSwitch.Height = irradianceMapLength;
                viewportSwitch.On();
                ShaderProgram program = this.irradianceProgram;
                program.SetUniform("environmentMap", envCubeMap);
                program.SetUniform("ProjMatrix", captureProjection);
                for (uint i = 0; i < 6; ++i)
                {
                    fbo.Bind();
                    CubemapFace face = (CubemapFace)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + i);
                    uint location = 0;
                    int level = 0;
                    fbo.Attach(FramebufferTarget.Framebuffer, location, face, irradianceMap, level);
                    fbo.CheckCompleteness();
                    fbo.Unbind();

                    fbo.Bind();
                    program.Bind();
                    program.SetUniform("ViewMatrix", captureView[i]);
                    program.PushUniforms();
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    renderCube();
                    program.Unbind();
                    fbo.Unbind();

                    irradianceMap.GetImage(face, fbo.Width, fbo.Height).Save(
                        string.Format("irradianceMap.{0}.png", face));
                }
                viewportSwitch.Off();
                fbo.Dispose();
            }
            //对环境光用蒙特卡洛积分来创建一个prefliterMap贴图
            {
                ShaderProgram program = this.prefliterProgram;
                program.SetUniform("environmentMap", envCubeMap);
                program.SetUniform("ProjMatrix", captureProjection);
                const int maxMipLevels = 5;
                for (int level = 0; level < maxMipLevels; level++)
                {
                    int mipWidth = (int)(128 * Math.Pow(0.5, level));
                    int mipHeight = (int)(128 * Math.Pow(0.5, level));
                    var fbo = new Framebuffer(mipWidth, mipHeight);
                    fbo.Bind();
                    var rbo = new Renderbuffer(mipWidth, mipHeight, GL.GL_DEPTH_COMPONENT24);
                    fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                    fbo.CheckCompleteness();
                    fbo.Unbind();

                    viewportSwitch.Width = mipWidth; viewportSwitch.Height = mipHeight;
                    viewportSwitch.On();
                    float roughness = (float)level / (float)(maxMipLevels - 1);
                    program.SetUniform("roughness", roughness);
                    for (uint j = 0; j < 6; j++)
                    {
                        program.SetUniform("ViewMatrix", captureView[level]);

                        fbo.Bind();
                        CubemapFace face = (CubemapFace)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + j);
                        uint location = 0;
                        fbo.Attach(FramebufferTarget.Framebuffer, location, face, prefliterMap, level);
                        fbo.CheckCompleteness();
                        fbo.Unbind();

                        fbo.Bind();
                        program.Bind();
                        program.PushUniforms();
                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                        renderCube();
                        program.Unbind();
                        fbo.Unbind();

                        prefliterMap.GetImage(face, fbo.Width, fbo.Height, level).Save(
                            string.Format("prefliterMap.{0}.{1}.png", level, face));
                    }
                    viewportSwitch.Off();
                    fbo.Dispose();
                }
                program.Unbind();
            }
            {
                var fbo = new Framebuffer(512, 512);
                fbo.Bind();
                var rbo = new Renderbuffer(512, 512, GL.GL_DEPTH_COMPONENT24);
                fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                fbo.Attach(FramebufferTarget.Framebuffer, brdfLUTTexture, 0u);
                fbo.CheckCompleteness();
                fbo.Unbind();

                fbo.Bind();
                viewportSwitch.Width = 512; viewportSwitch.Height = 512;
                viewportSwitch.On();
                ShaderProgram program = this.brdfProgram;
                program.Bind();
                program.PushUniforms();
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                renderQuad();
                program.Unbind();
                viewportSwitch.Off();
                fbo.Unbind();
                fbo.Dispose();

                brdfLUTTexture.GetImage(fbo.Width, fbo.Height).Save(
                    string.Format("BRDF.GetImage.png"));
            }
        }

        private Texture LoadBRDFTexture()
        {
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RG16F, 512, 512, GL.GL_RG, GL.GL_FLOAT);
            var brdfLUTTexture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            brdfLUTTexture.Initialize();
            return brdfLUTTexture;
        }

        private Texture LoadPrefliterMap()
        {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 128, 128, GL.GL_RGB, GL.GL_FLOAT, dataProvider, 6);
            var prefliterMap = new Texture(storage, new MipmapBuilder(),
               new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
               new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            prefliterMap.Initialize();
            return prefliterMap;
        }

        private Texture LoadIrradianceMap()
        {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, irradianceMapLength, irradianceMapLength, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var irradianceMap = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            irradianceMap.Initialize();
            return irradianceMap;
        }

        private Texture LoadEnvCubeMap()
        {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 512, 512, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var envCubeMap = new Texture(storage,
               new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
               new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            envCubeMap.Initialize();
            return envCubeMap;
        }

        private void renderSphere()
        {
            if (this.sphereBuffers == null)
            {
                this.sphereBuffers = new SphereBuffers();
            }

            this.sphereBuffers.Render();
        }

        private void renderQuad()
        {
            if (this.quadBuffers == null)
            {
                this.quadBuffers = new QuadBuffers();
            }

            this.quadBuffers.Render();
        }

        private void renderCube()
        {
            if (this.cubemapBuffers == null)
            {
                this.cubemapBuffers = new CubemapBuffers();
            }

            this.cubemapBuffers.Render();
        }

        /*
        #?RADIANCE
        # Made with FreeImage 3.9.3
        FORMAT=32-bit_rle_rgbe
        GAMMA=1
        EXPOSURE=0

        -Y 800 +X 1600
        */
        private Texture LoadHdrEnvironmentMap(string filename)
        {
            HdrFile hdrFile = HdrAssetImporter.ReadHdrFile(filename);
            Pixel[] pixels = hdrFile.Colors;
            byte[] bytes = new byte[pixels.Length * 4];
            for (int i = 0; i < pixels.Length; i++)
            {
                //bytes[i * 4 + 0] = pixels[i].r;
                //bytes[i * 4 + 1] = pixels[i].g;
                //bytes[i * 4 + 2] = pixels[i].b;
                //bytes[i * 4 + 3] = pixels[i].a;
            }
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RGB16F, hdrFile.Width, hdrFile.Height, GL.GL_RGBA, GL.GL_BYTE, new ArrayDataProvider<byte>(bytes));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();

            var file = new FileInfo(filename);
            texture.GetImage(hdrFile.Width, hdrFile.Height).Save(
                string.Format("{0}.GetImage.png", file.Name));

            return texture;
        }

        public unsafe Bitmap LoadHdrFormFreeImage(string FileName)
        {
            Bitmap Bmp = null;
            FREE_IMAGE_FORMAT fif = FREE_IMAGE_FORMAT.FIF_UNKNOWN;
            if (FreeImage.IsAvailable() == true)
            {
                fif = FreeImage.GetFileType(FileName, 0);
                if (fif != FREE_IMAGE_FORMAT.FIF_HDR)
                {
                    throw new Exception("不是Hdr格式的图像.");
                }
                fif = FreeImage.GetFIFFromFilename(FileName);
                FIBITMAP Dib = FreeImage.Load(fif, FileName, FREE_IMAGE_LOAD_FLAGS.DEFAULT);
                uint Bpp = FreeImage.GetBPP(Dib);

                if (Bpp != 96)
                {
                    FreeImage.Unload(Dib);
                    throw new Exception("无法支持的Hdr格式.");
                }
                uint Width = FreeImage.GetWidth(Dib);                        //  图像宽度
                uint Height = FreeImage.GetHeight(Dib);                      //  图像高度
                uint Stride = FreeImage.GetPitch(Dib);                       //  图像扫描行的大小,必然是4的整数倍
                IntPtr Bits = FreeImage.GetBits(Dib);

                float* Data = (float*)Bits;
                int Speed, Index;
                byte* Pixel;
                float Value;

                //if (RawData != null) Marshal.FreeHGlobal((IntPtr)RawData);
                //IntPtr RawData = (float*)Marshal.AllocHGlobal((int)Width * (int)Height * 3 * sizeof(float));
                //CopyMemory(RawData, Data, (int)Width * (int)Height * 3 * sizeof(float));

                Bmp = new Bitmap((int)Width, (int)Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData BmpData = Bmp.LockBits(new System.Drawing.Rectangle(0, 0, Bmp.Width, Bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Pixel = (byte*)BmpData.Scan0;

                for (int Y = 0; Y < Height; Y++)
                {
                    Speed = Y * BmpData.Stride;
                    Index = Y * (int)Width * 3;
                    for (int X = 0; X < Width; X++)
                    {
                        Value = (Data[Index + 2] * 255);
                        if (Value > 255)
                            Value = 255;
                        else if (Value < 0)
                            Value = 0;
                        Pixel[Speed] = (byte)Value;
                        Value = (Data[Index + 1] * 255);
                        if (Value > 255)
                            Value = 255;
                        else if (Value < 0)
                            Value = 0;
                        Pixel[Speed + 1] = (byte)Value;
                        Value = (Data[Index + 0] * 255);
                        if (Value > 255)
                            Value = 255;
                        else if (Value < 0)
                            Value = 0;
                        Pixel[Speed + 2] = (byte)Value;
                        Index += 3;
                        Speed += 3;
                    }
                }
                FreeImage.Unload(Dib);
                Bmp.UnlockBits(BmpData);
                Bmp.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
                return Bmp;
            }
            else
                return null;
        }

        private Texture LoadTexture(string filename)
        {
            var bitmap = new Bitmap(filename);
            var storage = new TexImageBitmap(bitmap, GL.GL_RGB);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();

            var file = new FileInfo(filename);
            texture.GetImage(bitmap.Width, bitmap.Height).Save(
                string.Format("{0}.GetImage.png", file.Name));

            return texture;
        }
    }
}
