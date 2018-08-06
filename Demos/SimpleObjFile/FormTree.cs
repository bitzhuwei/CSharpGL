using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleObjFile
{
    public partial class FormTree : Form
    {
        private Scene scene;
        public FormTree(Scene scene)
        {
            InitializeComponent();

            this.scene = scene;
        }

        private void Match(TreeView treeView, SceneNodeBase nodeBase)
        {
            treeView.Nodes.Clear();
            var node = new TreeNode(nodeBase.ToString()) { Tag = nodeBase };
            treeView.Nodes.Add(node);
            Match(node, nodeBase);
        }

        private void Match(TreeNode node, SceneNodeBase nodeBase)
        {
            foreach (var item in nodeBase.Children)
            {
                var child = new TreeNode(item.ToString()) { Tag = item };
                node.Nodes.Add(child);
                Match(child, item);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();

        }
    }
}
