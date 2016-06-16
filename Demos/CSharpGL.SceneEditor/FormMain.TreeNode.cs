using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {

        private void addSceneObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildInSceneObject type = (BuildInSceneObject)Enum.Parse(typeof(BuildInSceneObject),
                (sender as ToolStripItem).Text);
            SceneObject obj = SceneObjectFactory.GetBuildInSceneObject(type);
            var node = new TreeNode(obj.ToString());
            node.Tag = obj;
            this.Scene.ObjectList.Add(obj);
            this.treeView1.Nodes.Add(node);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node != null)
            {
                node.Text = string.Format("{0}", node.Tag);
                this.propertyGrid1.SelectedObject = node.Tag;
            }
            else
            {
                this.propertyGrid1.SelectedObject = null;
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node != null)
            {
                node.Text = string.Format("{0}", node.Tag);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node != null)
            {
                {
                    var obj = node.Tag as SceneObject;
                    SceneObject parent = obj.Parent;
                    if (parent != null)
                    { parent.Children.Remove(obj); }
                    else
                    { /* nothing to do */ }
                }
                {
                    this.Scene.ObjectList.Remove(node.Tag as SceneObject);
                    TreeNode parent = node.Parent;
                    if (parent != null)
                    { parent.Nodes.Remove(node); }
                    else
                    { this.treeView1.Nodes.Remove(node); }
                }
            }
        }
    }
}
