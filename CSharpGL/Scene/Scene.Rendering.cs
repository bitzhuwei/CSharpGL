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
                this.rootViewPort.Layout();
                // render scene in every view port.
                this.RenderViewPort(this.rootViewPort, this.Canvas.ClientRectangle, pickingGeometryType);
            }
        }

        /// <summary>
        /// render scene in every view port.
        /// </summary>
        /// <param name="viewPort"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="pickingGeometryType"></param>
        private void RenderViewPort(ViewPort viewPort, Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            if (viewPort.Enabled)
            {
                // render in this view port.
                if (viewPort.Visiable)
                {
                    viewPort.On();// limit rendering area.
                    // render scene in this view port.
                    this.Render(viewPort, clientRectangle, pickingGeometryType);
                    viewPort.Off();// cancel limitation.
                }

                // render children viewport.
                foreach (ViewPort item in viewPort.Children)
                {
                    this.RenderViewPort(item, clientRectangle, pickingGeometryType);
                }
            }
        }

        // <param name="mousePosition">mouse position in window coordinate system.</param>
        /// <summary>
        /// Render scene in specified <paramref name="viewPort"/>.
        /// </summary>
        /// <param name="viewPort"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="pickingGeometryType"></param>
        private void Render(ViewPort viewPort, Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            var arg = new RenderEventArgs(clientRectangle, viewPort, pickingGeometryType);

            if (pickingGeometryType != PickingGeometryType.None)// picking mode.
            {
                var color = new vec4(1, 1, 1, 1);
                OpenGL.ClearColor(color.x, color.y, color.z, color.w);

                OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
            }
            else
            {
                vec4 color = viewPort.ClearColor.ToVec4();
                OpenGL.ClearColor(color.x, color.y, color.z, color.w);

                OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
            }
            // render objects.
            SceneObject obj = this.RootObject;
            this.RenderObject(obj, arg);

            // render regular UI.
            this.RootUI.Render(arg);

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
            if (sceneObject.Enabled)
            {
                //sceneObject.DoBeforeRendering();
                GLSwitch[] switchArray = sceneObject.GroupSwitchList.ToArray();
                for (int i = 0; i < switchArray.Length; i++)
                {
                    switchArray[i].On();
                }
                sceneObject.Render(arg);
                SceneObject[] array = sceneObject.Children.ToArray();
                foreach (SceneObject child in array)
                {
                    RenderObject(child, arg);
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