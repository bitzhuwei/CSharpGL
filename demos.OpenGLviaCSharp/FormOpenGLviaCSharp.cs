using CSharpGL;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace demos.OpenGLviaCSharp {
    public unsafe partial class FormOpenGLviaCSharp : Form {

        public FormOpenGLviaCSharp() {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object? sender, EventArgs e) {
            var baseType = typeof(demoCode);
            var instanceTypes = from item in Assembly.GetExecutingAssembly().GetTypes()
                                where item.BaseType == baseType
                                select item;
            foreach (var item in instanceTypes) {
                this.listBox1.Items.Add(new NameType(item.Name, item));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.listBox1.SelectedItem is NameType item) {
                (new FormInstance(item.type)).Show();
            }
        }

        class NameType {
            public readonly string Name;
            public readonly Type type;

            public NameType(string name, Type type) {
                Name = $"OpenGL via C# demo: {name}";
                this.type = type;
            }

            public override string ToString() => this.Name;
        }
    }
}
