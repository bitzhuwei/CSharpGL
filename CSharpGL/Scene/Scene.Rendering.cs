using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
        private object synObj = new object();

        /// <summary>
        /// Render this scene.
        /// </summary>
        /// <param name="pickingGeometryType">Specify type of primitive you want to pick or nothing to pick.</param>
        public void Render(
            PickingGeometryType pickingGeometryType = PickingGeometryType.None)
        {
            lock (this.synObj)
            {
                // update view port's location and size.
                // render scene in every view port.
                this.RenderViewPort(this.Canvas.ClientRectangle, pickingGeometryType);
            }
        }

        /// <summary>
        /// render scene in every view port.
        /// </summary>
        /// <param name="clientRectangle"></param>
        /// <param name="pickingGeometryType"></param>
        private void RenderViewPort(Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            if (pickingGeometryType == PickingGeometryType.None)
            {
                RenderNormally(this, clientRectangle);
            }
            else
            {
                RenderColorCoded(this, clientRectangle, pickingGeometryType);
            }
        }

        private void RenderColorCoded(Scene scene, Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            var color = new vec4(1, 1, 1, 1);
            OpenGL.glClearColor(color.x, color.y, color.z, color.w);

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(this.FirstCamera, clientRectangle, pickingGeometryType);
            // render objects.
            // Render all PickableRenderers for color-coded picking.
            List<IPickable> pickableRendererList = scene.Render4Picking(arg);

            //// render regular UI.
            //this.RootUI.Render(arg);

            //// render cursor.
            //UICursor cursor = this.Cursor;
            //if (cursor != null && cursor.Enabled)
            //{
            //    cursor.UpdatePosition(mousePosition);
            //    this.rootCursor.Render(arg);
            //}
        }

        private void RenderNormally(Scene scene, Rectangle clientRectangle)
        {
            var arg = new RenderEventArgs(this.FirstCamera, clientRectangle, PickingGeometryType.None);

            vec4 color = scene.ClearColor.ToVec4();
            OpenGL.glClearColor(color.x, color.y, color.z, color.w);

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            // render objects.
            SceneObject obj = scene.RootObject;
            this.RenderObject(obj, arg);

            // render regular UI.
            scene.RootUI.Render(arg);

            //// render cursor.
            //UICursor cursor = this.Cursor;
            //if (cursor != null && cursor.Enabled)
            //{
            //    cursor.UpdatePosition(mousePosition);
            //    this.rootCursor.Render(arg);
            //}
        }

        /// <summary>
        /// render object recursively.
        /// </summary>
        /// <param name="sceneObject"></param>
        /// <param name="arg"></param>
        private void RenderObject(SceneObject sceneObject, RenderEventArgs arg)
        {
            if (sceneObject.RenderingEnabled)
            {
                //sceneObject.DoBeforeRendering();
                GLState[] switchArray = sceneObject.GroupStateList.ToArray();
                for (int i = 0; i < switchArray.Length; i++)
                {
                    switchArray[i].On();
                }
                sceneObject.Render(arg);
                ITreeNode[] array = sceneObject.Children.ToArray();
                foreach (ITreeNode child in array)
                {
                    RenderObject(child as SceneObject, arg);
                }
                //sceneObject.DoAfterRendering();
                for (int i = switchArray.Length - 1; i >= 0; i--)
                {
                    switchArray[i].Off();
                }
            }
        }
    }
}