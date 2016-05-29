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
    class RaycastVolumeRender : RendererBase
    {
        private Renderer backfaceRenderer;
        private Renderer raycastRenderer;
        private uint g_tff1DTexObj;
        private uint g_face2DTexObj;
        private uint g_vol3DTexObj;
        private uint[] g_frameBuffer = new uint[1];

        private DepthTestSwitch depthTest;

        private static readonly IBufferable model = new RaycastModel();

        protected override void DoInitialize()
        {
            InitBackfaceRenderer();

            InitRaycastRenderer();

            g_tff1DTexObj = initTFF1DTex(@"10RaycastVolumeRender\tff.dat");
            int[] viewport = OpenGL.GetViewport();
            g_face2DTexObj = initFace2DTex(viewport[2], viewport[3]);
            g_vol3DTexObj = initVol3DTex(@"10RaycastVolumeRender\head256.raw", 256, 256, 225);
            initFrameBuffer(g_face2DTexObj, viewport[2], viewport[3]);

            this.depthTest = new DepthTestSwitch();
        }

        private void initFrameBuffer(uint texObj, int texWidth, int texHeight)
        {
            // create a depth buffer for our framebuffer
            var depthBuffer = new uint[1];
            OpenGL.GetDelegateFor<OpenGL.glGenRenderbuffersEXT>()(1, depthBuffer);
            OpenGL.GetDelegateFor<OpenGL.glBindRenderbufferEXT>()(OpenGL.GL_RENDERBUFFER, depthBuffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glRenderbufferStorageEXT>()(OpenGL.GL_RENDERBUFFER, OpenGL.GL_DEPTH_COMPONENT, texWidth, texHeight);

            // attach the texture and the depth buffer to the framebuffer
            OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>()(1, g_frameBuffer);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, g_frameBuffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_COLOR_ATTACHMENT0_EXT, OpenGL.GL_TEXTURE_2D, texObj, 0);
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

        private uint initVol3DTex(string filename, int width, int height, int depth)
        {
            var data = new UnmanagedArray<byte>(width * height * depth);
            unsafe
            {
                int index = 0;
                byte* array = (byte*)data.Header.ToPointer();
                using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                using (var br = new BinaryReader(fs))
                {
                    const int cacheSize = 1024 * 1024;
                    var cache = new byte[cacheSize];
                    int count = br.Read(cache, index, cacheSize);
                    for (int i = 0; i < count; i++)
                    {
                        array[i + index] = cache[i];
                    }
                    index += count;
                }
            }

            var texture = new uint[1];
            OpenGL.GenTextures(1, texture);
            // bind 3D texture target
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_3D, texture[0]);
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
            return texture[0];
        }

        private uint initFace2DTex(int width, int height)
        {
            var backFace2DTex = new uint[1];
            OpenGL.GenTextures(1, backFace2DTex);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, backFace2DTex[0]);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGBA16F, width, height, 0, OpenGL.GL_RGBA, OpenGL.GL_FLOAT, IntPtr.Zero);
            return backFace2DTex[0];
        }

        private uint initTFF1DTex(string filename)
        {
            // read in the user defined data of transfer function
            byte[] tff;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                tff = br.ReadBytes((int)fs.Length);
            }
            var tff1DTex = new uint[1];
            OpenGL.GenTextures(1, tff1DTex);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_1D, tff1DTex[0]);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_REPEAT);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.PixelStorei(OpenGL.GL_UNPACK_ALIGNMENT, 1);
            OpenGL.TexImage1D(OpenGL.GL_TEXTURE_1D, 0, OpenGL.GL_RGBA8, 256, 0, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, tff);
            return tff1DTex[0];
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
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        protected override void DisposeUnmanagedResources()
        {
            this.backfaceRenderer.Dispose();
            this.raycastRenderer.Dispose();
        }


    }
}