using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public static class RendererBaseHelper {
        /// <summary>
        /// Push and calculate projection+view matrix in legacy OpenGL.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="arg"></param>
        public unsafe static void PushProjectionViewMatrix(this SceneNodeBase node, RenderEventArgs arg) {
            var gl = GL.current; if (gl != null) {
                gl.glMatrixMode(GL.GL_PROJECTION);
                gl.glPushMatrix();
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                gl.glLoadIdentity();
                gl.glMultMatrixf((projection * view).ToArray());
            }
        }

        /// <summary>
        /// Push and calculate projection+view matrix in legacy OpenGL for picking.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="arg"></param>
        public unsafe static void PushProjectionViewMatrix(this SceneNodeBase node, LegacyPickingEventArgs arg) {
            var gl = GL.current; if (gl != null) {
                gl.glMatrixMode(GL.GL_PROJECTION);
                gl.glPushMatrix();
                mat4 projection = arg.pickMatrix * arg.scene.camera.GetProjectionMatrix();
                mat4 view = arg.scene.camera.GetViewMatrix();
                gl.glLoadIdentity();
                gl.glMultMatrixf((projection * view).ToArray());
            }
        }

        /// <summary>
        /// Push and calculate model matrix in legacy OpenGL.
        /// </summary>
        /// <param name="node"></param>
        public unsafe static void PushModelMatrix(this SceneNodeBase node) {
            var gl = GL.current; if (gl != null) {
                gl.glMatrixMode(GL.GL_MODELVIEW);
                gl.glPushMatrix();
                gl.glLoadIdentity();
                // note: node.modelMat has already been updated in Scene.Render(RendererBase sceneElement, RenderEventArgs arg);
                gl.glMultMatrixf(node.cascadeModelMatrix.ToArray());
            }
        }

        /// <summary>
        /// Pop projection+view matrix.
        /// </summary>
        public unsafe static void PopProjectionViewMatrix(this SceneNodeBase node) {
            var gl = GL.current; if (gl != null) {
                gl.glMatrixMode(GL.GL_PROJECTION);
                gl.glPopMatrix();
            }
        }

        /// <summary>
        /// Pop model matrix.
        /// </summary>
        public unsafe static void PopModelMatrix(this SceneNodeBase node) {
            var gl = GL.current; if (gl != null) {
                gl.glMatrixMode(GL.GL_MODELVIEW);
                gl.glPopMatrix();
            }
        }

    }
}
