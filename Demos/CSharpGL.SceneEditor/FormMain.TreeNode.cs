using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            obj.Children.ItemAdded += Children_ItemAdded;
            obj.Children.ItemRemoved += Children_ItemRemoved;
            var node = new TreeNode(obj.ToString());
            node.Tag = obj;
            obj.Tag = node;
            this.scene.ObjectList.Add(obj);
            this.treeView1.Nodes.Add(node);
        }

        void Children_ItemRemoved(object sender, RemoveItemEventArgs<SceneObject> e)
        {
            if (e.RemovedItem.Parent == null)
            {
                var node = e.RemovedItem.Tag as TreeNode;
                this.treeView1.Nodes.Remove(node);
            }
            else
            {
                var node = e.RemovedItem.Tag as TreeNode;
                node.Parent.Nodes.Remove(node);
            }
        }

        void Children_ItemAdded(object sender, AddItemEventArgs<SceneObject> e)
        {
            if (e.NewItem.Parent == null)
            {
                int index = this.scene.ObjectList.IndexOf(e.NewItem);
                var node = new TreeNode(e.NewItem.ToString());
                node.Tag = e.NewItem;
                e.NewItem.Tag = node;
                this.treeView1.Nodes.Insert(index, node);
            }
            else
            {
                int index = e.NewItem.Parent.Children.IndexOf(e.NewItem);
                var node = new TreeNode(e.NewItem.ToString());
                node.Tag = e.NewItem;
                e.NewItem.Tag = node;
                (e.NewItem.Parent.Tag as TreeNode).Nodes.Insert(index, node);
            }
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
                    this.scene.ObjectList.Remove(node.Tag as SceneObject);
                    TreeNode parent = node.Parent;
                    if (parent != null)
                    { parent.Nodes.Remove(node); }
                    else
                    { this.treeView1.Nodes.Remove(node); }
                }
            }
        }

        private void addScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node != null)
            {
                var frmSelectScript = new FormSelectType(typeof(ScriptComponent));
                if (frmSelectScript.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var obj = node.Tag as SceneObject;
                    var script = Activator.CreateInstance(frmSelectScript.SelectedType) as ScriptComponent;
                    obj.ScriptList.Add(script);
                }
            }
        }

        private void deleteScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node != null)
            {
                var obj = node.Tag as SceneObject;
                obj.ScriptList.Clear();
            }
        }

        private void refreshTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            foreach (var sceneObject in this.scene.ObjectList)
            {
                var node = new TreeNode(sceneObject.Name);
                node.Tag = sceneObject;
                if (sceneObject.Children.Count > 0)
                {
                    TreeNode[] childNodes = GetTreeNodes(sceneObject.Children);
                    node.Nodes.AddRange(childNodes);
                }
                this.treeView1.Nodes.Add(node);
            }

            this.treeView1.ExpandAll();
        }

        private TreeNode[] GetTreeNodes(IList<SceneObject> list)
        {
            var result = new TreeNode[list.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var node = new TreeNode(list[i].Name);
                node.Tag = list[i];
                if (list[i].Children.Count > 0)
                {
                    TreeNode[] childNodes = GetTreeNodes(list[i].Children);
                    node.Nodes.AddRange(childNodes);
                }
                result[i] = node;
            }

            return result;
        }

    }
}
