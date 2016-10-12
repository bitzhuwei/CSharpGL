using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
        private object synObj = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderMode"></param>
        /// <param name="autoClear"></param>
        /// <param name="pickingGeometryType"></param>
        public void Render(RenderModes renderMode,
            bool autoClear = true,
            GeometryType pickingGeometryType = GeometryType.Point)
        {
            lock (this.synObj)
            {
                this.rootViewPort.Layout();
                this.RenderViewPort(this.rootViewPort, this.Canvas.ClientRectangle, renderMode, autoClear, pickingGeometryType);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewPort"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="renderMode"></param>
        /// <param name="autoClear"></param>
        /// <param name="pickingGeometryType"></param>
        private void RenderViewPort(ViewPort viewPort, Rectangle clientRectangle, RenderModes renderMode, bool autoClear, GeometryType pickingGeometryType)
        {
            if (viewPort.Enabled)
            {
                // render self.
                if (viewPort.Visiable)
                {
                    viewPort.On();
                    this.Render(viewPort, clientRectangle, renderMode, autoClear, pickingGeometryType);
                    viewPort.Off();
                }

                // render children viewport.
                foreach (ViewPort item in viewPort.Children)
                {
                    this.RenderViewPort(item, clientRectangle, renderMode, autoClear, pickingGeometryType);
                }
            }
        }

        // <param name="mousePosition">mouse position in window coordinate system.</param>
        /// <summary>
        ///
        /// </summary>
        /// <param name="viewPort"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="renderMode"></param>
        /// <param name="clearColor"></param>
        /// <param name="autoClear"></param>
        /// <param name="pickingGeometryType"></param>
        private void Render(ViewPort viewPort, Rectangle clientRectangle,
            RenderModes renderMode,
            bool autoClear = true,
            GeometryType pickingGeometryType = GeometryType.Point)
        {
            var arg = new RenderEventArgs(renderMode, clientRectangle, viewPort, pickingGeometryType);

            if (autoClear)
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