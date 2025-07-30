using CSharpGL;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace demos.glSuperBible7code {
    public unsafe partial class FormGLSuperBible7 : Form {

        public FormGLSuperBible7() {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object? sender, EventArgs e) {
            var baseType = typeof(_glSuperBible7code);
            var instanceTypes = from item in Assembly.GetExecutingAssembly().GetTypes()
                                where item.BaseType == baseType
                                select item;
            foreach (var item in instanceTypes) {
                this.listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var item = this.listBox1.SelectedItem as Type;
            if (item == null) return;

            (new FormInstance(item)).Show();
        }
    }
}
