namespace CSharpGL {
    /// <summary>
    /// set and reset viewport using glViewport();
    /// </summary>
    public unsafe class ViewportSwitch : GLSwitch {
        private int originalX;
        private int originalY;
        private int originalWidth;
        private int originalHeight;

        /// <summary>
        ///
        /// </summary>
        public int x;

        /// <summary>
        ///
        /// </summary>
        public int y;

        /// <summary>
        ///
        /// </summary>
        public int width;

        /// <summary>
        ///
        /// </summary>
        public int height;


        // Activator needs a non-parameter constructor.
        /// <summary>
        /// set and reset viewport using glViewport();
        /// </summary>
        public ViewportSwitch() {
            var gl = GL.current; if (gl == null) { return; }
            var viewport = stackalloc GLint[4];
            gl.glGetIntegerv((GLenum)GetTarget.Viewport, viewport);

            this.Init(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        /// <summary>
        /// set and reset viewport using glViewport();
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public ViewportSwitch(int x, int y, int width, int height) {
            this.Init(x, y, width, height);
        }

        /// <summary>
        /// set and reset viewport using glViewport();
        /// </summary>
        /// <param name="viewport"></param>
        public ViewportSwitch(int[] viewport) {
            this.Init(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        private void Init(int x, int y, int width, int height) {
            this.x = x; this.y = y; this.width = width; this.height = height;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glViewport({0}, {1}, {2}, {3});",
                x, y, width, height);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            var original = stackalloc GLint[4];
            gl.glGetIntegerv((GLenum)GetTarget.Viewport, original);
            this.originalX = original[0];
            this.originalY = original[1];
            this.originalWidth = original[2];
            this.originalHeight = original[3];

            gl.glViewport(x, y, width, height);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glViewport(this.originalX, this.originalY, this.originalWidth, this.originalHeight);
        }
    }
}