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

namespace demos.anything {
    public partial class FormNodePropertyGrid : Form {
        public FormNodePropertyGrid(SceneNodeBase node) {
            InitializeComponent();

            this.trvScene.AfterSelect += trvScene_AfterSelect;

            Match(node);
        }

        public void SetNode(SceneNodeBase? node) {
            Match(node);
        }

        private void Match(SceneNodeBase? sceneNode) {
            this.trvScene.Nodes.Clear();
            if (sceneNode != null) {
                var node = new TreeNode(sceneNode.ToString()) { Tag = sceneNode };
                this.trvScene.Nodes.Add(node);
                Match(node, sceneNode);
            }
        }
        private void Match(TreeNode node, SceneNodeBase sceneNode) {
            foreach (var item in sceneNode.Children) {
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
