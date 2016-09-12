using System;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Rotate model using arc-ball method.
    /// </summary>
    public class ArcBallManipulater : Manipulater, IMouseHandler
    {
        private int _height;
        private float _length, _radiusRadius;
        private vec3 _startPosition, _endPosition, _normalVector = new vec3(0, 1, 0);
        private vec3 _vectorBack;
        private vec3 _vectorRight;
        private vec3 _vectorUp;
        private int _width;
        private ICamera camera;
        private CameraState cameraState = new CameraState();
        private ICanvas canvas;

        private bool mouseDownFlag;
        private MouseButtons lastBindingMouseButtons;
        private MouseEventHandler mouseDownEvent;
        private MouseEventHandler mouseMoveEvent;
        private MouseEventHandler mouseUpEvent;
        private MouseEventHandler mouseWheelEvent;
        private mat4 totalRotation = mat4.identity();

        /// <summary>
        /// Rotate model using arc-ball method.
        /// </summary>
        /// <param name="bindingMouseButtons"></param>
        public ArcBallManipulater(MouseButtons bindingMouseButtons = MouseButtons.Left)
        {
            this.MouseSensitivity = 0.1f;
            this.BindingMouseButtons = bindingMouseButtons;

            this.mouseDownEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseDown);
            this.mouseMoveEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseMove);
            this.mouseUpEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseUp);
            this.mouseWheelEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseWheel);
        }

        /// <summary>
        ///
        /// </summary>
        public MouseButtons BindingMouseButtons { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float MouseSensitivity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvas"></param>
        public override void Bind(ICamera camera, ICanvas canvas)
        {
            if (camera == null || canvas == null) { throw new ArgumentNullException(); }

            this.camera = camera;
            this.canvas = canvas;

            canvas.MouseDown += this.mouseDownEvent;
            canvas.MouseMove += this.mouseMoveEvent;
            canvas.MouseUp += this.mouseUpEvent;
            canvas.MouseWheel += this.mouseWheelEvent;

            SetCamera(camera.Position, camera.Target, camera.UpVector);
        }

        /// <summary>
        ///
        /// </summary>
        public mat4 GetRotationMatrix()
        {
            return totalRotation;
        }

        void IMouseHandler.canvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastBindingMouseButtons = this.BindingMouseButtons;
            if ((e.Button & this.lastBindingMouseButtons) != MouseButtons.None)
            {
                var control = sender as Control;
                this.SetBounds(control.Width, control.Height);

                if (!cameraState.IsSameState(this.camera))
                {
                    SetCamera(this.camera.Position, this.camera.Target, this.camera.UpVector);
                }

                this._startPosition = GetArcBallPosition(e.X, e.Y);

                mouseDownFlag = true;
            }
        }

        void IMouseHandler.canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownFlag && ((e.Button & this.lastBindingMouseButtons) != MouseButtons.None))
            {
                if (!cameraState.IsSameState(this.camera))
                {
                    SetCamera(this.camera.Position, this.camera.Target, this.camera.UpVector);
                }

                this._endPosition = GetArcBallPosition(e.X, e.Y);
                var cosAngle = _startPosition.dot(_endPosition) / (_startPosition.length() * _endPosition.length());
                if (cosAngle > 1.0f) { cosAngle = 1.0f; }
                else if (cosAngle < -1) { cosAngle = -1.0f; }
                var angle = MouseSensitivity * (float)(Math.Acos(cosAngle) / Math.PI * 180);
                _normalVector = _startPosition.cross(_endPosition).normalize();
                if (!
                    ((_normalVector.x == 0 && _normalVector.y == 0 && _normalVector.z == 0)
                    || float.IsNaN(_normalVector.x) || float.IsNaN(_normalVector.y) || float.IsNaN(_normalVector.z)))
                {
                    _startPosition = _endPosition;

                    mat4 newRotation = glm.rotate(angle, _normalVector);
                    this.totalRotation = newRotation * totalRotation;
                }
            }
        }

        void IMouseHandler.canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & this.lastBindingMouseButtons) != MouseButtons.None)
            {
                mouseDownFlag = false;
            }
        }

        void IMouseHandler.canvas_MouseWheel(object sender, MouseEventArgs e)
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
            }
        }

        private vec3 GetArcBallPosition(int x, int y)
        {
            float rx = (x - _width / 2) / _length;
            float ry = (_height / 2 - y) / _length;
            float zz = _radiusRadius - rx * rx - ry * ry;
            float rz = (zz > 0 ? (float)Math.Sqrt(zz) : 0.0f);
            var result = new vec3(
                rx * _vectorRight.x + ry * _vectorUp.x + rz * _vectorBack.x,
                rx * _vectorRight.y + ry * _vectorUp.y + rz * _vectorBack.y,
                rx * _vectorRight.z + ry * _vectorUp.z + rz * _vectorBack.z
                );
            //var position = new vec3(rx, ry, rz);
            //var matrix = new mat3(_vectorRight, _vectorUp, _vectorBack);
            //result = matrix * position;

            return result;
        }

        private void SetBounds(int width, int height)
        {
            this._width = width; this._height = height;
            _length = width > height ? width : height;
            var rx = (width / 2) / _length;
            var ry = (height / 2) / _length;
            _radiusRadius = (float)(rx * rx + ry * ry);
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