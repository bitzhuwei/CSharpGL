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
            this.backfaceRenderer = InitBackfaceRenderer();
            this.raycastRenderer = InitRaycastRenderer();

            this.transferFunc1DTexture = InitTFF1DTexture(@"data\tff.dat");
            this.volume3DTexture = initVol3DTex(@"data\head256.raw", 256, 256, 225);

            int[] viewport = OpenGL.GetViewport();
            int width = viewport[2], height = viewport[3];
            Resize(width, height);

        }

        private void Resize(int width, int height)
        {
            if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }
            if (framebuffer != null) { framebuffer.Dispose(); }

            this.width = width; this.height = height;
            this.backface2DTexture = InitFace2DTexture(width, height);
            this.framebuffer = InitFramebuffer(width, height);

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

        private Framebuffer InitFramebuffer(int texWidth, int texHeight)
        {
            var framebuffer = new Framebuffer();
            framebuffer.Bind();
            Texture texture = this.backface2DTexture;
            framebuffer.Attach(texture);
            Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(texWidth, texHeight, DepthComponentType.DepthComponent);
            framebuffer.Attach(depthBuffer);
            framebuffer.Unbind();

            return framebuffer;
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
            var texture = new Texture(
                BindTextureTarget.Texture3D,
                new RaycastVolumeImageBuilder(filename, width, height, depth),
                new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Linear, TextureFilter.Linear));
            texture.Initialize();

            return texture;
        }

        private Texture InitFace2DTexture(int width, int height)
        {
            if (this.backface2DTexture != null) { this.backface2DTexture.Dispose(); }

            var texture = new Texture(
                BindTextureTarget.Texture2D,
                new NullImageBuilder(width, height, OpenGL.GL_RGBA16F, OpenGL.GL_RGBA, OpenGL.GL_FLOAT),
                new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Nearest, TextureFilter.Nearest));
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
            var texture = new Texture(
                BindTextureTarget.Texture1D,
                new ByteImageBuilder(tff, 256),
                new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Nearest, TextureFilter.Nearest));
            texture.Initialize();
            return texture;
        }

        private Renderer InitRaycastRenderer()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\raycasting.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\raycasting.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", RaycastModel.strposition);
            map.Add("boundingBox", RaycastModel.strcolor);
            var raycastRenderer = new Renderer(model, shaderCodes, map);
            raycastRenderer.Initialize();
            raycastRenderer.SwitchList.Add(new CullFaceSwitch(CullFaceMode.Back, true));

            return raycastRenderer;
        }

        private Renderer InitBackfaceRenderer()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\backface.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\backface.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", RaycastModel.strposition);
            map.Add("boundingBox", RaycastModel.strcolor);
            var backfaceRenderer = new Renderer(model, shaderCodes, map);
            backfaceRenderer.Initialize();
            backfaceRenderer.SwitchList.Add(new CullFaceSwitch(CullFaceMode.Front, true));

            return backfaceRenderer;
        }

    }
}