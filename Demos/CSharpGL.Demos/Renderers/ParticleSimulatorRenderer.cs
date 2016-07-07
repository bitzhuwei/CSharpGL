using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{

    class ParticleSimulatorRenderer : RendererBase
    {

        private ParticleRenderer particleRenderer;
        private ParticleComputeRenderer particleComputeRenderer;

        protected override void DoInitialize()
        {
            {
                IBufferable bufferable = new ParticleModel();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\particleSimulator.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\particleSimulator.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("position", ParticleModel.strPosition);
                var particleRenderer = new ParticleRenderer(bufferable, shaderCodes, map, new DepthTestSwitch(false), new BlendSwitch(BlendingSourceFactor.One, BlendingDestinationFactor.One));
                particleRenderer.Initialize();
                this.particleRenderer = particleRenderer;
            }
            {
                var particleComputeRenderer = new ParticleComputeRenderer(
                    this.particleRenderer.PositionBufferPtr.BufferId, 
                    this.particleRenderer.VelocityBufferPtrId);
                particleComputeRenderer.Initialize();
                this.particleComputeRenderer = particleComputeRenderer;
            }
        }


        protected override void DoRender(RenderEventArg arg)
        {
            this.particleComputeRenderer.Render(arg);

            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            // Clear, select the rendering program and draw a full screen quad
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.particleRenderer.SetUniform("mvp", projection * view);
            this.particleRenderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.particleRenderer.Dispose();
            this.particleComputeRenderer.Dispose();
        }
    }
}