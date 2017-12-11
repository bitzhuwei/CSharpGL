﻿using System;
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
        IGLCanvas
    {
        private const string strWinGLCanvas = "WinGLCanvas";

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
                this.assist = new DesignModeAssist(this);
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
            int width = this.Width, height = this.Height;

            if (this.designMode)
            {
                this.assist.Resize(width, height);
            }
            else
            {
                this.KeyPress += WinGLCanvas_KeyPress;
                this.MouseDown += WinGLCanvas_MouseDown;
                this.MouseMove += WinGLCanvas_MouseMove;
                this.MouseUp += WinGLCanvas_MouseUp;
                this.MouseWheel += WinGLCanvas_MouseWheel;
                this.KeyDown += WinGLCanvas_KeyDown;
                this.KeyUp += WinGLCanvas_KeyUp;
            }

            // Create the render context.
            var parameters = new ContextGenerationParams();
            var renderContext = new FBORenderContext(width, height, parameters);
            renderContext.MakeCurrent();
            this.renderContext = renderContext;

            // Set the most basic OpenGL styles.
            GL.Instance.ShadeModel(GL.GL_SMOOTH);
            GL.Instance.ClearDepth(1.0f);
            GL.Instance.Enable(GL.GL_DEPTH_TEST);// depth test is disabled by default.
            GL.Instance.DepthFunc(GL.GL_LEQUAL);
            GL.Instance.Hint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
        }

        void WinGLCanvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            GLEventHandler<GLKeyPressEventArgs> KeyPress = this.glKeyPress;
            if (KeyPress != null)
            {
                GLKeyPressEventArgs arg = e.Translate();
                KeyPress(sender, arg);
            }
        }

        void WinGLCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseDown = this.glMouseDown;
            if (MouseDown != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseDown(sender, arg);
            }
        }

        void WinGLCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseMove = this.glMouseMove;
            if (MouseMove != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseMove(sender, arg);
            }
        }

        void WinGLCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseUp = this.glMouseUp;
            if (MouseUp != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseUp(sender, arg);
            }
        }

        void WinGLCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseWheel = this.glMouseWheel;
            if (MouseWheel != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseWheel(sender, arg);
            }
        }

        void WinGLCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            GLEventHandler<GLKeyEventArgs> keyDown = this.glKeyDown;
            if (keyDown != null)
            {
                GLKeyEventArgs arg = e.Translate();
                keyDown(sender, arg);
            }
        }

        void WinGLCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            GLEventHandler<GLKeyEventArgs> keyUp = this.glKeyUp;
            if (keyUp != null)
            {
                GLKeyEventArgs arg = e.Translate();
                keyUp(sender, arg);
            }
        }

        #endregion ISupportInitialize 成员

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            GLRenderContext renderContext = this.renderContext;
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
                    string str = string.Format("{0}: OpenGL error: {1}", this.GetType().FullName, error);
                    Debug.WriteLine(str);
                    Log.Write(str);
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
                GLRenderContext renderContext = this.renderContext;
                if (renderContext != null)
                {
                    renderContext.MakeCurrent();

                    renderContext.SetDimensions(width, height);

                    GL.Instance.Viewport(0, 0, width, height);

                    if (this.designMode)
                    {
                        this.assist.Resize(width, height);
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
            GLRenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                this.renderContext = null;
                renderContext.Dispose();
            }
        }

        /// <summary>
        ///
        /// </summary>
        [Category(strWinGLCanvas)]
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
        [Category(strWinGLCanvas)]
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
                        throw new NotDealWithNewEnumItemException(typeof(RenderTrigger));
                }
            }
        }

        /// <summary>
        /// Interval between two rendering passes. Must be greater than 0.(in milliseconds)
        /// </summary>
        [Category(strWinGLCanvas)]
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
            GLEventHandler<PaintEventArgs> handler = this.OpenGLDraw;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Occurs when OpenGL drawing should be performed.
        /// </summary>
        [Description("Called whenever OpenGL drawing should occur."), Category("CSharpGL")]
        public event GLEventHandler<PaintEventArgs> OpenGLDraw;

    }
}