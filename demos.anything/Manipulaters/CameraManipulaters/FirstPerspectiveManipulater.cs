﻿using System;
using System.Drawing;

//using System.Windows.Forms;

namespace CSharpGL {
    /// <summary>
    /// Manipulate a camera in first-persppective's view.
    /// </summary>
    public class FirstPerspectiveManipulater :
        Manipulater, IMouseHandler, IKeyboardHandler {
        private char backKey;
        private ICamera? camera;
        private IGLCanvas? canvas;

        private char downKey;
        private char frontKey;
        private GLEventHandler<GLKeyPressEventArgs> keyPressEvent;
        private GLMouseButtons lastBindingMouseButtons;
        private ivec2 lastPosition;
        private char leftKey;
        private GLEventHandler<GLMouseEventArgs> mouseDownEvent;
        private bool mouseDownFlag = false;
        private GLEventHandler<GLMouseEventArgs> mouseMoveEvent;
        private GLEventHandler<GLMouseEventArgs> mouseUpEvent;
        private GLEventHandler<GLMouseEventArgs> mouseWheelEvent;
        private char rightKey;
        private char upcaseBackKey;
        private char upcaseDownKey;
        private char upcaseFrontKey;
        private char upcaseLeftKey;
        private char upcaseRightKey;
        private char upcaseUpKey;
        private char upKey;

        /// <summary>
        ///
        /// </summary>
        public FirstPerspectiveManipulater()
            : this(1f, 0.12f, 0.12f, GLMouseButtons.Left | GLMouseButtons.Right) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stepLength"></param>
        /// <param name="horizontalRotationSpeed"></param>
        /// <param name="verticalRotationSpeed"></param>
        /// <param name="bindingMouseButtons"></param>
        public FirstPerspectiveManipulater(
            float stepLength, float horizontalRotationSpeed,
            float verticalRotationSpeed, GLMouseButtons bindingMouseButtons) {
            this.FrontKey = 'w';
            this.BackKey = 's';
            this.LeftKey = 'a';
            this.RightKey = 'd';
            this.UpKey = 'q';
            this.DownKey = 'e';

            this.StepLength = stepLength;
            this.HorizontalRotationSpeed = horizontalRotationSpeed;
            this.VerticalRotationSpeed = verticalRotationSpeed;
            this.BindingMouseButtons = bindingMouseButtons;

            this.keyPressEvent = (((IKeyboardHandler)this).canvas_KeyPress);
            this.mouseDownEvent = (((IMouseHandler)this).canvas_MouseDown);
            this.mouseMoveEvent = (((IMouseHandler)this).canvas_MouseMove);
            this.mouseUpEvent = (((IMouseHandler)this).canvas_MouseUp);
            this.mouseWheelEvent = (((IMouseHandler)this).canvas_MouseWheel);
        }

        /// <summary>
        ///
        /// </summary>
        public char BackKey {
            get { return backKey; }
            set {
                backKey = value.ToString().ToLower()[0];
                upcaseBackKey = value.ToString().ToUpper()[0];
            }
        }

        /// <summary>
        ///
        /// </summary>
        public GLMouseButtons BindingMouseButtons { get; set; }

        /// <summary>
        ///
        /// </summary>
        public char DownKey {
            get { return downKey; }
            set {
                downKey = value.ToString().ToLower()[0];
                upcaseDownKey = value.ToString().ToUpper()[0];
            }
        }

        /// <summary>
        ///
        /// </summary>
        public char FrontKey {
            get { return frontKey; }
            set {
                frontKey = value.ToString().ToLower()[0];
                upcaseFrontKey = value.ToString().ToUpper()[0];
            }
        }

        /// <summary>
        ///
        /// </summary>
        public float HorizontalRotationSpeed { get; set; }

        /// <summary>
        ///
        /// </summary>
        public char LeftKey {
            get { return leftKey; }
            set {
                leftKey = value.ToString().ToLower()[0];
                upcaseLeftKey = value.ToString().ToUpper()[0];
            }
        }

        /// <summary>
        ///
        /// </summary>
        public char RightKey {
            get { return rightKey; }
            set {
                rightKey = value.ToString().ToLower()[0];
                upcaseRightKey = value.ToString().ToUpper()[0];
            }
        }

        /// <summary>
        ///
        /// </summary>
        public float StepLength { get; set; }

        /// <summary>
        ///
        /// </summary>
        public char UpKey {
            get { return upKey; }
            set {
                upKey = value.ToString().ToLower()[0];
                upcaseUpKey = value.ToString().ToUpper()[0];
            }
        }

        /// <summary>
        ///
        /// </summary>
        public float VerticalRotationSpeed { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvas"></param>
        public override void Bind(ICamera camera, IGLCanvas canvas) {
            if (camera == null || canvas == null) { throw new ArgumentNullException(); }

            this.camera = camera;
            this.canvas = canvas;

            canvas.GLKeyPress += this.keyPressEvent;
            canvas.GLMouseDown += this.mouseDownEvent;
            canvas.GLMouseMove += this.mouseMoveEvent;
            canvas.GLMouseUp += this.mouseUpEvent;
            canvas.GLMouseWheel += this.mouseWheelEvent;
        }

        void IKeyboardHandler.canvas_KeyPress(object sender, GLKeyPressEventArgs e) {
            if (this.camera == null || this.canvas == null) { return; }

            bool updated = false;

            if (e.KeyChar == frontKey || e.KeyChar == upcaseFrontKey) {
                vec3 right = this.camera.GetRight();
                vec3 standardFront = this.camera.UpVector.cross(right).normalize();
                this.camera.Position += standardFront * this.StepLength;
                this.camera.Target += standardFront * this.StepLength;
                updated = true;
            }
            else if (e.KeyChar == backKey || e.KeyChar == upcaseBackKey) {
                vec3 right = this.camera.GetRight();
                vec3 standardBack = right.cross(this.camera.UpVector).normalize();
                this.camera.Position += standardBack * this.StepLength;
                this.camera.Target += standardBack * this.StepLength;
                updated = true;
            }
            else if (e.KeyChar == leftKey || e.KeyChar == upcaseLeftKey) {
                vec3 right = this.camera.GetRight();
                vec3 left = (-right).normalize();
                this.camera.Position += left * this.StepLength;
                this.camera.Target += left * this.StepLength;
                updated = true;
            }
            else if (e.KeyChar == rightKey || e.KeyChar == upcaseRightKey) {
                vec3 right = this.camera.GetRight().normalize();
                this.camera.Position += right * this.StepLength;
                this.camera.Target += right * this.StepLength;
                updated = true;
            }
            else if (e.KeyChar == upKey || e.KeyChar == upcaseUpKey) {
                vec3 up = this.camera.UpVector.normalize();
                this.camera.Position += up * this.StepLength;
                this.camera.Target += up * this.StepLength;
                updated = true;
            }
            else if (e.KeyChar == downKey || e.KeyChar == upcaseDownKey) {
                vec3 down = -this.camera.UpVector.normalize();
                this.camera.Position += down * this.StepLength;
                this.camera.Target += down * this.StepLength;
                updated = true;
            }

            if (updated) {
                IGLCanvas canvas = this.canvas;
                if (canvas.RenderTrigger == RenderTrigger.Manual) {
                    //canvas.Repaint();
                }
            }
        }

        void IMouseHandler.canvas_MouseDown(object sender, GLMouseEventArgs e) {
            this.lastBindingMouseButtons = this.BindingMouseButtons;
            if ((e.Button & this.lastBindingMouseButtons) != GLMouseButtons.None) {
                this.mouseDownFlag = true;
                this.lastPosition = e.Location;
            }
        }

        void IMouseHandler.canvas_MouseMove(object sender, GLMouseEventArgs e) {
            if (this.mouseDownFlag
                && ((e.Button & this.lastBindingMouseButtons) != GLMouseButtons.None)
                && (e.X != this.lastPosition.x || e.Y != this.lastPosition.y)) {
                mat4 rotationMatrix = glm.rotate(this.HorizontalRotationSpeed * (e.X - this.lastPosition.x), -this.camera.UpVector);
                var front = new vec4(this.camera.GetFront(), 1.0f);
                vec4 front1 = rotationMatrix * front;
                rotationMatrix = glm.rotate(this.VerticalRotationSpeed * (this.lastPosition.y - e.Y), this.camera.GetRight());
                vec4 front2 = rotationMatrix * front1;
                //front2 = front2.normalize();
                this.camera.Target = this.camera.Position + new vec3(front2);

                this.lastPosition = e.Location;

                var canvas = this.canvas;
                if (canvas != null && canvas.RenderTrigger == RenderTrigger.Manual) {
                    //canvas.Repaint();
                }
            }
        }

        void IMouseHandler.canvas_MouseUp(object sender, GLMouseEventArgs e) {
            if ((e.Button & this.lastBindingMouseButtons) != GLMouseButtons.None) {
                this.mouseDownFlag = false;
            }
        }

        void IMouseHandler.canvas_MouseWheel(object sender, GLMouseEventArgs e) {
            if (this.camera != null) { this.camera.MouseWheel(e.Delta); }

            var canvas = this.canvas;
            if (canvas != null && canvas.RenderTrigger == RenderTrigger.Manual) {
                //canvas.Repaint();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override void Unbind() {
            if (this.canvas != null && (!this.canvas.IsDisposed)) {
                this.canvas.GLKeyPress -= this.keyPressEvent;
                this.canvas.GLMouseDown -= this.mouseDownEvent;
                this.canvas.GLMouseMove -= this.mouseMoveEvent;
                this.canvas.GLMouseUp -= this.mouseUpEvent;
                this.canvas.GLMouseWheel -= this.mouseWheelEvent;
                this.canvas = null;
                this.camera = null;
            }
        }
    }
}