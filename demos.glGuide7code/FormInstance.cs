using CSharpGL;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace demos.glGuide7code {
    public unsafe partial class FormInstance : Form {
        //private DummyRenderer? dummyRenderer;
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer() { Enabled = true, Interval = 1 };

        private double FPS = 0;

        private Type? instanceType;
        private _glGuide7code? currentInstance;

        private int x;
        private int y;


        public FormInstance(Type instanceType) {
            InitializeComponent();

            this.instanceType = instanceType;

            // init resources.
            this.Load += FormInstance_Load;
            // render event.
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            // resize event.
            this.glCanvas1.Resize += glCanvas1_Resize;
            this.timer1.Tick += timer1_Tick;
            this.glCanvas1.MouseMove += GlCanvas1_MouseMove;
            this.glCanvas1.MouseDown += GlCanvas1_MouseDown;
            this.glCanvas1.MouseUp += GlCanvas1_MouseUp;
            this.glCanvas1.KeyDown += GlCanvas1_KeyDown;

        }

        private void FormInstance_Load(object? sender, EventArgs e) {
            var gl = GL.Current; if (gl == null) { return; }
            if (this.instanceType == null) { return; }

            var instance = Activator.CreateInstance(instanceType,
                this, this.glCanvas1.Width, this.glCanvas1.Height, gl) as _glGuide7code;
            if (instance != null && gl != null) {
                this.currentInstance = instance;
                instance.init(gl);
                instance.reshape(gl, this.glCanvas1.Width, this.glCanvas1.Height);
                this.lblValidKeys.Text = string.Concat(instance.ValidKeys);
                this.lblValidButtons.Text = string.Concat(instance.ValidButtons);
            }
        }

        private void glCanvas_Mouse(object? sender, MouseEventArgs e, MouseState state) {
            this.x = e.X;
            this.y = e.Y;

            var gl = GL.Current; if (gl == null) return;
            var instance = this.currentInstance; if (instance == null) return;
            instance.mouse(e.Button, state, e.X, e.Y);
        }
        private void GlCanvas1_MouseUp(object? sender, MouseEventArgs e) {
            glCanvas_Mouse(sender, e, MouseState.Up);
        }

        private void GlCanvas1_MouseDown(object? sender, MouseEventArgs e) {
            glCanvas_Mouse(sender, e, MouseState.Down);
        }

        private void GlCanvas1_MouseMove(object? sender, MouseEventArgs e) {
            glCanvas_Mouse(sender, e, MouseState.Move);
        }

        private void GlCanvas1_KeyDown(object? sender, KeyEventArgs e) {
            var gl = GL.Current; if (gl == null) return;
            var instance = this.currentInstance; if (instance == null) return;

            instance.keyboard(gl, e.KeyCode, this.x, this.y);
        }

        private unsafe void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e) {
            var gl = GL.Current; if (gl == null) return;
            var instance = this.currentInstance; if (instance == null) return;

            instance.display(gl);

            this.UpdateText();
        }

        void glCanvas1_Resize(object? sender, EventArgs e) {
            var gl = GL.Current; if (gl == null) return;
            var instance = this.currentInstance; if (instance == null) return;
            instance.reshape(gl, this.glCanvas1.Width, this.glCanvas1.Height);
        }

        private void timer1_Tick(object? sender, EventArgs e) {
            this.FPS = this.glCanvas1.GetFPS();
        }

        private void UpdateText() {
            this.Text = $"openGL Program Guide 7th Edition - FPS: {this.glCanvas1.GetFPS().ToString("000.00")}";
        }

    }
}
