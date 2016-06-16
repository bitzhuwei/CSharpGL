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
using System.ComponentModel.Design;
using System.Diagnostics;

namespace CSharpGL
{
    /// <summary>
    /// 可执行OpenGL渲染的控件。
    /// </summary>
    [DefaultProperty("Text")]
    [DefaultEvent("OpenGLDraw")]
    [Description("A canvas for OpenGL rendering.")]
    //[ToolboxBitmap(typeof(GLCanvas), @"CSharpGL.WinformControls.GLCanvas.ico")]
    public partial class GLCanvas : UserControl, ISupportInitialize
    {
        private Stopwatch stopWatch = new Stopwatch();

        protected RenderContext renderContext;

        private bool designMode;

        /// <summary>
        /// 可执行OpenGL渲染的控件。
        /// </summary>
        public GLCanvas()
        {
            InitializeComponent();

            //  Set the user draw styles.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // check http://stackoverflow.com/questions/34664/designmode-with-controls
            this.designMode = this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

        }

        #region ISupportInitialize 成员

        void ISupportInitialize.BeginInit()
        {
        }

        void ISupportInitialize.EndInit()
        {
            CreateRenderContext();
        }

        #endregion

        private void CreateRenderContext()
        {
            // Initialises OpenGL.
            var renderContext = new FBORenderContext();

            //  Create the render context.
            renderContext.Create(OpenGLVersion, Width, Height, 32, null);

            this.renderContext = renderContext;

            renderContext.MakeCurrent();

            //  Set the most basic OpenGL styles.
            OpenGL.ShadeModel(OpenGL.GL_SMOOTH);
            // 天蓝色背景
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            OpenGL.ClearDepth(1.0f);
            OpenGL.Enable(OpenGL.GL_DEPTH_TEST);
            OpenGL.DepthFunc(OpenGL.GL_LEQUAL);
            OpenGL.Hint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RenderContext renderContext = this.renderContext;
            if (renderContext == null)
            {
                base.OnPaint(e);
                return;
            }

            stopWatch.Restart();

            //	Make sure it's our instance of openSharpGL that's active.
            renderContext.MakeCurrent();

            if (this.designMode)
            {
                GLCanvasHelper.ResizeGL(this.Width, this.Height);

                GLCanvasHelper.DrawPyramid();
            }
            else
            {
                //	If there is a draw handler, then call it.
                DoOpenGLDraw(e);
            }

            //	Blit our offscreen bitmap.
            Graphics graphics = e.Graphics;
            IntPtr deviceContext = graphics.GetHdc();
            renderContext.Blit(deviceContext);
            graphics.ReleaseHdc(deviceContext);

            stopWatch.Stop();

            this.FPS = 1000.0 / stopWatch.Elapsed.TotalMilliseconds;
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

            RenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                renderContext.MakeCurrent();

                renderContext.SetDimensions(this.Width, this.Height);

                OpenGL.Viewport(0, 0, this.Width, this.Height);

                this.Invalidate();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            DestroyRenderContext();

            base.OnHandleDestroyed(e);
        }

        private void DestroyRenderContext()
        {
            RenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                this.renderContext = null;
                renderContext.Dispose();
            }
        }

        public double FPS { get; private set; }

        /// <summary>
        /// Gets or sets the desired OpenGL version.
        /// </summary>
        /// <value>
        /// The desired OpenGL version.
        /// </value>
        [Description("The desired OpenGL version for the control. Only works in design mode."), Category("CSharpGL")]
        public GLVersion OpenGLVersion
        {
            get { return openGLVersion; }
            set
            {
                if (this.designMode)
                {
                    openGLVersion = value;
                    //if (openGLVersion != value)
                    //{
                    //    openGLVersion = value;

                    //    this.DestroyRenderContext();
                    //    this.CreateRenderContext();
                    //}
                }
            }
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
        /// 获取或设置两次重绘之间的时间间隔（以毫秒为单位）。该值不能小于 1。
        /// </summary>
        [Description("获取或设置两次重绘之间的时间间隔（以毫秒为单位）。该值不能小于 1。"), Category("CSharpGL"), DefaultValue(50)]
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
        private void DoOpenGLDraw(PaintEventArgs e)
        {
            var handler = OpenGLDraw;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Occurs when OpenGL drawing should be performed.
        /// </summary>
        [Description("Called whenever OpenGL drawing should occur."), Category("CSharpGL")]
        public event EventHandler<PaintEventArgs> OpenGLDraw;

    }

}
