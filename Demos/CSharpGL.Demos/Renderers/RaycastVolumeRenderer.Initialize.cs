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

            this.transferFunc1DTexture = InitTFF1DTexture(@"data\tff.dat");
            this.volume3DTexture = initVol3DTex(@"data\head256.raw", 256, 256, 225);

            int[] viewport = OpenGL.GetViewport();
            Resize(viewport[2], viewport[3]);

        }

        private void Resize(int width, int height)
        {
            if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }
            OpenGL.DeleteFrameBuffers(1, frameBuffer);

            this.width = width; this.height = height;
            this.backface2DTexture = initFace2DTex(width, height);
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
            this.raycastRenderer.SetUniform("TransferFunc",
                this.transferFunc1DTexture.ToSamplerValue());
            this.raycastRenderer.SetUniform("ExitPoints",
                this.backface2DTexture.ToSamplerValue());
            this.raycastRenderer.SetUniform("VolumeTex",
                this.volume3DTexture.ToSamplerValue());
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
            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER, OpenGL.GL_COLOR_ATTACHMENT0, OpenGL.GL_TEXTURE_2D,
                //backface2DTexObj[0], 
                this.backface2DTexture.Id,
                0);
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

        private Texture initVol3DTex(string filename, int width, int height, int depth)
        {
            var texture = new Texture(new RaycastVolumeImageBuilder(filename, width, height, depth), BindTextureTarget.Texture3D, new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Linear, TextureFilter.Linear));
            texture.Initialize();

            return texture;
        }

        private Texture initFace2DTex(int width, int height)
        {
            if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }

            var texture = new Texture(new NullImageBuilder(width, height, OpenGL.GL_RGBA16F, OpenGL.GL_RGBA, OpenGL.GL_FLOAT), BindTextureTarget.Texture2D, new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Nearest, TextureFilter.Nearest));
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
            var builder = new ByteImageBuilder(tff, 256);
            var texture = new Texture(builder, BindTextureTarget.Texture1D,
                new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Nearest, TextureFilter.Nearest));
            texture.Initialize();
            return texture;
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