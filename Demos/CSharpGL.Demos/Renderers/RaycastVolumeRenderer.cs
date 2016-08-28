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
        private Texture transferFunc1DTexture;
        private uint[] backface2DTexObj = new uint[1];
        private uint[] vol3DTexObj = new uint[1];
        private uint[] frameBuffer = new uint[1];

        private static readonly IBufferable model = new RaycastModel();
        private float g_stepSize = 0.001f;

        public void SetMVP(mat4 mvp)
        {
            this.backfaceRenderer.SetUniform("MVP", mvp);
            this.raycastRenderer.SetUniform("MVP", mvp);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.backfaceRenderer.Dispose();
            this.raycastRenderer.Dispose();
            this.transferFunc1DTexture.Dispose();
            OpenGL.DeleteTextures(1, backface2DTexObj);
            OpenGL.DeleteTextures(1, vol3DTexObj);
            OpenGL.DeleteFrameBuffers(1, frameBuffer);
        }

    }
}