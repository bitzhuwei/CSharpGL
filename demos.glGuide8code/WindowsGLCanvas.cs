using CSharpGL;
using CSharpGL.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demos.glGuide8code {
    public unsafe partial class WindowsGLCanvas : UserControl, IGLCanvas {
        private static readonly Func<IntPtr, int, int, object, HashSet<string>?, GLRenderContext?> defaultCreateWinGLRenderContext = WinGLRenderContext.Create;

        private readonly Func<IntPtr, int, int, ContextGenerationParams, HashSet<string>?, GLRenderContext?> createRenderContext;

        private vec4 clearColor = Color.SkyBlue.ToVec4();

        private static readonly ContextGenerationParams parameters = new ContextGenerationParams();
        private bool designMode;
        //private DesignModeAssist? assist;

        private GLRenderContext? renderContext;
        private double FPS;
        public double GetFPS() { return FPS; }

        public GLRenderContext? RenderContext => renderContext;

        private RenderTrigger renderTrigger = RenderTrigger.TimerBased;
        public RenderTrigger RenderTrigger {
            get { return renderTrigger; }
            set {
                this.renderTrigger = value;
                this.redrawTimer.Enabled = value == RenderTrigger.TimerBased;
            }
        }
        public int TimerTriggerInterval {
            get { return this.redrawTimer.Interval; }
            set { this.redrawTimer.Interval = value; }
        }

        //private int renderTimes = 0;
        //private DateTime startTime;
        /*
         * about design mode:
2025/5/18 10:49:43.684 WindowsGLCanvas: false
2025/5/18 10:49:43.704 OnHandleCreated: true
2025/5/18 10:49:43.704 OnLoad: true
2025/5/18 10:49:43.705 OnCreateControl: true

         */

        public WindowsGLCanvas(Func<IntPtr, int, int, object, HashSet<string>?, GLRenderContext?> createRenderContext) {
            this.createRenderContext = createRenderContext;

            InitializeComponent();
            //  Set the user draw styles.
            SetStyle(ControlStyles.OptimizedDoubleBuffer |  // 启用优化双缓冲
                     ControlStyles.AllPaintingInWmPaint |   // 忽略 WM_ERASEBKGND 消息
                     ControlStyles.UserPaint, true);        // 自行处理绘制
            //DoubleBuffered = true;                        // 快速启用双缓冲（等效于上述设置）

            redrawTimer.Interval = 1;
            redrawTimer.Tick += redrawTimer_Tick;
            redrawTimer.Enabled = true;

            //this.designMode = this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

            //var gl = WinGL.Current; // gl is null.
            //if (gl != null) { gl.glFinish(); }
            //else { this.clearColor = new vec4(0, 1, 0, 1); }
        }

        public WindowsGLCanvas() : this(defaultCreateWinGLRenderContext) { }

        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            // check http://stackoverflow.com/questions/34664/designmode-with-controls
            this.designMode = this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
            //var now = DateTime.Now;
            //File.AppendAllText("OnHandleCreated.txt", $"{now}.{now.Millisecond} design mode: {this.designMode}");
            try {
                int width = this.Width, height = this.Height;
                // Create the render context.
                ContextGenerationParams parameters; HashSet<string>? config = null;
                if (this.designMode) {
                    parameters = new ContextGenerationParams();
                    //parameters.updateContextVersion = false;
                    //config = new HashSet<string>() { "glShadeModel", "glClearDepth", "glEnable", "glDepthFunc", "glHint", "glViewport", "glClearColor", "glClear", };
                }
                else {
                    parameters = WindowsGLCanvas.parameters;
                }
                var renderContext = this.createRenderContext(this.Handle, width, height, parameters, config);
                //var now = DateTime.Now;
                //File.AppendAllText("OnLoad.txt", $"{now}.{now.Millisecond} renderContext: {renderContext != null}");
                if (renderContext != null) {
                    this.renderContext = renderContext;

                    renderContext.MakeCurrent();
                    // Set the most basic OpenGL styles.
                    var gl = renderContext.glFunctions;
                    //gl.glShadeModel(0x1D01/*GL_SMOOTH*/);
                    //gl.glClearDepth(1.0f);//initial value is 1.
                    gl.glEnable(0x0B71/*GL_DEPTH_TEST*/);// depth test is disabled by default.
                    gl.glDepthFunc(0x0203/*GL_LEQUAL*/);
                    gl.glHint(0x0C50/*GL_PERSPECTIVE_CORRECTION_HINT*/, 0x1102/*GL_NICEST*/);
                    gl.glClearColor(this.clearColor.x, this.clearColor.y, this.clearColor.z, this.clearColor.w);
                    //{
                    //    uint error;
                    //    error = gl.glGetError();
                    //    int max_vao;
                    //    gl.glGetIntegerv(0x8869/*GL_MAX_VERTEX_ATTRIBS*/, &max_vao);
                    //    error = gl.glGetError();

                    //    // 尝试绑定默认 VAO (ID=0)
                    //    gl.glBindVertexArray(0);
                    //    error = gl.glGetError();

                    //    // 如果成功，说明默认 VAO 存在
                    //    uint vbo;
                    //    gl.glGenBuffers(1, &vbo);
                    //    error = gl.glGetError();
                    //    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, vbo);
                    //    error = gl.glGetError();
                    //    gl.glBufferData(GL.GL_ARRAY_BUFFER, 10, IntPtr.Zero, GL.GL_STATIC_DRAW);
                    //    error = gl.glGetError();
                    //    gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    //    error = gl.glGetError();
                    //    gl.glEnableVertexAttribArray(0);
                    //    error = gl.glGetError();
                    //}
                    if (this.designMode) {
                        //var assist = new DesignModeAssist(this);
                        //assist.Resize(this.Width, this.Height);
                        //this.assist = assist;
                    }
                    else {
                        //this.KeyPress += WinGLCanvas_KeyPress;
                        //this.MouseDown += WinGLCanvas_MouseDown;
                        //this.MouseMove += WinGLCanvas_MouseMove;
                        //this.MouseUp += WinGLCanvas_MouseUp;
                        //this.MouseWheel += WinGLCanvas_MouseWheel;
                        //this.KeyDown += WinGLCanvas_KeyDown;
                        //this.KeyUp += WinGLCanvas_KeyUp;
                    }
                }
                else {
                    this.clearColor = new vec4(0, 0, 1, 1);
                }
            }
            catch (Exception ex) {
                this.clearColor = new vec4(1, 0, 0, 1);
                Log.Write(ex);
            }
        }

        private Bitmap? bitmap;
        private bool dump = false;
        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            if (this.renderContext == null) { base.OnPaint(e); return; }

            //stopWatch.Reset();
            //stopWatch.Start();
            var start = DateTime.Now;
            renderContext.MakeCurrent();
            if (this.designMode) {
                try {
                    var gl = GL.Current;
                    if (gl != null) {
                        var c = this.clearColor;
                        gl.glClearColor(c.x, c.y, c.z, c.w);
                        gl.glClear(0x00004000/*GL_COLOR_BUFFER_BIT*/ | 0x00000100/*GL_DEPTH_BUFFER_BIT*/ | 0x00000400/*GL_STENCIL_BUFFER_BIT*/);
                        //this.assist?.Render(this.RenderTrigger == RenderTrigger.TimerBased, this.Height, this.FPS, this);
                    }
                }
                catch (Exception) {
                    base.OnPaint(e); return;
                }
            }
            else {
                //	If there is a draw handler, then call it.
                var handler = this.OpenGLDraw;
                if (handler != null) { handler(this, e); }
            }

            //	Blit our offscreen bitmap.
            // way #1.
            Graphics graphics = e.Graphics;
            var hDC = graphics.GetHdc();
            var success = renderContext.Blit(hDC);
            graphics.ReleaseHdc();
            //way #2.
            if (!success) {
                var gl = GL.Current; if (gl != null) {
                    int width = this.Width, height = this.Height;
                    if (width > 0 && height > 0) {
                        var bitmap = this.bitmap;
                        if (bitmap == null || bitmap.Width != width || bitmap.Height != height) {
                            if (bitmap != null) { bitmap.Dispose(); }
                            bitmap = new Bitmap(width, height);
                            this.bitmap = bitmap;
                        }

                        var bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        gl.glReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                        bitmap.UnlockBits(bmpData);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                        e.Graphics.DrawImage(bitmap, 0, 0);
                        if (dump) {
                            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.fff");
                            bitmap.Save($"dump{time}.png");
                        }


                    }
                }
            }
            {
                var gl = GL.Current; if (gl != null) {
                    var error = (ErrorCode)gl.glGetError();
                    if (error != ErrorCode.NoError) {
                        string str = string.Format("{0}: OpenGL error: {1}", this.GetType().FullName, error);
                        Debug.WriteLine(str);
                        Log.Write(str);
                    }
                }
            }
            //stopWatch.Stop();
            var stop = DateTime.Now;
            var span = (stop - start).TotalMilliseconds;
            this.FPS = 1000.0 / span;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e) {
            //base.OnPaintBackground(e);
        }

        ///// <summary>
        ///// Make render context in this Canvas the current one in the thread.
        ///// </summary>
        //public void MakeCurrent() {
        //    if (this.renderContext != null) {
        //        this.renderContext.MakeCurrent();
        //    }
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);

            int width = this.Width, height = this.Height;
            var renderContext = this.renderContext;
            if (width > 0 && height > 0 && renderContext != null) {
                renderContext.MakeCurrent();
                renderContext.SetDimensions(width, height);
                var gl = renderContext.glFunctions;
                gl.glViewport(0, 0, width, height);
                if (this.designMode) {
                    //this.assist?.Resize(width, height);
                }
                else {
                    //Bitmap bitmap = this.bitmap;
                    //this.bitmap = new Bitmap(width, height);
                    //if (bitmap != null) { bitmap.Dispose(); }
                }

                this.Invalidate();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e) {
            DestroyRenderContext();
            {
                var bitmap = this.bitmap;
                if (bitmap != null) {
                    bitmap.Dispose();
                    this.bitmap = null;
                }
            }
            //var now = DateTime.Now;
            //var span = (now - startTime).TotalMilliseconds;
            //var speed = (this.renderTimes / span) * 1000;
            //File.WriteAllText("speed.txt", $"{this.startTime} -> {now} : {this.renderTimes} => {speed} FPS");

            base.OnHandleDestroyed(e);
        }

        private void DestroyRenderContext() {
            var renderContext = this.renderContext;
            if (renderContext != null) {
                this.renderContext = null;
                if (renderContext is IDisposable disp) { disp.Dispose(); }
            }
        }

        private void redrawTimer_Tick(object? sender, EventArgs e) {
            this.Invalidate();
        }

        /// <summary>
        /// Called whenever OpenGL drawing should occur.
        /// </summary>
        //[Description("Called whenever OpenGL drawing should occur."), Category("CSharpGL")]
        public event GLEventHandler<PaintEventArgs>? OpenGLDraw;
        public event GLEventHandler<GLKeyPressEventArgs>? GLKeyPress;
        public event GLEventHandler<GLMouseEventArgs>? GLMouseDown;
        public event GLEventHandler<GLMouseEventArgs>? GLMouseMove;
        public event GLEventHandler<GLMouseEventArgs>? GLMouseUp;
        public event GLEventHandler<GLMouseEventArgs>? GLMouseWheel;
        public event GLEventHandler<GLKeyEventArgs>? GLKeyDown;
        public event GLEventHandler<GLKeyEventArgs>? GLKeyUp;
    }
}
