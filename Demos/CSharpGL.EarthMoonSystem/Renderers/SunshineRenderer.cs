using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{

    class SunshineRenderer : RendererBase
    {

        private SunshineParticleRenderer particleRenderer;
        private SunshineComputeRenderer particleComputeRenderer;

        protected override void DoInitialize()
        {
            {
                IBufferable bufferable = new SunshineParticleModel();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\SunshineParticle.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\SunshineParticle.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("position", SunshineParticleModel.strPosition);
                var sunshineParticleRenderer = new SunshineParticleRenderer(
                    bufferable, shaderCodes, map, new DepthTestSwitch(false), new BlendSwitch(BlendingSourceFactor.One, BlendingDestinationFactor.One));
                sunshineParticleRenderer.Initialize();
                this.particleRenderer = sunshineParticleRenderer;
            }
            {
                var sunshineComputeRenderer = new SunshineComputeRenderer(
                    this.particleRenderer.PositionBufferPtr.BufferId);
                sunshineComputeRenderer.Initialize();
                this.particleComputeRenderer = sunshineComputeRenderer;
            }
        }

        public void SetMVP(mat4 mvp)
        {
            if (this.particleRenderer != null)
                this.particleRenderer.SetUniform("mvp", mvp);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.particleComputeRenderer.Render(arg);

            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            // Clear, select the rendering program and draw a full screen quad
            //mat4 view = arg.Camera.GetViewMat4();
            //mat4 projection = arg.Camera.GetProjectionMat4();
            //mat4 model = glm.scale(mat4.identity(), new vec3(scale, scale, scale));
            //this.particleRenderer.SetUniform("mvp", projection * view * model);
            this.particleRenderer.Render(arg);

            OpenGL.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.particleRenderer.Dispose();
            this.particleComputeRenderer.Dispose();
        }
    }
}