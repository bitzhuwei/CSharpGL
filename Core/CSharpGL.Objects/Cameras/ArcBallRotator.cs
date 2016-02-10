using GLM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Cameras
{
    /// <summary>
    /// 用鼠标旋转模型。
    /// </summary>
    public class ArcBallRotator
    {
        private CameraState cameraState;

        /// <summary>
        /// 用鼠标旋转模型。
        /// </summary>
        /// <param name="camera">当前场景所用的摄像机。</param>
        public ArcBallRotator(ICamera camera)
        {
            this.Camera = camera;
            this.cameraState = new CameraState() { position = camera.Position, target = camera.Target, up = camera.UpVector, };

            SetCamera(camera.Position, camera.Target, camera.UpVector);
            this.sw = new StreamWriter("arcballRotator.log", false);
        }
        ~ArcBallRotator()
        {
            //try
            //{
            //    sw.Flush();
            //    //this.sw.Close();
            //    this.sw.Dispose();
            //    //this.sw = null;
            //}
            //catch (Exception)
            //{
            //}
        }
        private void SetCamera(vec3 position, vec3 target, vec3 up)
        {
            _vectorCenterEye = position - target;
            _vectorCenterEye.Normalize();
            _vectorUp = up;
            _vectorRight = _vectorUp.cross(_vectorCenterEye);
            _vectorRight.Normalize();
            _vectorUp = _vectorCenterEye.cross(_vectorRight);
            _vectorUp.Normalize();

            this.cameraState.position = position;
            this.cameraState.target = target;
            this.cameraState.up = up;
        }


        /// <summary>
        /// 标识鼠标是否按下
        /// </summary>
        public bool MouseDownFlag { get; private set; }


        class CameraState
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

        private Point downPosition = new Point();
        private Size bound = new Size();

        private float horizontalRotationFactor = 4;
        private float verticalRotationFactor = 4;

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }
        float _length, _radiusRadius;
        mat4 _lastTransform = mat4.identity();
        vec3 _startPosition, _endPosition, _normalVector = new vec3(0, 1, 0);
        int _width;
        int _height;


        public void SetBounds(int width, int height)
        {
            this._width = width; this._height = height;
            _length = width > height ? width : height;
            var rx = (width / 2) / _length;
            var ry = (height / 2) / _length;
            _radiusRadius = (float)(rx * rx + ry * ry);
        }

        /// <summary>
        /// 必须先调用<see cref="SetBounds"/>()方法。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseDown(int x, int y)
        {
            sw.WriteLine();
            sw.WriteLine("=================>MouseDown:");
            if (!cameraState.IsSameState(this.Camera))
            {
                SetCamera(this.Camera.Position, this.Camera.Target, this.Camera.UpVector);
                sw.WriteLine("update camera state: {0}, {1}, {2}", this.cameraState.position, this.cameraState.target, this.cameraState.up);
            }

            this._startPosition = GetArcBallPosition(x, y);
            sw.WriteLine("Start position: {0}", this._startPosition);

            MouseDownFlag = true;

            sw.WriteLine("-------------------MouseDown end.");
        }

        private vec3 GetArcBallPosition(int x, int y)
        {
            var rx = (x - _width / 2) / _length;
            var ry = (_height / 2 - y) / _length;
            var zz = _radiusRadius - rx * rx - ry * ry;
            var rz = (zz > 0 ? Math.Sqrt(zz) : 0);
            var result = new vec3(
                (float)(rx * _vectorRight.x + ry * _vectorUp.x + rz * _vectorCenterEye.x),
                (float)(rx * _vectorRight.y + ry * _vectorUp.y + rz * _vectorCenterEye.y),
                (float)(rx * _vectorRight.z + ry * _vectorUp.z + rz * _vectorCenterEye.z)
                );
            return result;
        }


        public void MouseMove(int x, int y)
        {
            if (MouseDownFlag)
            {
                sw.WriteLine("    =================>MouseMove:");
                if (!cameraState.IsSameState(this.Camera))
                {
                    SetCamera(this.Camera.Position, this.Camera.Target, this.Camera.UpVector);
                    sw.WriteLine("    update camera state: {0}, {1}, {2}", this.cameraState.position, this.cameraState.target, this.cameraState.up);
                }

                this._endPosition = GetArcBallPosition(x, y);
                sw.WriteLine("    End position: {0}", this._endPosition);
                var cosAngle = _startPosition.dot(_endPosition) / (_startPosition.Magnitude() * _endPosition.Magnitude());
                if (cosAngle > 1) { cosAngle = 1; }
                else if (cosAngle < -1) { cosAngle = -1; }
                sw.Write("    cos angle: {0}", cosAngle);
                var angle = mouseSensitivity * (float)(Math.Acos(cosAngle) / Math.PI * 180);
                sw.WriteLine(", angle: {0}", angle);
                _normalVector = _startPosition.cross(_endPosition);
                if (_normalVector.x == 0 && _normalVector.y == 0 && _normalVector.z == 00)
                {
                    sw.WriteLine("    no movement recorded.");
                }
                else
                {
                    //_normalVector.Normalize();
                    sw.WriteLine("    normal vector: {0}", _normalVector);
                    _startPosition = _endPosition;

                    mat4 newRotation = glm.rotate(angle, _normalVector);
                    sw.WriteLine("    new rotation matrix:   {0}", newRotation);
                    mat4 totalRotation = newRotation * _lastTransform;
                    _lastTransform = totalRotation;
                    sw.WriteLine("    total rotation matrix: {0}", _lastTransform);
                }
                sw.WriteLine("    -------------------MouseMove end.");
            }
        }

        public void MouseUp(int x, int y)
        {
            sw.WriteLine("=================>MouseUp:");
            MouseDownFlag = false;
            sw.WriteLine("-------------------MouseUp end.");
            sw.WriteLine();
            sw.Flush();
        }

        public mat4 GetRotationMatrix()
        {
            return _lastTransform;
        }



        private vec3 _vectorCenterEye;
        private vec3 _vectorUp;
        private vec3 _vectorRight;
        private float mouseSensitivity = 1.0f;
        private StreamWriter sw;

    }
}
