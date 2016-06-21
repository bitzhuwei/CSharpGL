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

        void FormMain_Load(object sender, EventArgs e)
        {
            this.scene.Scene.ObjectList.ItemAdded += ObjectList_ItemAdded;
            this.scene.Scene.ObjectList.ItemRemoved += ObjectList_ItemRemoved;
            SceneObject ground = SceneObjectFactory.GetBuildInSceneObject(BuildInSceneObject.Ground);
            this.scene.Scene.ObjectList.Add(ground);
            SceneObject axis = SceneObjectFactory.GetBuildInSceneObject(BuildInSceneObject.Axis);
            this.scene.Scene.ObjectList.Add(axis);

            Application.Idle += Application_Idle;
        }

        void ObjectList_ItemRemoved(object sender, RemoveItemEventArgs<SceneObject> e)
        {
            if (e.RemovedItem.Parent == null)
            {
                var node = e.RemovedItem.Tag as TreeNode;
                this.objectsTreeView.Nodes.Remove(node);
            }
            else
            {
                var node = e.RemovedItem.Tag as TreeNode;
                node.Parent.Nodes.Remove(node);
            }
        }

        void ObjectList_ItemAdded(object sender, AddItemEventArgs<SceneObject> e)
        {
            if (e.NewItem.Parent == null)
            {
                int index = this.scene.Scene.ObjectList.IndexOf(e.NewItem);
                var node = new TreeNode(e.NewItem.ToString());
                node.Tag = e.NewItem;
                e.NewItem.Tag = node;
                this.objectsTreeView.Nodes.Insert(index, node);
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

        void Application_Idle(object sender, EventArgs e)
        {
            this.lblCameraInfo.Text = string.Format("eye{0}, center:{1}, up:{2}",
                this.scene.Scene.Camera.Position,
                this.scene.Scene.Camera.Target,
                this.scene.Scene.Camera.UpVector);
        }

    }
}
