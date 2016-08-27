using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// </summary>
    partial class RaycastVolumeRenderer : RendererBase
    {
        private Renderer backfaceRenderer;
        private Renderer raycastRenderer;
        private uint[] transferFunc1DTexObj = new uint[1];
        private uint[] backface2DTexObj = new uint[1];
        private uint[] vol3DTexObj = new uint[1];
        private uint[] frameBuffer = new uint[1];

        //private DepthTestSwitch depthTest;

        private static readonly IBufferable model = new RaycastModel();
        private float g_stepSize = 0.001f;

        public void SetMVP(mat4 mvp)
        {
            this.backfaceRenderer.SetUniform("MVP", mvp);
            this.raycastRenderer.SetUniform("MVP", mvp);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            int[] viewport = OpenGL.GetViewport();
            if (this.width != viewport[2] || this.height != viewport[3])
            {
                Resize(viewport[2], viewport[3]);
            }

            mat4 mvp = arg.Camera.GetProjectionMatrix() * arg.Camera.GetViewMatrix();
            this.backfaceRenderer.SetUniform("MVP", mvp);
            this.raycastRenderer.SetUniform("MVP", mvp);

            // render to texture
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER, frameBuffer[0]);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            this.backfaceRenderer.Render(arg);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER, 0);

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
            //this.depthTest.Off();
        }

        protected override void DisposeUnmanagedResources()
        {
            this.backfaceRenderer.Dispose();
            this.raycastRenderer.Dispose();
            OpenGL.DeleteTextures(1, transferFunc1DTexObj);
            OpenGL.DeleteTextures(1, backface2DTexObj);
            OpenGL.DeleteTextures(1, vol3DTexObj);
            OpenGL.DeleteFrameBuffers(1, frameBuffer);
        }


    }
}