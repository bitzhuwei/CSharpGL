using CSharpGL;
using CSharpGL.Windows;
using System.Reflection;

namespace GLInfo {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e) {
            HashSet<string>? config = null;
            var renderContext = WinGLRenderContext.Create(this.Handle, this.Width, this.Height, null, config);
            renderContext?.MakeCurrent();

            var gl = GL.Current; if (gl == null) { this.textBox1.Text = "failed to create openGL context!"; return; }

            AppendLine(this.textBox1, "supported extensions:");
            AppendLine(this.textBox2, "not supported extensions:");
            var type = gl.GetType();
            var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            {
                foreach (var fieldInfo in fieldInfos) {
                    var value = fieldInfo.GetValue(gl);
                    if (value != null && (IntPtr)value != IntPtr.Zero) {
                        AppendLine(this.textBox1, fieldInfo.Name);
                    }
                    else {
                        AppendLine(this.textBox2, fieldInfo.Name);
                    }
                }
            }
        }

        private void AppendLine(TextBox textbox, string text) {
            textbox.AppendText(text);
            textbox.AppendText(Environment.NewLine);
        }
    }
}
