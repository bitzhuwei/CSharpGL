using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demos.OpenGLviaCSharp {
    public partial class FormGLControlPropertyGrid : Form {
        public FormGLControlPropertyGrid(GLControl control) {
            InitializeComponent();

            this.trvScene.AfterSelect += trvScene_AfterSelect;

            Match(control);
        }

        private void Match(GLControl control) {
            this.trvScene.Nodes.Clear();
            var node = new TreeNode(control.ToString()) { Tag = control };
            this.trvScene.Nodes.Add(node);
            Match(node, control);
        }
        private void Match(TreeNode node, GLControl control) {
            foreach (var item in control.Children) {
                var child = new TreeNode(item.ToString()) { Tag = item };
                node.Nodes.Add(child);
                Match(child, item);
            }
        }

        private void trvScene_AfterSelect(object? sender, TreeViewEventArgs e) {
            this.propertyGrid1.SelectedObject = e.Node.Tag;
        }
    }
}
