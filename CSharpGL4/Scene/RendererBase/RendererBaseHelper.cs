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
        public static void PushProjection(this RendererBase renderer, RenderEventArgs arg)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PushMatrix();
            mat4 projection = arg.Scene.Camera.GetProjectionMatrix();
            mat4 view = arg.Scene.Camera.GetViewMatrix();
            GL.Instance.LoadIdentity();
            GL.Instance.MultMatrixf((projection * view).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        public static void PushProjection(this RendererBase renderer, LegacyPickEventArgs arg)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PushMatrix();
            mat4 projection = arg.pickMatrix * arg.scene.Camera.GetProjectionMatrix();
            mat4 view = arg.scene.Camera.GetViewMatrix();
            GL.Instance.LoadIdentity();
            GL.Instance.MultMatrixf((projection * view).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        public static void PushModelView(this RendererBase renderer)
        {
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.PushMatrix();
            GL.Instance.LoadIdentity();
            mat4 modelMatrix = renderer.GetModelMatrix();
            GL.Instance.MultMatrixf(modelMatrix.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        public static void PopProjection(this RendererBase renderer)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PopMatrix();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void PopModelView(this RendererBase renderer)
        {
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.PopMatrix();
        }

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
