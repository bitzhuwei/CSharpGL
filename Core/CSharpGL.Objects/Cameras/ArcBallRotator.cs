using GLM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        vec3 _vectorCenterEye;
        vec3 _vectorUp;
        vec3 _vectorRight;
        float _length, _radiusRadius;
        CameraState cameraState = new CameraState();
        mat4 totalRotation = mat4.identity();
        vec3 _startPosition, _endPosition, _normalVector = new vec3(0, 1, 0);
        int _width;
        int _height;

        float mouseSensitivity = 0.1f;

        public float MouseSensitivity
        {
            get { return mouseSensitivity; }
            set { mouseSensitivity = value; }
        }

        /// <summary>
        /// 标识鼠标是否按下
        /// </summary>
        public bool MouseDownFlag { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }


        const string listenerName = "ArcBallRotator";

        /// <summary>
        /// 用鼠标旋转模型。
        /// </summary>
        /// <param name="camera">当前场景所用的摄像机。</param>
        public ArcBallRotator(ICamera camera)
        {
            this.Camera = camera;

            SetCamera(camera.Position, camera.Target, camera.UpVector);
#if DEBUG
            string filename = typeof(ArcBallRotator).Name;
            string time = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            //if (File.Exists(filename)) { File.Delete(filename); }
            Debug.Listeners.Add(new TextWriterTraceListener(
                string.Format("{0}{1}.log",filename, time), listenerName));
            Debug.WriteLine(DateTime.Now, listenerName);
            Debug.Flush();
#endif
        }

        private void SetCamera(vec3 position, vec3 target, vec3 up)
        {
            _vectorCenterEye = (position - target).normalize();
            _vectorUp = up;
            _vectorRight = _vectorUp.cross(_vectorCenterEye).normalize();
            _vectorUp = _vectorCenterEye.cross(_vectorRight).normalize();

            this.cameraState.position = position;
            this.cameraState.target = target;
            this.cameraState.up = up;
        }

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
            Debug.WriteLine("");
            Debug.WriteLine("=================>MouseDown:", listenerName);
            if (!cameraState.IsSameState(this.Camera))
            {
                SetCamera(this.Camera.Position, this.Camera.Target, this.Camera.UpVector);
                Debug.WriteLine(string.Format(
                    "update camera state: {0}, {1}, {2}",
                    this.cameraState.position, this.cameraState.target, this.cameraState.up), listenerName);
            }

            this._startPosition = GetArcBallPosition(x, y);
            Debug.WriteLine(string.Format("Start position: {0}", this._startPosition), listenerName);

            MouseDownFlag = true;

            Debug.WriteLine("-------------------MouseDown end.", listenerName);
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
                Debug.WriteLine("    =================>MouseMove:", listenerName);
                if (!cameraState.IsSameState(this.Camera))
                {
                    SetCamera(this.Camera.Position, this.Camera.Target, this.Camera.UpVector);
                    Debug.WriteLine(string.Format(
                        "    update camera state: {0}, {1}, {2}",
                        this.cameraState.position, this.cameraState.target, this.cameraState.up), listenerName);
                }

                this._endPosition = GetArcBallPosition(x, y);
                Debug.WriteLine(string.Format(
                    "    End position: {0}", this._endPosition), listenerName);
                var cosAngle = _startPosition.dot(_endPosition) / (_startPosition.Magnitude() * _endPosition.Magnitude());
                if (cosAngle > 1) { cosAngle = 1; }
                else if (cosAngle < -1) { cosAngle = -1; }
                Debug.Write(string.Format("    cos angle: {0}", cosAngle), listenerName);
                var angle = mouseSensitivity * (float)(Math.Acos(cosAngle) / Math.PI * 180);
                Debug.WriteLine(string.Format(
                    ", angle: {0}", angle), listenerName);
                _normalVector = _startPosition.cross(_endPosition).normalize();
                if ((_normalVector.x == 0 && _normalVector.y == 0 && _normalVector.z == 0)
                    || float.IsNaN(_normalVector.x) || float.IsNaN(_normalVector.y) || float.IsNaN(_normalVector.z))
                {
                    Debug.WriteLine("    no movement recorded.", listenerName);
                }
                else
                {
                    Debug.WriteLine(string.Format(
                        "    normal vector: {0}", _normalVector), listenerName);
                    _startPosition = _endPosition;

                    mat4 newRotation = glm.rotate(angle, _normalVector);
                    Debug.WriteLine(string.Format(
                        "    new rotation matrix:   {0}", newRotation), listenerName);
                    this.totalRotation = newRotation * totalRotation;
                    Debug.WriteLine(string.Format(
                        "    total rotation matrix: {0}", totalRotation), listenerName);
                }
                Debug.WriteLine("    -------------------MouseMove end.", listenerName);
            }
        }

        public void MouseUp(int x, int y)
        {
            Debug.WriteLine("=================>MouseUp:", listenerName);
            MouseDownFlag = false;
            Debug.WriteLine("-------------------MouseUp end.", listenerName);
            Debug.WriteLine("");
            Debug.Flush();
        }

        public mat4 GetRotationMatrix()
        {
            return totalRotation;
        }
    }
}
