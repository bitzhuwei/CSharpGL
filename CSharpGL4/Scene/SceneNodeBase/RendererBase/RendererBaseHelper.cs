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
        /// Push and calculate projection+view matrix in legacy OpenGL.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        public static void PushProjectionViewMatrix(this RendererBase renderer, RenderEventArgs arg)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PushMatrix();
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            GL.Instance.LoadIdentity();
            GL.Instance.MultMatrixf((projection * view).ToArray());
        }

        /// <summary>
        /// Push and calculate projection+view matrix in legacy OpenGL for picking.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        public static void PushProjectionViewMatrix(this RendererBase renderer, LegacyPickingEventArgs arg)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PushMatrix();
            mat4 projection = arg.pickMatrix * arg.scene.Camera.GetProjectionMatrix();
            mat4 view = arg.scene.Camera.GetViewMatrix();
            GL.Instance.LoadIdentity();
            GL.Instance.MultMatrixf((projection * view).ToArray());
        }

        /// <summary>
        /// Push and calculate model matrix in legacy OpenGL.
        /// </summary>
        /// <param name="renderer"></param>
        public static void PushModelMatrix(this RendererBase renderer)
        {
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.PushMatrix();
            GL.Instance.LoadIdentity();
            // note: renderer.modelMatrix has already been updated in Scene.Render(RendererBase sceneElement, RenderEventArgs arg);
            GL.Instance.MultMatrixf(renderer.cascadeModelMatrix.ToArray());
        }

        /// <summary>
        /// Pop projection+view matrix.
        /// </summary>
        public static void PopProjectionViewMatrix(this RendererBase renderer)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PopMatrix();
        }

        /// <summary>
        /// Pop model matrix.
        /// </summary>
        public static void PopModelMatrix(this RendererBase renderer)
        {
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.PopMatrix();
        }

    }
}
