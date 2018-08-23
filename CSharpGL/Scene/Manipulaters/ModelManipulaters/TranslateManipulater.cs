using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Rotate model using arc-ball method.
    /// </summary>
    public class TranslateManipulater : Manipulater, IMouseHandler
    {
        private int _width;
        private int _height;
        private Point _lastPosition;
        private vec3 _vectorBack;
        private vec3 _vectorRight;
        private vec3 _vectorUp;
        private ICamera camera;
        private CameraState cameraState = new CameraState();
        private IGLCanvas canvas;

        private bool mouseDownFlag;
        private GLMouseButtons lastBindingMouseButtons;
        private GLEventHandler<GLMouseEventArgs> mouseDownEvent;
        private GLEventHandler<GLMouseEventArgs> mouseMoveEvent;
        private GLEventHandler<GLMouseEventArgs> mouseUpEvent;
        private GLEventHandler<GLMouseEventArgs> mouseWheelEvent;
        private bool isBinded = false;
        private SceneNodeBase renderer;

        /// <summary>
        /// 
        /// </summary>
        public bool IsBinded
        {
            get { return isBinded; }
        }

        /// <summary>
        /// Rotate model using arc-ball method.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="bindingMouseButtons"></param>
        public TranslateManipulater(SceneNodeBase renderer, GLMouseButtons bindingMouseButtons = GLMouseButtons.Left)
        {
            this.renderer = renderer;
            this.MouseSensitivity = 6.0f;
            this.BindingMouseButtons = bindingMouseButtons;

            this.mouseDownEvent = (((IMouseHandler)this).canvas_MouseDown);
            this.mouseMoveEvent = (((IMouseHandler)this).canvas_MouseMove);
            this.mouseUpEvent = (((IMouseHandler)this).canvas_MouseUp);
            this.mouseWheelEvent = (((IMouseHandler)this).canvas_MouseWheel);
        }

        /// <summary>
        ///
        /// </summary>
        public GLMouseButtons BindingMouseButtons { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float MouseSensitivity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvas"></param>
        public override void Bind(ICamera camera, IGLCanvas canvas)
        {
            if (camera == null || canvas == null) { throw new ArgumentNullException(); }

            if (this.isBinded) { return; }

            this.camera = camera;
            this.canvas = canvas;

            canvas.MouseDown += this.mouseDownEvent;
            canvas.MouseMove += this.mouseMoveEvent;
            canvas.MouseUp += this.mouseUpEvent;
            canvas.MouseWheel += this.mouseWheelEvent;

            SetCamera(camera.Position, camera.Target, camera.UpVector);

            this.isBinded = true;
        }

        void IMouseHandler.canvas_MouseDown(object sender, GLMouseEventArgs e)
        {
            this.lastBindingMouseButtons = this.BindingMouseButtons;
            if ((e.Button & this.lastBindingMouseButtons) != GLMouseButtons.None)
            {
                var control = sender as Control;
                this.SetBounds(control.Width, control.Height);

                if (!cameraState.IsSameState(this.camera))
                {
                    SetCamera(this.camera.Position, this.camera.Target, this.camera.UpVector);
                }

                this._lastPosition = new Point(e.X, this.canvas.Height - e.Y - 1);

                mouseDownFlag = true;
            }
        }

        void IMouseHandler.canvas_MouseMove(object sender, GLMouseEventArgs e)
        {
            if (mouseDownFlag && ((e.Button & this.lastBindingMouseButtons) != GLMouseButtons.None))
            {
                if (!cameraState.IsSameState(this.camera))
                {
                    SetCamera(this.camera.Position, this.camera.Target, this.camera.UpVector);
                }

                Point location = new Point(e.X, this.canvas.Height - e.Y - 1);
                Point differenceOnScreen = new Point(location.X - this._lastPosition.X, location.Y - this._lastPosition.Y);
                mat4 model = this.renderer.GetModelMatrix();
                mat4 view = this.camera.GetViewMatrix();
                mat4 projection = this.camera.GetProjectionMatrix();
                vec4 viewport;
                {
                    var result = new int[4];
                    GL.Instance.GetIntegerv((uint)GetTarget.Viewport, result);
                    viewport = new vec4(result[0], result[1], result[2], result[3]);
                }
                var position = new vec3(0.0f);// imangine we have a point at (0, 0, 0).
                vec3 windowPos = glm.project(position, view * model, projection, viewport);
                var newWindowPos = new vec3(windowPos.x + differenceOnScreen.X, windowPos.y + differenceOnScreen.Y, windowPos.z);
                vec3 newPosition = glm.unProject(newWindowPos, view * model, projection, viewport);
                var worldSpacePosition = new vec3(model * new vec4(position, 1.0f));
                var newWorldPosition = new vec3(model * new vec4(newPosition, 1.0f));
                this.renderer.WorldPosition += newWorldPosition - worldSpacePosition;

                this._lastPosition = location;

                IGLCanvas canvas = this.canvas;
                if (canvas != null && canvas.RenderTrigger == RenderTrigger.Manual)
                {
                    canvas.Repaint();
                }
            }
        }

        void IMouseHandler.canvas_MouseUp(object sender, GLMouseEventArgs e)
        {
            if ((e.Button & this.lastBindingMouseButtons) != GLMouseButtons.None)
            {
                mouseDownFlag = false;
            }
        }

        void IMouseHandler.canvas_MouseWheel(object sender, GLMouseEventArgs e)
        {
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
                this.canvas.MouseWheel -= this.mouseWheelEvent;
                this.canvas = null;
                this.camera = null;

                this.isBinded = false;
            }
        }

        private void SetBounds(int width, int height)
        {
            this._width = width; this._height = height;
        }

        private void SetCamera(vec3 position, vec3 target, vec3 up)
        {
            _vectorBack = (position - target).normalize();
            _vectorRight = up.cross(_vectorBack).normalize();
            _vectorUp = _vectorBack.cross(_vectorRight).normalize();

            this.cameraState.position = position;
            this.cameraState.target = target;
            this.cameraState.up = up;
        }

        private class CameraState
        {
            public vec3 position;
            public vec3 target;
            public vec3 up;

            public bool IsSameState(ICamera camera)
            {
                if (camera.Position != this.position) { return false; }
                if (camera.Target != this.target) { return false; }
                if (camera.UpVector != this.up) { return false; }

                return true;
            }
        }
    }
}