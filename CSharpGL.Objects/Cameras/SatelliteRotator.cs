using CSharpGL.Maths;
using System;
using System.Drawing;


namespace CSharpGL.Objects.Cameras
{
    /// <summary>
    /// Rotates a camera on a sphere, whose center is camera's Target.
    /// <para>Just like a satellite moves around a fixed star.</para>
    /// </summary>
    public class SatelliteRotator : ICameraRotator
    {
        private Point downPosition = new Point();
        private Size bound = new Size();
        public bool mouseDownFlag = false;
        private float horizontalRotationFactor = 4;
        private float verticalRotationFactor = 4;
        private vec3 up;
        private vec3 back;
        private vec3 right;

        /// <summary>
        /// Rotates a camera on a sphere, whose center is camera's Target.
        /// <para>Just like a satellite moves around a fixed star.</para>
        /// </summary>
        /// <param name="camera"></param>
        public SatelliteRotator(ICamera camera = null)
        {
            this.Camera = camera;
        }


        public override string ToString()
        {
            return string.Format("back:{0}|{3:0.00},up:{1}|{4:0.00},right:{2}|{5:0.00}",
                back, up, right, back.Magnitude(), up.Magnitude(), right.Magnitude());
            //return base.ToString();
        }


        private ICamera originalCamera;

        public ICamera Camera { get; set; }

        public void MouseUp(int x, int y)
        {
            this.mouseDownFlag = false;
        }

        public void MouseMove(int x, int y)
        {
            if (this.mouseDownFlag)
            {
                IViewCamera camera = this.Camera;
                if (camera == null) { return; }

                vec3 back = this.back;
                vec3 right = this.right;
                vec3 up = this.up;
                Size bound = this.bound;
                Point downPosition = this.downPosition;
                {
                    float deltaX = -horizontalRotationFactor * (x - downPosition.X) / bound.Width;
                    float cos = (float)Math.Cos(deltaX);
                    float sin = (float)Math.Sin(deltaX);
                    vec3 newBack = new vec3(
                        back.x * cos + right.x * sin,
                        back.y * cos + right.y * sin,
                        back.z * cos + right.z * sin);
                    back = newBack;
                    right = up.cross(back);
                    back.Normalize();
                    right.Normalize();
                }
                {
                    float deltaY = verticalRotationFactor * (y - downPosition.Y) / bound.Height;
                    float cos = (float)Math.Cos(deltaY);
                    float sin = (float)Math.Sin(deltaY);
                    vec3 newBack = new vec3(
                        back.x * cos + up.x * sin,
                        back.y * cos + up.y * sin,
                        back.z * cos + up.z * sin);
                    back = newBack;
                    up = back.cross(right);
                    back.Normalize();
                    up.Normalize();
                }

                camera.Position = camera.Target +
                    back * (float)((camera.Position - camera.Target).Magnitude());
                camera.UpVector = up;
                this.back = back;
                this.right = right;
                this.up = up;
                this.downPosition.X = x;
                this.downPosition.Y = y;
            }
        }

        public void SetBounds(int width, int height)
        {
            this.bound.Width = width;
            this.bound.Height = height;
        }

        public void MouseDown(int x, int y)
        {
            this.downPosition.X = x;
            this.downPosition.Y = y;
            this.mouseDownFlag = true;
            PrepareCamera();
        }

        private void PrepareCamera()
        {
            var camera = this.Camera;
            if (camera != null)
            {
                vec3 back = camera.Position - camera.Target;
                vec3 right = Camera.UpVector.cross(back);
                vec3 up = back.cross(right);
                back.Normalize();
                right.Normalize();
                up.Normalize();

                this.back = back;
                this.right = right;
                this.up = up;

                if (this.originalCamera == null)
                { this.originalCamera = new Camera(); }
                this.originalCamera.Position = camera.Position;
                this.originalCamera.UpVector = camera.UpVector;
            }
        }

        public void Reset()
        {
            IViewCamera camera = this.Camera;
            if (camera == null) { return; }
            IViewCamera originalCamera = this.originalCamera;
            if (originalCamera == null) { return; }

            camera.Position = originalCamera.Position;
            camera.UpVector = originalCamera.UpVector;
        }
    }
}
