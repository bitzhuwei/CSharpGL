using CSharpGL;
using System;

using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain
    {
        private void FormMain_Load(object sender, EventArgs e)
        {
            //this.scientificCanvas.Scene.RootObject.Children.ItemAdded += RootObject.Children_ItemAdded;
            //this.scientificCanvas.Scene.RootObject.Children.ItemRemoved += RootObject.Children_ItemRemoved;
            {
                SceneObject groundObj = SceneObjectFactory.GetBuildInSceneObject(BuildInSceneObject.Ground);
                {
                    BoundingBoxRenderer boxRenderer = groundObj.Renderer.GetBoundingBoxRenderer();
                    SceneObject boxObj = boxRenderer.WrapToSceneObject(new ModelScaleScript());
                    groundObj.Children.Add(boxObj);
                }
                this.scientificCanvas.Scene.RootObject.Children.Add(groundObj);
                //TreeNode groundTreeNode = this.objectsTreeView.Nodes.Add(groundObj.Name);
                //groundTreeNode.Tag = groundObj;
                TreeNode groundTreeNode = DumpTreeNode(groundObj);
                this.objectsTreeView.Nodes.Add(groundTreeNode);
            }
            {
                SceneObject axisObj = SceneObjectFactory.GetBuildInSceneObject(BuildInSceneObject.Axis);
                {
                    BoundingBoxRenderer boxRenderer = axisObj.Renderer.GetBoundingBoxRenderer();
                    SceneObject boxObj = boxRenderer.WrapToSceneObject(new ModelScaleScript());
                    axisObj.Children.Add(boxObj);
                }
                this.scientificCanvas.Scene.RootObject.Children.Add(axisObj);
                //TreeNode axisTreeNode = this.objectsTreeView.Nodes.Add(axisObj.Name);
                //axisTreeNode.Tag = axisObj;
                TreeNode axisTreeNode = DumpTreeNode(axisObj);
                this.objectsTreeView.Nodes.Add(axisTreeNode);
                this.objectsTreeView.ExpandAll();
            }
            Application.Idle += Application_Idle;
        }

        //void RootObject.Children_ItemRemoved(object sender, RemoveItemEventArgs<SceneObject> e)
        //{
        //    if (e.RemovedItem.Parent == null)
        //    {
        //        var node = e.RemovedItem.Tag as TreeNode;
        //        this.objectsTreeView.Nodes.Remove(node);
        //    }
        //    else
        //    {
        //        var node = e.RemovedItem.Tag as TreeNode;
        //        node.Parent.Nodes.Remove(node);
        //    }
        //}

        //void RootObject.Children_ItemAdded(object sender, AddItemEventArgs<SceneObject> e)
        //{
        //    if (e.NewItem.Parent == null)
        //    {
        //        int index = this.scientificCanvas.Scene.RootObject.Children.IndexOf(e.NewItem);
        //        var node = new TreeNode(e.NewItem.ToString());
        //        node.Tag = e.NewItem;
        //        e.NewItem.Tag = node;
        //        this.objectsTreeView.Nodes.Insert(index, node);
        //    }
        //    else
        //    {
        //        int index = e.NewItem.Parent.Children.IndexOf(e.NewItem);
        //        var node = new TreeNode(e.NewItem.ToString());
        //        node.Tag = e.NewItem;
        //        e.NewItem.Tag = node;
        //        (e.NewItem.Parent.Tag as TreeNode).Nodes.Insert(index, node);
        //    }
        //}

        private void Application_Idle(object sender, EventArgs e)
        {
            this.lblCameraInfo.Text = string.Format("eye{0}, center:{1}, up:{2}",
                this.scientificCanvas.Scene.FirstCamera.Position,
                this.scientificCanvas.Scene.FirstCamera.Target,
                this.scientificCanvas.Scene.FirstCamera.UpVector);
        }
    }
}