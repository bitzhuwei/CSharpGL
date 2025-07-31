using CSharpGL;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace demos.anything {
    public unsafe partial class FormInstance : Form {
        //private DummyRenderer? dummyRenderer;
        private Type? instanceType;
        private demoCode? currentInstance;

        private int x;
        private int y;


        public FormInstance(Type instanceType) {
            InitializeComponent();

            this.instanceType = instanceType;

            // init resources.
            this.Load += FormInstance_Load;
            // render event.
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;

        }

        private void FormInstance_Load(object? sender, EventArgs e) {
            var gl = GL.Current; if (gl == null) { return; }
            if (this.instanceType == null) { return; }

            var instance = Activator.CreateInstance(instanceType,
                this, this.glCanvas1) as demoCode;
            if (instance != null && gl != null) {
                this.currentInstance = instance;
                instance.init(gl);
                instance.reshape(gl, this.glCanvas1.Width, this.glCanvas1.Height);
            }
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

        private void UpdateText() {
            this.Text = $"OpenGL via C# - FPS: {this.glCanvas1.GetFPS().ToString("000.00")}";
        }

        public void SetInfo(string info) {
            this.lblInfo.Text = info;
        }
    }
}
