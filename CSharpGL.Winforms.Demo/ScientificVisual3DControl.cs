using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL.Objects.RenderContexts;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;

namespace CSharpGL.Winforms.Demo
{
    /// <summary>
    /// 可执行OpenGL渲染的控件。
    /// </summary>
    [ToolboxBitmap(typeof(ScientificVisual3DControl), "ScientificVisual3DControl.ico")]
    public partial class ScientificVisual3DControl : UserControl, ISupportInitialize
    {
        protected RenderContext renderContext;

        private bool designMode;

        private List<SceneElementBase> elementList = new List<SceneElementBase>();

        /// <summary>
        /// 获取此控件内的元素列表。
        /// </summary>
        public List<SceneElementBase> ElementList
        {
            get { return elementList; }
        }

        private IScientificCamera camera;

        public IScientificCamera Camera
        {
            get { return camera; }
        }
        
        /// <summary>
        /// 可执行OpenGL渲染的控件。
        /// </summary>
        public ScientificVisual3DControl()
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

            this.camera = new ScientificCamera(CameraTypes.Perspecitive, this.Width, this.Height);
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
            GL.ShadeModel(GL.GL_SMOOTH);
            // 天蓝色背景
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.ClearDepth(1.0f);
            GL.Enable(GL.GL_DEPTH_TEST);
            GL.DepthFunc(GL.GL_LEQUAL);
            GL.Hint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                Graphics graphics = e.Graphics;

                //	Make sure it's our instance of openSharpGL that's active.
                renderContext.MakeCurrent();

                if (this.designMode)
                {
                    // 天蓝色背景
                    GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);

                    GLCanvasHelper.ResizeGL(this.Width, this.Height);

                    GLCanvasHelper.DrawPyramid();

                }
                else
                {
                    //	If there is a draw handler, then call it.
                    //DoOpenGLDraw(new RenderEventArgs(graphics));
                    foreach (var item in this.elementList)
                    {
                        item.Render(RenderModes.Render);
                    }
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

            RenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                renderContext.MakeCurrent();

                renderContext.SetDimensions(this.Width, this.Height);

                GL.Viewport(0, 0, this.Width, this.Height);

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
            set
            {
                if (openGLVersion != value)
                {
                    this.DestroyRenderContext();
                    this.CreateRenderContext();

                    openGLVersion = value;
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

    }
}
