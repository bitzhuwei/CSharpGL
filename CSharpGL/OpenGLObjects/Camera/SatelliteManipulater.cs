using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Rotates a camera on a sphere, whose center is camera's Target.
    /// <para>Just like a satellite moves around a fixed star.</para>
    /// </summary>
    public class SatelliteManipulater : CameraManipulater, ISatelliteManipulater
    {

        private ICamera camera;
        private Control canvas;

        private MouseEventHandler mouseDownEvent;
        private MouseEventHandler mouseMoveEvent;
        private MouseEventHandler mouseUpEvent;
        private MouseEventHandler mouseWheelEvent;

        private Point downPosition = new Point();
        private Size bound = new Size();
        private bool mouseDownFlag = false;
        private vec3 up;
        private vec3 back;
        private vec3 right;

        public float HorizontalRotationFactor { get; set; }

        public float VerticalRotationFactor { get; set; }

        public MouseButtons BindingMouseButtons { get; set; }

        public SatelliteManipulater()
        {
            this.HorizontalRotationFactor = 4;
            this.VerticalRotationFactor = 4;
            this.BindingMouseButtons = MouseButtons.Right;
            this.mouseDownEvent = new MouseEventHandler(((ISatelliteManipulater)this).canvas_MouseDown);
            this.mouseMoveEvent = new MouseEventHandler(((ISatelliteManipulater)this).canvas_MouseMove);
            this.mouseUpEvent = new MouseEventHandler(((ISatelliteManipulater)this).canvas_MouseUp);
            this.mouseWheelEvent = new MouseEventHandler(((ISatelliteManipulater)this).canvas_MouseWheel);
        }

        public override void Bind(ICamera camera, Control canvas)
        {
            if (camera == null || canvas == null) { throw new ArgumentNullException(); }

            this.camera = camera;
            this.canvas = canvas;

            canvas.MouseDown += this.mouseDownEvent;
            canvas.MouseMove += this.mouseMoveEvent;
            canvas.MouseUp += this.mouseUpEvent;
            canvas.MouseWheel += this.mouseWheelEvent;
        }

        public override void Unbind()
        {
            this.camera = null;
            if (this.canvas != null && (!this.canvas.IsDisposed))
            {
                this.canvas.MouseDown -= this.mouseDownEvent;
                this.canvas.MouseMove -= this.mouseMoveEvent;
                this.canvas.MouseUp -= this.mouseUpEvent;
                this.canvas.MouseWheel -= this.mouseWheelEvent;
            }
        }


        public override string ToString()
        {
            return string.Format("back:{0}|{3:0.00},up:{1}|{4:0.00},right:{2}|{5:0.00}",
                back, up, right, back.length(), up.length(), right.length());
        }

        private void PrepareCamera()
        {
            var camera = this.camera;
            if (camera != null)
            {
                vec3 back = camera.Position - camera.Target;
                vec3 right = camera.UpVector.cross(back);
                vec3 up = back.cross(right);

                this.back = back.normalize();
                this.right = right.normalize();
                this.up = up.normalize();
            }
        }


        void ISatelliteManipulater.canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        void ISatelliteManipulater.canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == this.BindingMouseButtons)
            {
                this.mouseDownFlag = false;
            }
        }

        void ISatelliteManipulater.canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownFlag && e.Button == this.BindingMouseButtons)
            {
                IViewCamera camera = this.camera;
                if (camera == null) { return; }

                vec3 back = this.back;
                vec3 right = this.right;
                vec3 up = this.up;
                Size bound = this.bound;
                Point downPosition = this.downPosition;
                {
                    float deltaX = -this.HorizontalRotationFactor * (e.X - downPosition.X) / bound.Width;
                    float cos = (float)Math.Cos(deltaX);
                    float sin = (float)Math.Sin(deltaX);
                    vec3 newBack = new vec3(
                        back.x * cos + right.x * sin,
                        back.y * cos + right.y * sin,
                        back.z * cos + right.z * sin);
                    back = newBack;
                    right = up.cross(back);
                    back = back.normalize();
                    right = right.normalize();
                }
                {
                    float deltaY = this.VerticalRotationFactor * (e.Y - downPosition.Y) / bound.Height;
                    float cos = (float)Math.Cos(deltaY);
                    float sin = (float)Math.Sin(deltaY);
                    vec3 newBack = new vec3(
                        back.x * cos + up.x * sin,
                        back.y * cos + up.y * sin,
                        back.z * cos + up.z * sin);
                    back = newBack;
                    up = back.cross(right);
                    back = back.normalize();
                    up = up.normalize();
                }

                camera.Position = camera.Target +
                    back * (float)((camera.Position - camera.Target).length());
                camera.UpVector = up;
                this.back = back;
                this.right = right;
                this.up = up;
                this.downPosition = e.Location;
            }
        }

        void SetBounds(int width, int height)
        {
            this.bound.Width = width;
            this.bound.Height = height;
        }

        void ISatelliteManipulater.canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == this.BindingMouseButtons)
            {
                this.downPosition = e.Location;
                var control = sender as Control;
                this.SetBounds(control.Width, control.Height);
                this.mouseDownFlag = true;
                PrepareCamera();
            }
        }
    }
}
