using bitzhuwei.GLSLFormat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftGLImpl;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis;
using System.Reflection;

namespace ShaderProgramErrorInfo {
    public partial class FormGLSL2cs : Form {

        private static readonly CompilerGLSL glslParser = new();

        public FormGLSL2cs() {
            InitializeComponent();
        }

        public FormGLSL2cs(string glslCode, string shaderType) {
            InitializeComponent();
            var tokens = Preprocessor.Preprocess(glslCode);
            var tree = glslParser.Parse(tokens);
            var translation_unit = glslParser.Extract(tree, tokens, glslCode);
            if (translation_unit == null) { this.textBox1.Text = $"failed to transform from glsl to C# code"; return; }

            var builder = new StringBuilder();
            builder.AppendLine($"using {nameof(SoftGLImpl)};");
            builder.AppendLine($"class {shaderType} {{");
            using (var writer = new StringWriter(builder)) {
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                var context = new FormatContext(tokens, tabUnit: 4, tabCount: 0);
                translation_unit.FullFormat(config, writer, context);
            }
            builder.AppendLine();
            builder.AppendLine("}");
            var csCode = builder.ToString();
            this.textBox1.Text = csCode;

            var assembly = Compile2Assembly(csCode, out var error);
            if (assembly == null) {
                this.textBox1.Text = $"failed to transform from glsl to C# code";
                this.textBox1.AppendText(Environment.NewLine);
                this.textBox1.AppendText(error);
                return;
            }
        }

        private static Assembly? Compile2Assembly(string sourceCode, out string error) {
            // 解析语法树
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            // 设置编译选项
            string assemblyName = Path.GetRandomFileName();
            CSharpCompilationOptions options = new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary); // 生成类库

            // 自动加载所有已加载的程序集引用
            //MetadataReference[] references = AppDomain.CurrentDomain
            //    .GetAssemblies()
            //    .Where(a => !a.IsDynamic)
            //    .Select(a => MetadataReference.CreateFromFile(a.Location))
            //    .ToArray();
            var references = new List<MetadataReference>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies) {
                if (assembly.IsDynamic) { continue; }
                if (string.IsNullOrEmpty(assembly.Location)) { continue; }
                var reference = MetadataReference.CreateFromFile(assembly.Location);
                references.Add(reference);
            }

            // 创建编译对象
            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                new[] { syntaxTree },
                references,
                options);

            // 编译到内存流
            using MemoryStream ms = new MemoryStream();
            EmitResult result = compilation.Emit(ms);

            // 处理编译错误
            if (!result.Success) {
                error = result.Diagnostics
                              .Where(d => d.IsWarningAsError || d.Severity == DiagnosticSeverity.Error)
                              .Select(d => $"{d.Id}: {d.GetMessage()}")
                              .Aggregate((current, next) => current + "\n" + next);
                return null;
            }
            else {
                error = "";
                // 加载程序集
                ms.Seek(0, SeekOrigin.Begin);
                return Assembly.Load(ms.ToArray());
            }
        }
    }
}
