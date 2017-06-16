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
            mat4 projectionMatrix = arg.GetProjectionMatrix();
            mat4 viewMatrix = arg.GetViewMatrix();
            GL.Instance.MultMatrixf((projectionMatrix * viewMatrix).ToArray());
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.LoadIdentity();
            mat4 modelMatrix = renderer.GetModelMatrix();
            GL.Instance.MultMatrixf((modelMatrix).ToArray());
        }
    }
}
