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
    /// 可执行OpenGL渲染的控件。
    /// </summary>
    [ToolboxBitmap(typeof(GLCanvas), "GLCanvas.png")]
    public partial class GLCanvas : UserControl
    {
        private RenderContext renderContext;

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
                    // 天蓝色背景
                    GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);

                    GLCanvasHelper.ResizeGL(this.Width, this.Height);

                    GLCanvasHelper.DrawPyramid();
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

    }

}
