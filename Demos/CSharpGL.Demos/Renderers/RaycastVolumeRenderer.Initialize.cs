using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{
    partial class RaycastVolumeRenderer 
    {
        int width, height;

        protected override void DoInitialize()
        {
            InitBackfaceRenderer();

            InitRaycastRenderer();

            initTFF1DTex(@"data\tff.dat");
            initVol3DTex(@"data\head256.raw", 256, 256, 225);

            int[] viewport = OpenGL.GetViewport();
            Resize(viewport[2], viewport[3]);
          
        }

        private void Resize(int width, int height)
        {
            OpenGL.DeleteTextures(1, backface2DTexObj);
            OpenGL.DeleteFrameBuffers(1, frameBuffer);

            this.width = width; this.height = height;
            initFace2DTex(width, height);
            initFrameBuffer(width, height);

            RaycastingSetupUniforms();
        }

        private void RaycastingSetupUniforms()
        {
            // setting uniforms such as
            // ScreenSize 
            // StepSize
            // TransferFunc
            // ExitPoints i.e. the backface, the backface hold the ExitPoints of ray casting
            // VolumeTex the texture that hold the volume data i.e. head256.raw
            int[] viewport = OpenGL.GetViewport();
            this.raycastRenderer.SetUniform("ScreenSize", new vec2(viewport[2], viewport[3]));
            this.raycastRenderer.SetUniform("StepSize", g_stepSize);
            this.raycastRenderer.SetUniform("TransferFunc", new samplerValue(BindTextureTarget.Texture1D, transferFunc1DTexObj[0], OpenGL.GL_TEXTURE0));
            this.raycastRenderer.SetUniform("ExitPoints", new samplerValue(BindTextureTarget.Texture2D, backface2DTexObj[0], OpenGL.GL_TEXTURE0));
            this.raycastRenderer.SetUniform("VolumeTex", new samplerValue(BindTextureTarget.Texture3D, vol3DTexObj[0], OpenGL.GL_TEXTURE0));
            var clearColor = new float[4];
            OpenGL.GetFloat(GetTarget.ColorClearValue, clearColor);
            this.raycastRenderer.SetUniform("backgroundColor", clearColor.ToVec4());
        }

        private void initFrameBuffer(int texWidth, int texHeight)
        {
            // create a depth buffer for our framebuffer
            var depthBuffer = new uint[1];
            OpenGL.GetDelegateFor<OpenGL.glGenRenderbuffersEXT>()(1, depthBuffer);
            OpenGL.GetDelegateFor<OpenGL.glBindRenderbufferEXT>()(OpenGL.GL_RENDERBUFFER, depthBuffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glRenderbufferStorageEXT>()(OpenGL.GL_RENDERBUFFER, OpenGL.GL_DEPTH_COMPONENT, texWidth, texHeight);

            // attach the texture and the depth buffer to the framebuffer
            OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>()(1, frameBuffer);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER, frameBuffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER, OpenGL.GL_COLOR_ATTACHMENT0, OpenGL.GL_TEXTURE_2D, backface2DTexObj[0], 0);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferRenderbufferEXT>()(OpenGL.GL_FRAMEBUFFER, OpenGL.GL_DEPTH_ATTACHMENT, OpenGL.GL_RENDERBUFFER, depthBuffer[0]);
            checkFramebufferStatus();
            //OpenGL.Enable(GL_DEPTH_TEST); 
        }

        private void checkFramebufferStatus()
        {
            uint complete = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>()(OpenGL.GL_FRAMEBUFFER);
            if (complete != OpenGL.GL_FRAMEBUFFER_COMPLETE)
            {
                throw new Exception("framebuffer is not complete");
            }
        }

        private void initVol3DTex(string filename, int width, int height, int depth)
        {
            var data = new UnmanagedArray<byte>(width * height * depth);
            unsafe
            {
                int index = 0;
                int readCount = 0;
                byte* array = (byte*)data.Header.ToPointer();
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
                            array[index++] = cache[i];
                        }
                        unReadCount -= readCount;
                    } while (readCount > 0);
                }
            }

            OpenGL.GenTextures(1, vol3DTexObj);
            // bind 3D texture target
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_3D, vol3DTexObj[0]);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_3D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_LINEAR);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_3D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_LINEAR);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_3D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_3D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_3D, OpenGL.GL_TEXTURE_WRAP_R, (int)OpenGL.GL_REPEAT);
            // pixel transfer happens here from client to OpenGL server
            OpenGL.PixelStorei(OpenGL.GL_UNPACK_ALIGNMENT, 1);
            OpenGL.TexImage3D(OpenGL.GL_TEXTURE_3D, 0, (int)OpenGL.GL_INTENSITY,
                width, height, depth, 0,
                OpenGL.GL_LUMINANCE, OpenGL.GL_UNSIGNED_BYTE, data.Header);
            data.Dispose();
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_3D, 0);
        }

        private void initFace2DTex(int width, int height)
        {
            OpenGL.DeleteTextures(1, backface2DTexObj);
            OpenGL.GenTextures(1, backface2DTexObj);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, backface2DTexObj[0]);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGBA16F, width, height, 0, OpenGL.GL_RGBA, OpenGL.GL_FLOAT, IntPtr.Zero);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
        }

        private void initTFF1DTex(string filename)
        {
            // read in the user defined data of transfer function
            byte[] tff;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                tff = br.ReadBytes((int)fs.Length);
            }
            OpenGL.GenTextures(1, transferFunc1DTexObj);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_1D, transferFunc1DTexObj[0]);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.PixelStorei(OpenGL.GL_UNPACK_ALIGNMENT, 1);
            OpenGL.TexImage1D(OpenGL.GL_TEXTURE_1D, 0, OpenGL.GL_RGBA8, 256, 0, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, tff);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_1D, 0);
        }

        private void InitRaycastRenderer()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\raycasting.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\raycasting.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add(RaycastModel.strPosition, RaycastModel.strPosition);
            map.Add(RaycastModel.strBoundingBox, RaycastModel.strBoundingBox);
            this.raycastRenderer = new Renderer(model, shaderCodes, map);
            this.raycastRenderer.Initialize();
            this.raycastRenderer.SwitchList.Add(new CullFaceSwitch(CullFaceMode.Back, true));
        }

        private void InitBackfaceRenderer()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\backface.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\backface.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add(RaycastModel.strPosition, RaycastModel.strPosition);
            map.Add(RaycastModel.strBoundingBox, RaycastModel.strBoundingBox);
            this.backfaceRenderer = new Renderer(model, shaderCodes, map);
            this.backfaceRenderer.Initialize();
            this.backfaceRenderer.SwitchList.Add(new CullFaceSwitch(CullFaceMode.Front, true));
        }

    }
}