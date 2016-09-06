using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
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
    public partial class GLSceneCanvas :
        UserControl,
        ISupportInitialize,
        ICanvas
    {
        private Stopwatch stopWatch = new Stopwatch();
        private readonly string fullname;

        /// <summary>
        ///
        /// </summary>
        protected RenderContext renderContext;

        /// <summary>
        /// indicates whether the control is in design mode.
        /// </summary>
        protected readonly bool designMode;

        private EventHandler mouseEnter;
        private EventHandler mouseLeave;

        /// <summary>
        /// Creats render context and supports OpenGL rendering.
        /// </summary>
        public GLSceneCanvas()
        {
            InitializeComponent();

            //  Set the user draw styles.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // check http://stackoverflow.com/questions/34664/designmode-with-controls
            this.designMode = this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

            if (!this.designMode)
            {
                //this.mouseEnter = GLCanvas_MouseEnter;
                this.mouseEnter = (x, y) => ShowCursor(0);// hide system's cursor.
                this.mouseLeave = (x, y) => ShowCursor(1);// show system's cursor.
            }
            this.fullname = this.GetType().FullName;
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.Width, this.Height);
                var rotator = new FirstPerspectiveManipulater();// SatelliteManipulater();
                rotator.Bind(camera, this);
                this.CameraManipulater = rotator;
                var scene = new Scene(camera, this);
                this.Scene = scene;
                this.Resize += scene.Resize;
            }
        }

        private bool showingCursor = true;
        private bool showSystemCursor = true;

        /// <summary>
        /// show/hide system's cursor.
        /// </summary>
        [Category("CSharpGL")]
        [Description("show/hide system's cursor.")]
        public bool ShowSystemCursor
        {
            get { return (this.showSystemCursor); }
            set
            {
                this.showSystemCursor = value;
                if (!this.designMode)
                {
                    if ((this.showingCursor) && (!value))
                    {
                        this.MouseEnter += mouseEnter;
                        this.MouseLeave += mouseLeave;
                        ShowCursor(0);
                    }
                    else if ((!this.showingCursor) && (value))
                    {
                        this.MouseEnter -= mouseEnter;
                        this.MouseLeave -= mouseLeave;
                        ShowCursor(1);
                    }
                }
            }
        }

        [DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
        private extern static void ShowCursor(int status);

        #region ISupportInitialize 成员

        void ISupportInitialize.BeginInit()
        {
        }

        void ISupportInitialize.EndInit()
        {
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
            renderContext.Create(OpenGLVersion, Width, Height, 32, null);

            this.renderContext = renderContext;

            renderContext.MakeCurrent();

            //  Set the most basic OpenGL styles.
            OpenGL.ShadeModel(OpenGL.GL_SMOOTH);
            OpenGL.ClearDepth(1.0f);
            OpenGL.Enable(OpenGL.GL_DEPTH_TEST);
            OpenGL.DepthFunc(OpenGL.GL_LEQUAL);
            OpenGL.Hint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);
            if (this.designMode)
            {
                GLCanvasHelper.ResizeGL(this.Width, this.Height);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            RenderContext renderContext = this.renderContext;
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
                    DesignModeRender();
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

            this.FPS = 1000.0 / stopWatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Call this function in derived classes to do the OpenGL Draw event.
        /// </summary>
        private void DoOpenGLDraw(PaintEventArgs e)
        {
            vec4 clearColor = this.Scene.ClearColor.ToVec4();
            OpenGL.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);

            //  Clear the color and depth buffer.
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.Scene.Render(RenderModes.Render, this.ClientRectangle,
                this.PointToClient(Control.MousePosition));
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void DesignModeRender()
        {
            // Sky blue fore background.
            //OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            OpenGL.ClearColor(0, 0, 0, 0);

            //  Clear the color and depth buffer.
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            GLCanvasHelper.DrawClock();

            OpenGL.DrawText(10,
                10, Color.White, "Courier New",// "Courier New",
                25.0f, this.fullname);
            if (this.RenderTrigger == RenderTrigger.TimerBased)
            {
                OpenGL.DrawText(10,
                    this.Height - 20 - 1, Color.Red, "Courier New",// "Courier New",
                    20.0f, string.Format("FPS: {0}", this.FPS.ToShortString()));
            }
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

            RenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                renderContext.MakeCurrent();

                renderContext.SetDimensions(this.Width, this.Height);

                OpenGL.Viewport(0, 0, this.Width, this.Height);

                if (this.designMode)
                {
                    GLCanvasHelper.ResizeGL(this.Width, this.Height);
                }

                this.Invalidate();
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
            RenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                this.renderContext = null;
                renderContext.Dispose();
            }
        }

        /// <summary>
        ///
        /// </summary>
        [Category("CSharpGL")]
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
        [Description("Interval between two rendering passes. Must be greater than 0.(in milliseconds)."), Category("CSharpGL"), DefaultValue(50)]
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
        /// Scene to be rendered.
        /// </summary>
        [Description("Scene to be rendered."), Category("CSharpGL")]
        public Scene Scene { get; private set; }

        private Manipulater cameraManipulater;
        /// <summary>
        /// Controls how camera moves according to mouse/keyboard.
        /// </summary>
        [Description("Controls how camera moves according to mouse/keyboard."), Category("CSharpGL")]
        public Manipulater CameraManipulater
        {
            get { return this.cameraManipulater; }
            set
            {
                if (this.cameraManipulater != null)
                { this.cameraManipulater.Unbind(); }
                this.cameraManipulater = value;
                value.Bind(this.Scene.Camera, this);
            }
        }

        /// <summary>
        /// repaint this canvas' content.
        /// </summary>
        public void Repaint()
        {
            this.Invalidate();
        }

    }
}