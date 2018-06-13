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
        private IGLCanvas canvas;

        private bool mouseDownFlag;
        private GLMouseButtons lastBindingMouseButtons;
        private readonly GLEventHandler<GLMouseEventArgs> mouseDownEvent;
        private readonly GLEventHandler<GLMouseEventArgs> mouseMoveEvent;
        private readonly GLEventHandler<GLMouseEventArgs> mouseUpEvent;
        private readonly GLEventHandler<GLMouseEventArgs> mouseWheelEvent;
        private mat4 totalRotation = mat4.identity();
        private bool isBinded = false;

        /// <summary>
        /// Indicates whether this this manipulater is binded to camera and canvas.
        /// </summary>
        public bool IsBinded
        {
            get { return isBinded; }
        }

        /// <summary>
        /// Occurs when this is bound to a canvas and mouse is down.
        /// </summary>
        public event GLEventHandler<GLMouseEventArgs> MouseDown;
        ///// <summary>
        ///// Occurs when this is bound to a canvas and mouse is moved.
        ///// </summary>
        //public event GLEventHandler<GLMouseEventArgs> MouseMove;
        /// <summary>
        /// Occurs when this is bound to a canvas and mouse is up.
        /// </summary>
        public event GLEventHandler<GLMouseEventArgs> MouseUp;
        /// <summary>
        /// Occurs when this is bound to a canvas and rotated.
        /// </summary>
        public event GLEventHandler<Rotation> Rotated;

        /// <summary>
        /// Rotate model using arc-ball method.
        /// </summary>
        /// <param name="bindingMouseButtons"></param>
        public ArcBallManipulater(GLMouseButtons bindingMouseButtons = GLMouseButtons.Left)
        {
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
        /// </summary>
        public float MouseSensitivity { get; set; }

        /// <summary>
        /// Bind this manipulater to specified <paramref name="camera"/> and <paramref name="canvas"/>.
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

            //SetCamera(camera.Position, camera.Target, camera.UpVector);

            this.isBinded = true;
        }


        void IMouseHandler.canvas_MouseDown(object sender, GLMouseEventArgs e)
        {
            this.lastBindingMouseButtons = this.BindingMouseButtons;
            if ((e.Button & this.lastBindingMouseButtons) != GLMouseButtons.None)
            {
                IGLCanvas canvas = this.canvas;
                this.SetBounds(this.canvas.Width, this.canvas.Height);

                if (!cameraState.IsSameState(this.camera))
                {
                    SetCamera(this.camera.Position, this.camera.Target, this.camera.UpVector);
                }

                this._startPosition = GetArcBallPosition(e.X, e.Y);

                mouseDownFlag = true;

                {
                    var mouseDown = this.MouseDown;
                    if (mouseDown != null)
                    {
                        mouseDown(this, e);
                    }
                }
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

                this._endPosition = GetArcBallPosition(e.X, e.Y);
                var cosRadian = _startPosition.dot(_endPosition) / (_startPosition.length() * _endPosition.length());
                if (cosRadian > 1.0f) { cosRadian = 1.0f; }
                else if (cosRadian < -1) { cosRadian = -1.0f; }
                float angle = MouseSensitivity * (float)(Math.Acos(cosRadian) / Math.PI * 180);
                _normalVector = _startPosition.cross(_endPosition).normalize();
                if (!
                    ((_normalVector.x == 0 && _normalVector.y == 0 && _normalVector.z == 0)
                    || float.IsNaN(_normalVector.x) || float.IsNaN(_normalVector.y) || float.IsNaN(_normalVector.z)))
                {
                    _startPosition = _endPosition;

                    mat4 newRotation = glm.rotate(angle, _normalVector);
                    this.totalRotation = newRotation * this.totalRotation;


                    {
                        var rotated = this.Rotated;
                        if (rotated != null)
                        {
                            Quaternion quaternion = this.totalRotation.ToQuaternion();
                            float angleInDegree;
                            vec3 axis;
                            quaternion.Parse(out angleInDegree, out axis);
                            rotated(this, new Rotation(axis, angleInDegree, e.Button, e.Clicks, e.X, e.Y, e.Delta));
                        }
                    }
                }

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

                {
                    var mouseUp = this.MouseUp;
                    if (mouseUp != null)
                    {
                        mouseUp(this, e);
                    }
                }
            }
        }

        void IMouseHandler.canvas_MouseWheel(object sender, GLMouseEventArgs e)
        {
        }

        /// <summary>
        /// Unbind this manipulater to camera and canvas.
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

        private vec3 GetArcBallPosition(int x, int y)
        {
            float rx = (x - _width / 2.0f) / _length;
            float ry = (_height / 2.0f - y) / _length;
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
            var rx = ((float)(width) / 2) / _length;
            var ry = ((float)(height) / 2) / _length;
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

        /// <summary>
        ///
        /// </summary>
        public mat4 GetRotationMatrix()
        {
            return this.totalRotation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalRotation"></param>
        public void SetRotationMatrix(mat4 totalRotation)
        {
            this.totalRotation = totalRotation;
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

        /// <summary>
        /// 
        /// </summary>
        public class Rotation : GLMouseEventArgs
        {
            /// <summary>
            /// 
            /// </summary>
            public readonly vec3 axis;
            /// <summary>
            /// 
            /// </summary>
            public readonly float angleInDegree;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="axis"></param>
            /// <param name="angleInDegree"></param>
            /// <param name="button">MouseButtons 值之一，它指示曾按下的是哪个鼠标按钮。</param>
            /// <param name="clicks">鼠标按钮曾被按下的次数。</param>
            /// <param name="x">鼠标单击的 x 坐标（以像素为单位，以left为0）。相对<see cref="CtrlRoot"/>而言。</param>
            /// <param name="y">鼠标单击的 y 坐标（以像素为单位，以bottom为0）。相对<see cref="CtrlRoot"/>而言。</param>
            /// <param name="delta">鼠标轮已转动的制动器数的有符号计数。</param>
            public Rotation(vec3 axis, float angleInDegree, GLMouseButtons button, int clicks, int x, int y, int delta)
                : base(button, clicks, x, y, delta)
            {
                this.axis = axis;
                this.angleInDegree = angleInDegree;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("axis:{0}, angle:{1}°", this.axis, this.angleInDegree);
            }
        }

    }
}