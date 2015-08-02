using CSharpGL.Maths;
using System.ComponentModel;

namespace CSharpGL.Objects.Cameras
{
    /// <summary>
    /// projects in perspective view or ortho view.
    /// </summary>
    public class ScientificCamera :
        IScientificCamera,
        IPerspectiveViewCamera, IOrthoViewCamera,
        IViewCamera, IPerspectiveCamera, IOrthoCamera
    {
        static int count = 0;

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Name, count);
            //return base.ToString();
        }
        public ScientificCamera(CameraTypes cameraType = CameraTypes.Perspecitive)
        {
            Name = "Scientific Camera: " + count++;
            IPerspectiveCamera perspectiveCamera = this;
            perspectiveCamera.FieldOfView = 60f;
            perspectiveCamera.AspectRatio = 1f;
            perspectiveCamera.Near = 0.01;
            perspectiveCamera.Far = 1000;

            IOrthoCamera orthoCamera = this;
            orthoCamera.Left = -100;
            orthoCamera.Right = 100;
            orthoCamera.Bottom = -100;
            orthoCamera.Top = 100;
            orthoCamera.Near = -1000;
            orthoCamera.Far = 1000;

            this.Target = new vec3(0, 0, 0);
            this.UpVector = new vec3(0, 1, 0);
            this.Position = new vec3(0, 0, 0);

            this.CameraType = cameraType;
        }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        [Description("The target of the camera (the point it's looking at)"), Category("Camera")]
        public vec3 Target { get; set; }

        /// <summary>
        /// Gets or sets up vector.
        /// </summary>
        /// <value>
        /// Up vector.
        /// </value>
        [Description("The up direction, relative to camera. (Controls tilt)."), Category("Camera")]
        public vec3 UpVector { get; set; }

        /// <summary>
        /// The camera position.
        /// </summary>
        private vec3 position = new vec3(0, 0, 0);

        /// <summary>
        /// Every time a camera is used to project, the projection matrix calculated
        /// and stored here.
        /// </summary>
        private mat4 projectionMatrix = mat4.identity();

        /// <summary>
        /// The screen aspect ratio.
        /// </summary>
        private double aspectRatio = 1.0f;

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [Description("The position of the camera"), Category("Camera")]
        public vec3 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// camera's perspective type.
        /// </summary>
        public CameraTypes CameraType { get; set; }

        #region IPerspectiveCamera 成员

        double IPerspectiveCamera.FieldOfView { get; set; }

        double IPerspectiveCamera.AspectRatio
        {
            get { return aspectRatio; }
            set { aspectRatio = value; }
        }

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

        public void Scale(int delta)
        {
            ScientificCamera camera = this;
            //if (camera.CameraType == CameraTypes.Perspecitive)
            {
                var target2Position = camera.Position - camera.Target;
                if (target2Position.Magnitude() < 0.01)
                {
                    target2Position = target2Position.Normalize();
                    target2Position.x *= 0.01f;
                    target2Position.y *= 0.01f;
                    target2Position.z *= 0.01f;
                }
                var scaledTarget2Position = target2Position * (1 - delta * 0.001f);
                camera.Position = camera.Target + scaledTarget2Position;
                double lengthDiff = scaledTarget2Position.Magnitude() - target2Position.Magnitude();
                // Increase ortho camera's Near/Far property in case the camera's position changes too much.
                IPerspectiveCamera perspectiveCamera = camera;
                perspectiveCamera.Far += lengthDiff;
                //perspectiveCamera.Near += lengthDiff;
                IOrthoCamera orthoCamera = camera;
                orthoCamera.Far += lengthDiff;
                orthoCamera.Near += lengthDiff;
            }
            //else if (camera.CameraType == CameraTypes.Ortho)
            {
                IOrthoCamera orthoCamera = camera;
                double distanceX = orthoCamera.Right - orthoCamera.Left;
                double distanceY = orthoCamera.Top - orthoCamera.Bottom;
                double centerX = (orthoCamera.Left + orthoCamera.Right) / 2;
                double centerY = (orthoCamera.Bottom + orthoCamera.Top) / 2;
                orthoCamera.Left = centerX - distanceX * (1 - delta * 0.001) / 2;
                orthoCamera.Right = centerX + distanceX * (1 - delta * 0.001) / 2;
                orthoCamera.Bottom = centerY - distanceY * (1 - delta * 0.001) / 2;
                orthoCamera.Top = centerX + distanceY * (1 - delta * 0.001) / 2;
            }
        }
    }
}
