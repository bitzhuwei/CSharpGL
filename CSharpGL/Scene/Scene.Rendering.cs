using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="renderMode"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="mousePosition">mouse position in window coordinate system.</param>
        public void Render(RenderModes renderMode, Rectangle clientRectangle, Point mousePosition)
        {
            var arg = new RenderEventArgs(renderMode, clientRectangle, this.Camera);

            // render objects.
            {
                SceneObject obj = this.RootObject;
                this.RenderObject(obj, arg);
            }

            // render regular UI.
            this.UIRoot.Render(arg);

            // render cursor.
            UICursor cursor = this.Cursor;
            if (cursor != null && cursor.Enabled)
            {
                cursor.UpdatePosition(mousePosition);
                this.cursorRoot.Render(arg);
            }
        }

        private void RenderObject(SceneObject sceneObject, RenderEventArgs arg)
        {
            sceneObject.Render(arg);
            SceneObject[] array = sceneObject.Children.ToArray();
            foreach (SceneObject child in array)
            {
                RenderObject(child, arg);
            }
        }
    }
}