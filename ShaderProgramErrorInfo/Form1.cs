using CSharpGL;
using CSharpGL.Windows;

namespace ShaderProgramErrorInfo {
    public partial class Form1 : Form {
        private WinGLRenderContext? renderContext = null;

        public Form1() {
            InitializeComponent();

            LoadDefaultShaderCodes();
            this.Load += Form1_Load;
        }

        private void LoadDefaultShaderCodes() {
            if (File.Exists("default.vert")) {
                this.txtVertexShader.Text = File.ReadAllText("default.vert");
            }
            if (File.Exists("default.tesc")) {
                this.txtTessellationControlShader.Text = File.ReadAllText("default.tesc");
            }
            if (File.Exists("default.tese")) {
                this.txtTessellationEvaluationShader.Text = File.ReadAllText("default.tese");
            }
            if (File.Exists("default.geom")) {
                this.txtGeometryShader.Text = File.ReadAllText("default.geom");
            }
            if (File.Exists("default.frag")) {
                this.txtFragmentShader.Text = File.ReadAllText("default.frag");
            }
            if (File.Exists("default.comp")) {
                this.txtComputeShader.Text = File.ReadAllText("default.comp");
            }
        }

        private void Form1_Load(object? sender, EventArgs e) {
            HashSet<string>? config = null;
            this.renderContext = WinGLRenderContext.Create(this.Handle, this.Width, this.Height, null, config);
            renderContext?.MakeCurrent();

            var gl = GL.Current; if (gl == null) {
                MessageBox.Show("failed to create openGL render context!");
                this.Close();
            }
        }

        private void btnCompile_Click(object sender, EventArgs e) {
            if (this.renderContext == null) return;

            this.renderContext.MakeCurrent();
            Shader? vert = null, tesc = null, tese = null, geom = null, frag = null, comp = null;
            var shaderErrorOccured = false;
            if (this.txtVertexShader.Text.Length > 0) {
                vert = Shader.Create(Shader.Kind.vert, this.txtVertexShader.Text, out var log);
                if (vert == null) {
                    shaderErrorOccured = true;
                    var form = new FormDisplayInfo(log);
                    form.Show();
                }
                else {
                    var form = new FormGLSL2cs(this.txtVertexShader.Text, "ShaderXxx : VertexCodeBase");
                    form.Show();
                }
            }
            if (this.txtTessellationControlShader.Text.Length > 0) {
                tesc = Shader.Create(Shader.Kind.tesc, this.txtTessellationControlShader.Text, out var log);
                if (tesc == null) {
                    shaderErrorOccured = true;
                    var form = new FormDisplayInfo(log);
                    form.Show();
                }
                else {
                    var form = new FormGLSL2cs(this.txtTessellationControlShader.Text, "ShaderXxx : TessControlCodeBase");
                    form.Show();
                }
            }
            if (this.txtTessellationEvaluationShader.Text.Length > 0) {
                tese = Shader.Create(Shader.Kind.tese, this.txtTessellationEvaluationShader.Text, out var log);
                if (tese == null) {
                    shaderErrorOccured = true;
                    var form = new FormDisplayInfo(log);
                    form.Show();
                }
                else {
                    var form = new FormGLSL2cs(this.txtTessellationEvaluationShader.Text, "ShaderXxx : TessEvaluationCodeBase");
                    form.Show();
                }
            }
            if (this.txtGeometryShader.Text.Length > 0) {
                geom = Shader.Create(Shader.Kind.geom, this.txtGeometryShader.Text, out var log);
                if (geom == null) {
                    shaderErrorOccured = true;
                    var form = new FormDisplayInfo(log);
                    form.Show();
                }
                else {
                    var form = new FormGLSL2cs(this.txtGeometryShader.Text, "ShaderXxx : GeometryCodeBase");
                    form.Show();
                }
            }
            if (this.txtFragmentShader.Text.Length > 0) {
                frag = Shader.Create(Shader.Kind.frag, this.txtFragmentShader.Text, out var log);
                if (frag == null) {
                    shaderErrorOccured = true;
                    var form = new FormDisplayInfo(log);
                    form.Show();
                }
                else {
                    var form = new FormGLSL2cs(this.txtFragmentShader.Text, "ShaderXxx : FragmentCodeBase");
                    form.Show();
                }
            }
            if (this.txtComputeShader.Text.Length > 0) {
                comp = Shader.Create(Shader.Kind.comp, this.txtComputeShader.Text, out var log);
                if (comp == null) {
                    shaderErrorOccured = true;
                    var form = new FormDisplayInfo(log);
                    form.Show();
                }
                else {
                    var form = new FormGLSL2cs(this.txtComputeShader.Text, "ShaderXxx : ComputeCodeBase");
                    form.Show();
                }
            }
            if (!shaderErrorOccured) {
                var list = new List<Shader>(6);
                if (vert != null) { list.Add(vert); }
                if (tesc != null) { list.Add(tesc); }
                if (tese != null) { list.Add(tese); }
                if (geom != null) { list.Add(geom); }
                if (frag != null) { list.Add(frag); }
                if (comp != null) { list.Add(comp); }
                if (list.Count > 0) {
                    var (program, log) = GLProgram.Create(list.ToArray());
                    if (program == null) {
                        var form = new FormDisplayInfo(log);
                        form.Show();
                    }
                    else {
                        MessageBox.Show("no error found!", "great", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {
                    MessageBox.Show("all shaders are empty!");
                }
            }
        }
    }
}
