using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain
    {

        private void objectsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.propertyGrid1.SelectedObject = e.Node.Tag;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.objectsTreeView.SelectedNode;
            if (node != null)
            {
                SceneObject obj = node.Tag as SceneObject;
                if (obj.Parent == null)
                {
                    this.scene.Scene.ObjectList.Remove(obj);
                    this.objectsTreeView.Nodes.Remove(node);
                }
                else
                {
                    obj.Parent.Children.Remove(obj);
                    node.Parent.Nodes.Remove(node);
                }
            }
        }

    }
}
