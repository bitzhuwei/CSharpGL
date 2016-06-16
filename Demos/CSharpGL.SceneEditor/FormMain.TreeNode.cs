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

    }
}
