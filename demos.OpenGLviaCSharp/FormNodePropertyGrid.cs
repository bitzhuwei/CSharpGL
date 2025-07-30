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
    public partial class FormNodePropertyGrid : Form {
        public FormNodePropertyGrid(SceneNodeBase node) {
            InitializeComponent();

            this.trvScene.AfterSelect += trvScene_AfterSelect;

            Match(node);
        }

        private void Match(SceneNodeBase rootNode) {
            this.trvScene.Nodes.Clear();
            var node = new TreeNode(rootNode.ToString()) { Tag = rootNode };
            this.trvScene.Nodes.Add(node);
            Match(node, rootNode);
        }
        private void Match(TreeNode node, SceneNodeBase nodeBase) {
            foreach (var item in nodeBase.Children) {
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
