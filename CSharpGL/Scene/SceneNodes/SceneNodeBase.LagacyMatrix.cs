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
        /// <param name="node"></param>
        /// <param name="arg"></param>
        public static void PushProjectionViewMatrix(this SceneNodeBase node, RenderEventArgs arg)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PushMatrix();
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            GL.Instance.LoadIdentity();
            GL.Instance.MultMatrixf((projection * view).ToArray());
        }

        /// <summary>
        /// Push and calculate projection+view matrix in legacy OpenGL for picking.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="arg"></param>
        public static void PushProjectionViewMatrix(this SceneNodeBase node, LegacyPickingEventArgs arg)
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
        /// <param name="node"></param>
        public static void PushModelMatrix(this SceneNodeBase node)
        {
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.PushMatrix();
            GL.Instance.LoadIdentity();
            // note: node.modelMat has already been updated in Scene.Render(RendererBase sceneElement, RenderEventArgs arg);
            GL.Instance.MultMatrixf(node.cascadeModelMatrix.ToArray());
        }

        /// <summary>
        /// Pop projection+view matrix.
        /// </summary>
        public static void PopProjectionViewMatrix(this SceneNodeBase node)
        {
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PopMatrix();
        }

        /// <summary>
        /// Pop model matrix.
        /// </summary>
        public static void PopModelMatrix(this SceneNodeBase node)
        {
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.PopMatrix();
        }

    }
}
