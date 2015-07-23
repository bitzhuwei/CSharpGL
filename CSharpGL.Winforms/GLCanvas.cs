using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CSharpGL.Objects;

namespace CSharpGL.Winforms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GLCanvas : UserControl
    {
        private IRenderContext renderContext;

        /// <summary>
        /// 
        /// </summary>
        public GLCanvas()
        {
            InitializeComponent();

            //  Set the user draw styles.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Initialises OpenGL.
            renderContext = new FBORenderContext();

            //  Create the render context.
            renderContext.Create(OpenGLVersion, Width, Height, 32, null);

            //  Set the most basic OpenGL styles.
            GL.ShadeModel(GL.GL_SMOOTH);
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.ClearDepth(1.0f);
            GL.Enable(GL.GL_DEPTH_TEST);
            GL.DepthFunc(GL.GL_LEQUAL);
            GL.Hint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.renderContext != null)
            {
                Graphics graphics = e.Graphics;

                //	Make sure it's our instance of openSharpGL that's active.
                renderContext.MakeCurrent();

                if (this.DesignMode)
                {
                    GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);

                    ResizeGL();

                    DrawPyramid();
                }
                else
                {
                    //	If there is a draw handler, then call it.
                    DoOpenGLDraw(new RenderEventArgs(graphics));
                }

                //	Blit our offscreen bitmap.
                var handleDeviceContext = graphics.GetHdc();
                renderContext.Blit(handleDeviceContext);
                graphics.ReleaseHdc(handleDeviceContext);
            }
            else
            {
                base.OnPaint(e);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        private void redrawTimer_Tick(object sender, EventArgs e)
        {
            //this.renderingRequired = true;
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.renderContext != null)
            {
                this.renderContext.SetDimensions(this.Width, this.Height);

                GL.Viewport(0, 0, this.Width, this.Height);

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the desired OpenGL version.
        /// </summary>
        /// <value>
        /// The desired OpenGL version.
        /// </value>
        [Description("The desired OpenGL version for the control."), Category("CSharpGL")]
        public GLVersion OpenGLVersion
        {
            get { return openGLVersion; }
            set { openGLVersion = value; }
        }

        /// <summary>
        /// The default desired OpenGL version.
        /// </summary>
        private GLVersion openGLVersion = GLVersion.OpenGL2_1;

        /// <summary>
        /// Gets or sets the render trigger.
        /// </summary>
        /// <value>
        /// The render trigger.
        /// </value>
        [Description("The render trigger - determines when rendering will occur."), Category("CSharpGL")]
        public RenderTriggers RenderTrigger
        {
            get
            {
                return this.redrawTimer.Enabled ? RenderTriggers.TimerBased : RenderTriggers.Manual;
            }
            set
            {
                switch (value)
                {
                    case RenderTriggers.TimerBased:
                        this.redrawTimer.Enabled = true;
                        break;
                    case RenderTriggers.Manual:
                        this.redrawTimer.Enabled = false;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// 获取或设置在相对于上一次发生的 System.Windows.Forms.Timer.Tick 事件引发 System.Windows.Forms.Timer.Tick
        //     事件之前的时间（以毫秒为单位）。该值不能小于 1。
        /// </summary>
        [Description("The rate at which the control should be re-drawn, in Hertz."), Category("CSharpGL"), DefaultValue(50)]
        public int TimerTriggerInterval
        {
            get { return this.redrawTimer.Interval; }
            set
            {
                if (value < 1) { value = 1; }
                this.redrawTimer.Interval = value;
            }
        }

        /// <summary>
        /// Call this function in derived classes to do the OpenGL Draw event.
        /// </summary>
        private void DoOpenGLDraw(RenderEventArgs e)
        {
            var handler = OpenGLDraw;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Occurs when OpenGL drawing should be performed.
        /// </summary>
        [Description("Called whenever OpenGL drawing should occur."), Category("CSharpGL")]
        public event EventHandler<RenderEventArgs> OpenGLDraw;


        private void ResizeGL()
        {
            //  Set the projection matrix.
            GL.MatrixMode(GL.GL_PROJECTION);

            //  Load the identity.
            GL.LoadIdentity();

            //  Create a perspective transformation.
            GL.gluPerspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            GL.gluLookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            GL.MatrixMode(GL.GL_MODELVIEW);
        }

        private void DrawPyramid()
        {
            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //  Load the identity matrix.
            GL.LoadIdentity();

            //  Rotate around the Y axis.
            GL.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            //  Draw a coloured pyramid.
            GL.Begin(GL.GL_TRIANGLES);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(-1.0f, -1.0f, 1.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(1.0f, -1.0f, 1.0f);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(1.0f, -1.0f, 1.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(1.0f, -1.0f, -1.0f);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(1.0f, -1.0f, -1.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(-1.0f, -1.0f, -1.0f);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(-1.0f, -1.0f, -1.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(-1.0f, -1.0f, 1.0f);
            GL.End();

            rotation += 3.0f;
        }

        private double rotation;

    }

}
