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
            this.RenderViewPort(this.rootViewPort, renderMode, autoClear, pickingGeometryType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewPort"></param>
        /// <param name="renderMode"></param>
        /// <param name="autoClear"></param>
        /// <param name="pickingGeometryType"></param>
        private void RenderViewPort(ViewPort viewPort, RenderModes renderMode, bool autoClear, GeometryType pickingGeometryType)
        {
            if (viewPort.Enabled)
            {
                // render self.
                viewPort.Render(renderMode, autoClear, pickingGeometryType, this);

                // render children viewport.
                foreach (var item in viewPort.Children)
                {
                    this.RenderViewPort(item, renderMode, autoClear, pickingGeometryType);
                }
            }
        }

        // <param name="mousePosition">mouse position in window coordinate system.</param>
        /// <summary>
        ///
        /// </summary>
        /// <param name="renderMode"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="autoClear"></param>
        /// <param name="pickingGeometryType"></param>
        public void Render(RenderModes renderMode, Rectangle clientRectangle,
            //Point mousePosition,
            bool autoClear = true,
            GeometryType pickingGeometryType = GeometryType.Point)
        {
            var arg = new RenderEventArgs(renderMode, clientRectangle, this.Camera, pickingGeometryType);

            lock (this.synObj)
            {
                if (autoClear)
                {
                    vec4 clearColor = this.ClearColor.ToVec4();
                    OpenGL.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);

                    OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
                }
                // render objects.
                SceneObject obj = this.RootObject;
                this.RenderObject(obj, arg);

                // render regular UI.
                this.UIRoot.Render(arg);

                //// render cursor.
                //UICursor cursor = this.Cursor;
                //if (cursor != null && cursor.Enabled)
                //{
                //    cursor.UpdatePosition(mousePosition);
                //    this.cursorRoot.Render(arg);
                //}
            }
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