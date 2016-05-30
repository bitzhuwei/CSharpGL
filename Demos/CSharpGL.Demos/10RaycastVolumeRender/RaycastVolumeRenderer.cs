using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// </summary>
    class RaycastVolumeRenderer : RendererBase
    {
        private Renderer backfaceRenderer;
        private Renderer raycastRenderer;
        private uint[] transferFunc1DTexObj = new uint[1];
        private uint[] backface2DTexObj = new uint[1];
        private uint[] vol3DTexObj = new uint[1];
        private uint[] frameBuffer = new uint[1];

        private DepthTestSwitch depthTest;

        private static readonly IBufferable model = new RaycastModel();
        private float g_stepSize = 0.001f;

        public void SetMVP(mat4 mvp)
        {
            this.backfaceRenderer.SetUniform("MVP", mvp);
            this.raycastRenderer.SetUniform("MVP", mvp);
        }

        protected override void DoInitialize()
        {
            InitBackfaceRenderer();

            InitRaycastRenderer();

            initTFF1DTex(@"10RaycastVolumeRender\tff.dat");
            int[] viewport = OpenGL.GetViewport();
            initFace2DTex(viewport[2], viewport[3]);
            initVol3DTex(@"10RaycastVolumeRender\head256.raw", 256, 256, 225);
            initFrameBuffer(viewport[2], viewport[3]);

            this.depthTest = new DepthTestSwitch();

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
            this.raycastRenderer.SetUniform("ExitPoints", new samplerValue(BindTextureTarget.Texture2D, backface2DTexObj[0], OpenGL.GL_TEXTURE1));
            this.raycastRenderer.SetUniform("VolumeTex", new samplerValue(BindTextureTarget.Texture3D, vol3DTexObj[0], OpenGL.GL_TEXTURE2));
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
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, frameBuffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_COLOR_ATTACHMENT0_EXT, OpenGL.GL_TEXTURE_2D, backface2DTexObj[0], 0);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferRenderbufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_DEPTH_ATTACHMENT_EXT, OpenGL.GL_RENDERBUFFER, depthBuffer[0]);
            checkFramebufferStatus();
            //OpenGL.Enable(GL_DEPTH_TEST); 
        }

        private void checkFramebufferStatus()
        {
            uint complete = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>()(OpenGL.GL_FRAMEBUFFER_EXT);
            if (complete != OpenGL.GL_FRAMEBUFFER_COMPLETE_EXT)
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
        }

        private void initFace2DTex(int width, int height)
        {
            OpenGL.GenTextures(1, backface2DTexObj);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, backface2DTexObj[0]);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGBA16F, width, height, 0, OpenGL.GL_RGBA, OpenGL.GL_FLOAT, IntPtr.Zero);
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
        }

        private void InitRaycastRenderer()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"10RaycastVolumeRender\raycasting.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"10RaycastVolumeRender\raycasting.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", "position");
            map.Add("color", "color");
            this.raycastRenderer = new Renderer(model, shaderCodes, map);
            this.raycastRenderer.Initialize();
            this.raycastRenderer.SwitchList.Add(new CullFaceSwitch(CullFaceMode.Back, true));
        }

        private void InitBackfaceRenderer()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"10RaycastVolumeRender\backface.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"10RaycastVolumeRender\backface.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", "position");
            map.Add("color", "color");
            this.backfaceRenderer = new Renderer(model, shaderCodes, map);
            this.backfaceRenderer.Initialize();
            this.backfaceRenderer.SwitchList.Add(new CullFaceSwitch(CullFaceMode.Front, true));
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.depthTest.On();

            // render to texture
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_DRAW_FRAMEBUFFER, frameBuffer[0]);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            this.backfaceRenderer.Render(arg);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);

            this.raycastRenderer.Render(arg);
            // need or need not to resume the state of only one active texture unit?
            // glActiveTexture(GL_TEXTURE1);
            // glBindTexture(GL_TEXTURE_2D, 0);
            // glDisable(GL_TEXTURE_2D);
            // glActiveTexture(GL_TEXTURE2);
            // glBindTexture(GL_TEXTURE_3D, 0);    
            // glDisable(GL_TEXTURE_3D);
            // glActiveTexture(GL_TEXTURE0);
            // glBindTexture(GL_TEXTURE_1D, 0);    
            // glDisable(GL_TEXTURE_1D);
            // glActiveTexture(GL_TEXTURE0);

            // // for test the first pass
            // glBindFramebuffer(GL_READ_FRAMEBUFFER, g_frameBuffer);
            // checkFramebufferStatus();
            // glBindFramebuffer(GL_DRAW_FRAMEBUFFER, 0);
            // glViewport(0, 0, g_winWidth, g_winHeight);
            // glClearColor(0.0, 0.0, 1.0, 1.0);
            // glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            // GL_ERROR();
            // glBlitFramebuffer(0, 0, g_winWidth, g_winHeight,0, 0,
            // 		      g_winWidth, g_winHeight, GL_COLOR_BUFFER_BIT, GL_NEAREST);
            // glBindFramebuffer(GL_FRAMEBUFFER, 0);
            // GL_ERROR();
            this.depthTest.Off();
        }

        protected override void DisposeUnmanagedResources()
        {
            this.backfaceRenderer.Dispose();
            this.raycastRenderer.Dispose();
            OpenGL.DeleteTextures(1, transferFunc1DTexObj);
            OpenGL.DeleteTextures(1, backface2DTexObj);
            OpenGL.DeleteTextures(1, vol3DTexObj);
            OpenGL.DeleteTextures(1, frameBuffer);
        }


    }
}