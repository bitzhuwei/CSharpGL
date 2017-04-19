using System;
using System.Collections.Generic;
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
            this.scene.RootObject.Children.Add(obj);
            this.treeView1.Nodes.Add(node);
        }

        private void Children_ItemRemoved(object sender, RemoveTreeNodeEventArgs<ITreeNode> e)
        {
            if (e.RemovedItem.Parent == null)
            {
                var node = (e.RemovedItem as SceneObject).Tag as TreeNode;
                this.treeView1.Nodes.Remove(node);
            }
            else
            {
                var node = (e.RemovedItem as SceneObject).Tag as TreeNode;
                node.Parent.Nodes.Remove(node);
            }
        }

        private void Children_ItemAdded(object sender, AddTreeNodeEventArgs<ITreeNode> e)
        {
            //if (e.NewItem.Parent == null)
            //{
            //    int index = this.scene.RootObject.Children.IndexOf(e.NewItem);
            //    var node = new TreeNode(e.NewItem.ToString());
            //    node.Tag = e.NewItem;
            //    e.NewItem.Tag = node;
            //    this.treeView1.Nodes.Insert(index, node);
            //}
            //else
            {
                int index = e.NewItem.Parent.Children.IndexOf(e.NewItem);
                var node = new TreeNode(e.NewItem.ToString());
                node.Tag = e.NewItem;
                (e.NewItem as TreeNode).Tag = node;
                ((e.NewItem.Parent as TreeNode).Tag as TreeNode).Nodes.Insert(index, node);
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
                    var parent = obj.Parent as SceneObject;
                    if (parent != null)
                    { parent.Children.Remove(obj); }
                    else
                    { /* nothing to do */ }
                }
                {
                    this.scene.RootObject.Children.Remove(node.Tag as SceneObject);
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
                var frmSelectScript = new FormSelectType(typeof(Script));
                if (frmSelectScript.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var obj = node.Tag as SceneObject;
                    var script = Activator.CreateInstance(frmSelectScript.SelectedType) as Script;
                    obj.Scripts.Add(script);
                }
            }
        }

        private void deleteScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node != null)
            {
                var obj = node.Tag as SceneObject;
                obj.Scripts.Clear();
            }
        }

        private void refreshTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            foreach (SceneObject sceneObject in this.scene.RootObject)
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

        private TreeNode[] GetTreeNodes(ChildList<ITreeNode> list)
        {
            var result = new TreeNode[list.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var node = new TreeNode((list[i] as TreeNode).Name);
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