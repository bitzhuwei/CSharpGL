using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 可执行OpenGL渲染的控件。
    /// </summary>
    [DefaultProperty("Text")]
    [DefaultEvent("OpenGLDraw")]
    [Description("A canvas for OpenGL rendering.")]
    //[ToolboxBitmap(typeof(GLCanvas), @"CSharpGL.WinformControls.GLCanvas.ico")]
    //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class WinGLCanvas :
        UserControl,
        ISupportInitialize,
        IWinGLCanvas
    {
        private readonly Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// indicates whether the control is in design mode.
        /// </summary>
        protected readonly bool designMode;
        private readonly DesignModeAssist assist;

        //private EventHandler mouseEnter;
        //private EventHandler mouseLeave;

        /// <summary>
        /// Creats render context and supports OpenGL rendering.
        /// </summary>
        public WinGLCanvas()
        {
            InitializeComponent();

            //  Set the user draw styles.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // initialize GL instance before any GL commands.
            var gl = WinGL.WinGLInstance;
            gl.Finish();

            // check http://stackoverflow.com/questions/34664/designmode-with-controls
            this.designMode = this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

            if (this.designMode)
            {
                this.assist = new DesignModeAssist(this.Width, this.Height, this.GetType().FullName);
                ////this.mouseEnter = GLCanvas_MouseEnter;
                //this.mouseEnter = (x, y) => ShowCursor(0);// hide system's cursor.
                //this.mouseLeave = (x, y) => ShowCursor(1);// show system's cursor.
            }

        }

        //private bool showingCursor = true;
        //private bool showSystemCursor = true;

        ///// <summary>
        ///// show/hide system's cursor.
        ///// </summary>
        //[Category("CSharpGL")]
        //[Description("show/hide system's cursor.")]
        //public bool ShowSystemCursor
        //{
        //    get { return (this.showSystemCursor); }
        //    set
        //    {
        //        this.showSystemCursor = value;
        //        if (!this.designMode)
        //        {
        //            if ((this.showingCursor) && (!value))
        //            {
        //                this.MouseEnter += mouseEnter;
        //                this.MouseLeave += mouseLeave;
        //                ShowCursor(0);
        //            }
        //            else if ((!this.showingCursor) && (value))
        //            {
        //                this.MouseEnter -= mouseEnter;
        //                this.MouseLeave -= mouseLeave;
        //                ShowCursor(1);
        //            }
        //        }
        //    }
        //}

        //[DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
        //private extern static void ShowCursor(int status);

        #region ISupportInitialize 成员

        void ISupportInitialize.BeginInit()
        {
        }

        void ISupportInitialize.EndInit()
        {
            if (this.designMode)
            {
                this.assist.Resize(this.Width, this.Height);
            }

            CreateRenderContext();
        }

        #endregion ISupportInitialize 成员

        /// <summary>
        ///
        /// </summary>
        protected virtual void CreateRenderContext()
        {
            // Initialises OpenGL.
            var renderContext = new FBORenderContext();

            //  Create the render context.
            renderContext.Create(Width, Height, 32, null);

            this.RenderContext = renderContext;

            renderContext.MakeCurrent();

            //  Set the most basic OpenGL styles.
            GL.Instance.ShadeModel(GL.GL_SMOOTH);
            GL.Instance.ClearDepth(1.0f);
            GL.Instance.Enable(GL.GL_DEPTH_TEST);// depth test is disabled by default.
            GL.Instance.DepthFunc(GL.GL_LEQUAL);
            GL.Instance.Hint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            GLRenderContext renderContext = this.RenderContext;
            if (renderContext == null)
            {
                base.OnPaint(e);
                return;
            }

            stopWatch.Reset();
            stopWatch.Start();

            //	Make sure it's our instance of openSharpGL that's active.
            renderContext.MakeCurrent();

            if (this.designMode)
            {
                try
                {
                    this.assist.Render(this.RenderTrigger == RenderTrigger.TimerBased, this.Height, this.FPS);
                }
                catch (Exception)
                {
                }
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

            {
                ErrorCode error = (ErrorCode)GL.Instance.GetError();
                if (error != ErrorCode.NoError)
                {
                    Debug.WriteLine(string.Format("{0}: OpenGL error: {1}", this.GetType().FullName, error));
                }
            }

            this.FPS = 1000.0 / stopWatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        private void redrawTimer_Tick(object sender, EventArgs e)
        {
            //this.renderingRequired = true;
            this.Invalidate();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            int width = this.Width, height = this.Height;
            if (width > 0 && height > 0)
            {
                GLRenderContext renderContext = this.RenderContext;
                if (renderContext != null)
                {
                    renderContext.MakeCurrent();

                    renderContext.SetDimensions(width, height);

                    GL.Instance.Viewport(0, 0, width, height);

                    if (this.designMode)
                    {
                        this.assist.Resize(this.Width, this.Height);
                    }

                    this.Invalidate();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            DestroyRenderContext();

            base.OnHandleDestroyed(e);
        }

        private void DestroyRenderContext()
        {
            GLRenderContext renderContext = this.RenderContext;
            if (renderContext != null)
            {
                this.RenderContext = null;
                renderContext.Dispose();
            }
        }

        /// <summary>
        ///
        /// </summary>
        [Category("CSharpGL")]
        public double FPS { get; private set; }

        ///// <summary>
        ///// Gets or sets the desired OpenGL version.
        ///// </summary>
        ///// <value>
        ///// The desired OpenGL version.
        ///// </value>
        //[Description("The desired OpenGL version for the control. Only works in design mode."), Category("CSharpGL")]
        //public GLVersion OpenGLVersion
        //{
        //    get { return openGLVersion; }
        //    set
        //    {
        //        if (this.designMode)
        //        {
        //            openGLVersion = value;
        //            //if (openGLVersion != value)
        //            //{
        //            //    openGLVersion = value;

        //            //    this.DestroyRenderContext();
        //            //    this.CreateRenderContext();
        //            //}
        //        }
        //    }
        //}

        ///// <summary>
        ///// The default desired OpenGL version.
        ///// </summary>
        //private GLVersion openGLVersion = GLVersion.OpenGL2_1;

        /// <summary>
        /// Gets or sets the render trigger.
        /// </summary>
        /// <value>
        /// The render trigger.
        /// </value>
        [Category("CSharpGL")]
        [Description("The render trigger - determines when rendering will occur.")]
        public RenderTrigger RenderTrigger
        {
            get
            {
                return this.redrawTimer.Enabled ? RenderTrigger.TimerBased : RenderTrigger.Manual;
            }
            set
            {
                switch (value)
                {
                    case RenderTrigger.TimerBased:
                        this.redrawTimer.Enabled = true;
                        break;

                    case RenderTrigger.Manual:
                        this.redrawTimer.Enabled = false;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Interval between two rendering passes. Must be greater than 0.(in milliseconds)
        /// </summary>
        [Category("CSharpGL")]
        [Description("Interval between two rendering passes. Must be greater than 0.(in milliseconds).")]
        [DefaultValue(50)]
        public int TimerTriggerInterval
        {
            get { return this.redrawTimer.Interval; }
            set
            {
                if (value < 1)
                {
                    this.redrawTimer.Interval = 1;
                }
                else
                {
                    this.redrawTimer.Interval = value;
                }
            }
        }

        /// <summary>
        /// Call this function in derived classes to do the OpenGL Draw event.
        /// </summary>
        private void DoOpenGLDraw(PaintEventArgs e)
        {
            EventHandler<PaintEventArgs> handler = this.OpenGLDraw;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Occurs when OpenGL drawing should be performed.
        /// </summary>
        [Description("Called whenever OpenGL drawing should occur."), Category("CSharpGL")]
        public event EventHandler<PaintEventArgs> OpenGLDraw;

        #region IGLCanvas 成员

        /// <summary>
        /// repaint this canvas' content.
        /// </summary>
        public void Repaint()
        {
            this.Invalidate();
        }

        [Category("CSharpGL")]
        [Description("OpenGL Render Context.")]
        public GLRenderContext RenderContext { get; private set; }

        #endregion
    }
}