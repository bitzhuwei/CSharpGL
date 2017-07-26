using System;
using System.Drawing;

using System.Windows.Forms;

namespace EMGraphics
{
    /// <summary>
    /// Rotates a camera on a sphere, whose center is camera's Target.
    /// <para>Just like a satellite moves around a fixed star.</para>
    /// </summary>
    public class ScreenTranslateManipulater : Manipulater, IMouseHandler
    {
        private vec3 back;
        private ICamera camera;
        private ICanvas canvas;

        private MouseButtons lastBindingMouseButtons;
        private Point lastPosition = new Point();
        private bool mouseDownFlag = false;
        private MouseEventHandler mouseDownEvent;
        private MouseEventHandler mouseMoveEvent;
        private MouseEventHandler mouseUpEvent;
        private vec3 right;
        private vec3 up;

        /// <summary>
        ///
        /// </summary>
        public ScreenTranslateManipulater(MouseButtons bindingMouseButtons = MouseButtons.Middle)
        {
            this.HorizontalRotationFactor = 0.001f;
            this.VerticalRotationFactor = 0.001f;
            this.BindingMouseButtons = bindingMouseButtons;
            this.mouseDownEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseDown);
            this.mouseMoveEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseMove);
            this.mouseUpEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseUp);
        }

        /// <summary>
        ///
        /// </summary>
        public MouseButtons BindingMouseButtons { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float HorizontalRotationFactor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float VerticalRotationFactor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public override void Bind(ICamera camera, ICanvas canvas)
        {
            if (camera == null || canvas == null) { throw new ArgumentNullException(); }

            this.camera = camera;
            this.canvas = canvas;

            canvas.MouseDown += this.mouseDownEvent;
            canvas.MouseMove += this.mouseMoveEvent;
            canvas.MouseUp += this.mouseUpEvent;
        }

        void IMouseHandler.canvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastBindingMouseButtons = this.BindingMouseButtons;
            if ((e.Button & this.lastBindingMouseButtons) != MouseButtons.None)
            {
                this.lastPosition = e.Location;
                this.mouseDownFlag = true;
            }
        }

        void IMouseHandler.canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownFlag
                && ((e.Button & this.lastBindingMouseButtons) != MouseButtons.None))
            {
                IViewCamera camera = this.camera;
                if (camera == null) { return; }

                Point newPosition = e.Location;
                int diffX = newPosition.X - this.lastPosition.X;
                int diffY = newPosition.Y - this.lastPosition.Y;
                mat4 viewMatrix = this.camera.GetViewMatrix();
                mat4 projectionMatrix = this.camera.GetProjectionMatrix();
                vec3 cameraPosition = this.camera.Position;
                vec4 viewport;
                {
                    int[] tmp = OpenGL.GetViewport();
                    viewport = new vec4(tmp[0], tmp[1], tmp[2], tmp[3]);
                }
                vec3 windowPos = glm.project(cameraPosition,
                        viewMatrix, projectionMatrix, viewport);
                var newWindowPos = new vec3(windowPos.x - diffX,
                    windowPos.y + diffY, windowPos.z);
                vec3 newCameraPosition = glm.unProject(newWindowPos,
                    viewMatrix, projectionMatrix, viewport);
                vec3 cameraDiff = newCameraPosition - cameraPosition;
                this.camera.Position = newCameraPosition;
                this.camera.Target += cameraDiff;

                this.lastPosition = newPosition;

                if (this.canvas.RenderTrigger == RenderTrigger.Manual)
                { this.canvas.Repaint(); }
            }
        }

        void IMouseHandler.canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & this.lastBindingMouseButtons) != MouseButtons.None)
            {
                this.mouseDownFlag = false;
            }
        }

        void IMouseHandler.canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            // nothing to do.
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("back:{0}|{3:0.00},up:{1}|{4:0.00},right:{2}|{5:0.00}",
                back, up, right, back.length(), up.length(), right.length());
        }

        /// <summary>
        ///
        /// </summary>
        public override void Unbind()
        {
            if (this.canvas != null && (!this.canvas.IsDisposed))
            {
                this.canvas.MouseDown -= this.mouseDownEvent;
                this.canvas.MouseMove -= this.mouseMoveEvent;
                this.canvas.MouseUp -= this.mouseUpEvent;
                this.canvas = null;
                this.camera = null;
            }
        }

    }
}