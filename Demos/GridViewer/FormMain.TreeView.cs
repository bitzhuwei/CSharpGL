using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class FormMain
    {

        private void objectsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.propertyGrid1.SelectedObject = e.Node.Tag;
            var property = e.Node.Tag as GridBlockProperty;
            if (property != null)
            {
                TreeNode parent = e.Node.Parent;
                if (parent != null)
                {
                    var grid = parent.Tag as CatesianGrid;
                    if (grid != null)
                    {
                        grid.UpdateColor(property);
                        this.scientificCanvas.uiCodedColorBar.UpdateValues(property);
                    }
                }
            }
            else
            {
                var grid = e.Node.Tag as CatesianGrid;
                if (grid != null)
                {
                    grid.UpdateColor(0);
                    this.scientificCanvas.uiCodedColorBar.UpdateValues(grid.GridBlockProperties[0]);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.objectsTreeView.SelectedNode;
            if (node != null)
            {
                SceneObject obj = node.Tag as SceneObject;
                if (obj.Parent == null)
                {
                    this.scientificCanvas.Scene.ObjectList.Remove(obj);
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
