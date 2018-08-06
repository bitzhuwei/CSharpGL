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
    public partial class WinSoftGLCanvas :
        UserControl,
        ISupportInitialize,
        IGLCanvas
    {
        private const string strWinSoftGLCanvas = "WinSoftGLCanvas";

        private readonly Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// indicates whether the control is in design mode.
        /// </summary>
        protected readonly bool designMode;
        //private readonly DesignModeAssist assist;

        //private EventHandler mouseEnter;
        //private EventHandler mouseLeave;

        /// <summary>
        /// Creats render context and supports OpenGL rendering.
        /// </summary>
        public WinSoftGLCanvas()
        {
            InitializeComponent();

            //  Set the user draw styles.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // initialize GL instance before any GL commands.
            var gl = SoftGL.SoftGLInstance;
            gl.Finish();

            // check http://stackoverflow.com/questions/34664/designmode-with-controls
            this.designMode = this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

            if (this.designMode)
            {
                //this.assist = new DesignModeAssist(this);
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

        /// <summary>
        ///
        /// </summary>
        [Category(strWinSoftGLCanvas)]
        [Description("FPS")]
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
        [Category(strWinSoftGLCanvas)]
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
        [Category(strWinSoftGLCanvas)]
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

    }
}