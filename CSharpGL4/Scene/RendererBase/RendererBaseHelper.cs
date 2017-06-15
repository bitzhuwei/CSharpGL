using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class RendererBaseHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        public static void LegacyMVP(this RendererBase renderer, RenderEventArgs arg)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.LoadIdentity();
            arg.Scene.Camera.LegacyProjection();
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.LoadIdentity();
            renderer.LegacyTransform();
        }
    }
}
