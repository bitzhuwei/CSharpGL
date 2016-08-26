using CSharpGL;
using SimLab.helper;
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

        //private TreeNode lastSelectedBoxNode;
        private BoundingBoxRenderer lastselectedBoxRenderer;
        private bool UpdateCurrentNode(TreeNode node)
        {
            bool updated = false;
            var stack = new Stack<TreeNode>();
            stack.Push(node);
            BoundingBoxRenderer selectedRenderer = null;
            while (stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                var obj = current.Tag as SceneObject;
                if (obj != null)
                {
                    var renderer = obj.Renderer as BoundingBoxRenderer;
                    if (renderer != null)
                    {
                        selectedRenderer = renderer;
                        break;
                    }
                }
                foreach (TreeNode item in current.Nodes)
                {
                    stack.Push(item);
                }
            }

            if (selectedRenderer != lastselectedBoxRenderer)
            {
                if (selectedRenderer != null)
                {
                    selectedRenderer.BoundingBoxColor = Color.Aqua;
                    var glSwitch = selectedRenderer.SwitchList.Find(x => x is LineWidthSwitch) as LineWidthSwitch;
                    glSwitch.LineWidth = 3;
                }

                if (lastselectedBoxRenderer != null)
                {
                    lastselectedBoxRenderer.BoundingBoxColor = Color.White;
                    var glSwitch = lastselectedBoxRenderer.SwitchList.Find(x => x is LineWidthSwitch) as LineWidthSwitch;
                    glSwitch.LineWidth = 1;
                }

                this.lastselectedBoxRenderer = selectedRenderer;
                updated = true;
            }

            return updated;
        }
        //private bool UpdateCurrentNode(TreeNode node)
        //{
        //    bool updated = false;
        //    if (node == lastSelectedBoxNode) { return updated; }

        //    {
        //        var obj = node.Tag as SceneObject;
        //        if (obj != null)
        //        {
        //            var renderer = obj.Renderer as BoundingBoxRenderer;
        //            if (renderer != null)
        //            {
        //                renderer.BoundingBoxColor = Color.Aqua;
        //                var glSwitch = renderer.SwitchList.Find(x => x is LineWidthSwitch) as LineWidthSwitch;
        //                glSwitch.LineWidth = 3;
        //                updated = true;
        //            }
        //        }
        //    }

        //    if (updated && lastSelectedBoxNode != null)
        //    {
        //        var obj = lastSelectedBoxNode.Tag as SceneObject;
        //        if (obj != null)
        //        {
        //            var renderer = obj.Renderer as BoundingBoxRenderer;
        //            if (renderer != null)
        //            {
        //                renderer.BoundingBoxColor = Color.White;
        //                var glSwitch = renderer.SwitchList.Find(x => x is LineWidthSwitch) as LineWidthSwitch;
        //                glSwitch.LineWidth = 1;
        //                updated = true;
        //            }
        //        }
        //    }

        //    if (updated)
        //    {
        //        this.lastSelectedBoxNode = node;
        //    }

        //    return updated;
        //}

        private void objectsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool updated = false;
            updated = UpdateCurrentNode(e.Node) || updated;

            var node = e.Node as AbstractTreeNode;
            if (node != null)
            {
                node.Selected(sender, e);
                updated = true;
            }

            if (e.Node.Tag != null)
            { this.lblSelectedType.Text = e.Node.Tag.GetType().FullName; }
            else
            { this.lblSelectedType.Text = ""; }
            this.propertyGrid1.SelectedObject = e.Node.Tag;

            //if (e.Node.Tag is GridBlockProperty)
            //{
            //    var property = e.Node.Tag as GridBlockProperty;
            //    var sceneObject = e.Node.Parent.Tag as SceneObject;
            //    BoundedRenderer boundedRenderer = (sceneObject.Renderer as BoundedRendererComponent).Renderer;
            //    if (boundedRenderer.Renderer is CatesianGridRenderer)
            //    {
            //        CatesianGrid grid = (boundedRenderer.Renderer as CatesianGridRenderer).Grid;
            //        UpdateCatesianGrid(grid, property);
            //    }
            //    this.scientificCanvas.Invalidate();
            //}
            //else if (e.Node.ToolTipText == typeof(CatesianGrid).Name)
            //{
            //    var sceneObject = e.Node.Tag as SceneObject;
            //    CatesianGrid grid = ((sceneObject.Renderer as BoundedRendererComponent).Renderer.Renderer as CatesianGridRenderer).Grid;
            //    GridBlockProperty property = grid.GridBlockProperties[0];
            //    UpdateCatesianGrid(grid, property);
            //    this.scientificCanvas.Invalidate();
            //}

            if (updated)
            {
                this.scientificCanvas.Scene.Update();
                this.scientificCanvas.Invalidate();
            }
        }

        private void UpdateCatesianGrid(CatesianGrid grid, GridBlockProperty property)
        {
            double axisMin, axisMax, step;
            ColorIndicatorAxisAutomator.Automate(property.MinValue, property.MaxValue, out axisMin, out axisMax, out step);
            grid.MinColorCode = (float)axisMin;
            grid.MaxColorCode = (float)axisMax;
            grid.UpdateColor(property);
            this.scientificCanvas.ColorPalette.SetCodedColor(axisMin, axisMax, step);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.objectsTreeView.SelectedNode;
            if (node == null) { return; }
            SceneObject obj = node.Tag as SceneObject;
            if (obj == null) { return; }

            if (obj.Parent == null) { throw new Exception("This should not happen."); }

            obj.Parent.Children.Remove(obj);
            if (node.Parent == null)
            { this.objectsTreeView.Nodes.Remove(node); }
            else
            { node.Parent.Nodes.Remove(node); }

            obj.Dispose();

            this.scientificCanvas.Invalidate();
        }

        /// <summary>
        /// move camera to focus on selected scene object again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adjustCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.objectsTreeView.SelectedNode;
            if (node == null) { return; }
            SceneObject obj = node.Tag as SceneObject;
            if (obj == null) { return; }
            var transform = obj.Renderer as IModelSpace;
            if (transform == null) { return; }
            vec3 position = transform.ModelMatrix.GetTranslate();
            var max = transform.Lengths / 2;
            var min = -max;
            IBoundingBox translatedBox = new BoundingBox(min + position, max + position);
            translatedBox.ZoomCamera(this.scientificCanvas.Scene.Camera);

            this.scientificCanvas.Invalidate();
        }
    }
}
