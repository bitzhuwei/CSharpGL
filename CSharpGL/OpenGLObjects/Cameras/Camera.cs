using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// 摄像机。
    /// </summary>
    public class Camera :
        ICamera,
        IPerspectiveViewCamera, IOrthoViewCamera,
        IViewCamera, IPerspectiveCamera, IOrthoCamera
    {
        ///// <summary>
        ///// 默认目标为vec3(0, 0, 0)
        ///// </summary>
        //public static readonly vec3 defaultTarget = new vec3(0, 0, -1);

        ///// <summary>
        ///// 默认位置为vec3(0, 0, 1)
        ///// </summary>
        //public static readonly vec3 defaultPosition = new vec3(0, 0, 0);

        ///// <summary>
        ///// 默认上方为vec3(0, 1, 0)
        ///// </summary>
        //public static readonly vec3 defaultUpVector = new vec3(0, 1, 0);

        internal Camera() { }

        /// <summary>
        /// 摄像机。
        /// </summary>
        /// <param name="cameraType">类型</param>
        /// <param name="width">OpenGL窗口的宽度</param>
        /// <param name="height">OpenGL窗口的高度</param>
        public Camera(vec3 position, vec3 target, vec3 up, CameraType cameraType, double width, double height)
        {
            this.Position = position;
            this.Target = target;
            this.UpVector = up;

            this.lastWidth = width;
            this.lastHeight = height;

            IPerspectiveCamera perspectiveCamera = this;
            perspectiveCamera.FieldOfView = 60.0f;
            perspectiveCamera.AspectRatio = width / height;
            perspectiveCamera.Near = 0.1;
            perspectiveCamera.Far = 1000;

            const int factor = 100;
            IOrthoCamera orthoCamera = this;
            orthoCamera.Left = -width / 2 / factor;
            orthoCamera.Right = width / 2 / factor;
            orthoCamera.Bottom = -height / 2 / factor;
            orthoCamera.Top = height / 2 / factor;
            orthoCamera.Near = -1000;
            orthoCamera.Far = 1000;

            this.CameraType = cameraType;
        }

        /// <summary>
        /// opengl控件的大小改变时调整camera
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Resize(double width, double height)
        {
            double aspectRatio = width / height;

            IPerspectiveCamera perspectiveCamera = this;
            perspectiveCamera.AspectRatio = aspectRatio;

            IOrthoCamera orthoCamera = this;

            double lastAspectRatio = this.lastWidth / this.lastHeight;
            if (aspectRatio > lastAspectRatio)
            {
                double top = orthoCamera.Top;
                double newRight = top * aspectRatio;
                orthoCamera.Left = -newRight;
                orthoCamera.Right = newRight;
            }
            else if (aspectRatio < lastAspectRatio)
            {
                double right = orthoCamera.Right;
                double newTop = right / aspectRatio;
                orthoCamera.Bottom = -newTop;
                orthoCamera.Top = newTop;
            }

            //const int factor = 100;
            //if (width / 2 / factor != orthoCamera.Right)
            //{
            //    orthoCamera.Left = -width / 2 / factor;
            //    orthoCamera.Right = width / 2 / factor;
            //}
            //if (height / 2 / factor != orthoCamera.Top)
            //{
            //    orthoCamera.Bottom = -height / 2 / factor;
            //    orthoCamera.Top = height / 2 / factor;
            //}
        }

        double lastWidth;
        double lastHeight;

        /// <summary>
        /// Gets or sets world coordinate of the camera's target.
        /// </summary>
        [Description("world coordinate of the camera's target(the point it's looking at)."), Category("Camera")]
        public vec3 Target { get; set; }

        /// <summary>
        /// Gets or sets world coordinate of the camera's up vector.
        /// </summary>
        /// <value>
        /// Up vector.
        /// </value>
        [Description("world coordinate of the camera's up vector."), Category("Camera")]
        public vec3 UpVector { get; set; }

        /// <summary>
        /// Gets or sets world coordinate of the camera 's position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [Description("world coordinate of the camera 's position."), Category("Camera")]
        public vec3 Position { get; set; }

        /// <summary>
        /// camera's perspective type.
        /// </summary>
        public CameraType CameraType { get; set; }

        #region IPerspectiveCamera 成员

        double IPerspectiveCamera.FieldOfView { get; set; }

        double IPerspectiveCamera.AspectRatio { get; set; }

        double IPerspectiveCamera.Near { get; set; }

        double IPerspectiveCamera.Far { get; set; }

        #endregion

        #region IOrthoCamera 成员

        double IOrthoCamera.Left { get; set; }

        double IOrthoCamera.Right { get; set; }

        double IOrthoCamera.Bottom { get; set; }

        double IOrthoCamera.Top { get; set; }

        double IOrthoCamera.Near { get; set; }

        double IOrthoCamera.Far { get; set; }

        #endregion


    }
}
